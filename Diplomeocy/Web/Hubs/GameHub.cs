using System.Diagnostics;

using Diplomacy;
using Diplomacy.Orders;

using Game.Utils;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Localization;

using Newtonsoft.Json;

namespace Web.Hubs;

public class GameHub : Hub {
	private readonly Dictionary<string, GameHandler> gameHandlers;
	private readonly ILogger<GameHub> logger;

	public GameHub(ILogger<GameHub> logger, Dictionary<string, GameHandler> gameHandlers) : base() {
		this.logger = logger;
		this.gameHandlers = gameHandlers;
	}

	public Task JoinGameGroup(string gameId) {
		Groups.AddToGroupAsync(Context.ConnectionId, gameId);
		return Clients.Client(Context.ConnectionId).SendAsync("JoinGameGroupConfirm", gameId);
	}

	public Task RequestState(string gameId) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}
		string state = JsonConvert.SerializeObject(handler!.Players, new JsonSerializerSettings {
			Converters = { new Web.Serializers.Game.PlayerConverter() }
		});
		// handler.Players.ForEach(
		// 			player => player.Countries.ForEach(
		// 				country =>
		// 					country.TerritoriesSerializationNames.ForEach(
		// 						territoryName =>
		// 							country.Territories.Add(handler.Board.Territory(territoryName)))));
		// handler.Players.ForEach(
		// 	player => player.UnitsSerializationData.ForEach(
		// 		data =>
		// 			player.Units.Add(new Unit {
		// 				Country = Enum.Parse<Countries>(player.Countries[0].Name),
		// 				Type = (UnitType)int.Parse(data.type),
		// 				Location = handler.Board.Territory(Enum.Parse<Territories>(data.location))
		// 			})));
		handler!.Players.ForEach(player => Debug.WriteLine(player.Units.Count));
		return Clients.Client(Context.ConnectionId).SendAsync("RequestStateResponse", state);
	}

	public Task RequestAvailableMovements(string gameId, string country) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		handler!.Players.ForEach(player => Debug.WriteLine($"{player.Countries[0].Name} -> {player.Units.Count}"));
		Player player = handler.Players.First(player => player.Countries[0].Name == country);

		Dictionary<Territories, List<string>> convoyMovements = new();
		player.Units
			.Where(unit => Board.CoastalTerritories.Contains(Enum.Parse<Territories>(unit.Location!)))
			.Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
			.ToList()
			.ForEach(t => {
				Stack<Territories> territories = new();
				territories.Push(t);
				List<Territories> waterVisited = new();
				while (territories.Any()) {
					Territories territory = territories.Pop();

					if (waterVisited.Contains(territory)) continue;
					waterVisited.Add(territory);

					Debug.WriteLine("Looking at " + territory);
					IEnumerable<Territories> landAdjacencies = Board.TerritoryAdjacency(handler.Board, territory)
						.Where(terr => !Board.WaterTerritories.Contains(Enum.Parse<Territories>(terr)))
						.Select(terr => Enum.Parse<Territories>(terr.Name));
					IEnumerable<Territories> waterAdjacencies = Board.TerritoryAdjacency(handler.Board, territory)
						.Where(terr => terr.OccupyingUnit is not null && Board.WaterTerritories.Contains(Enum.Parse<Territories>(terr)))
						.Select(terr => Enum.Parse<Territories>(terr.Name));

					if (!convoyMovements.TryGetValue(t, out List<string>? movements)) {
						movements = new();
						convoyMovements.Add(t, movements);
					}

					movements.AddRange(landAdjacencies.Select(adj => adj.ToString()));
					waterAdjacencies.ToList().ForEach(territories.Push);
				}
			});

		Dictionary<Territories, List<string>> adjacencies = player
				.Units
				.Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
				.ToDictionary(
					territory => territory,
					territory => Board
									.TerritoryAdjacency(handler.Board, territory)
									.Where(adjacency =>
										Board.CanUnitGoThere(player.Unit(territory), Enum.Parse<Territories>(adjacency.Name)))
									.Select(adjacency => adjacency.Name)
									.Concat(convoyMovements.GetValueOrDefault(territory, new()))
									.Distinct()
									.ToList()
				);
		string json = JsonConvert.SerializeObject(adjacencies);
		return Clients.Client(Context.ConnectionId).SendAsync("RequestAvailableMovementsResponse", json);
	}

	public Task AddOrder(string gameId, string country, string from, string to, string type, string? unit = null) {
		Debug.WriteLine($"received {gameId} {country} {from} {to} {type}");
		// return Task.CompletedTask;
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Territories territoryFrom = Enum.Parse<Territories>(from);
		Territories territoryTo = Enum.Parse<Territories>(to);
		Enum.TryParse(unit, true, out Territories territoryUnit);

		Player player = handler.Players.First(player => player.Countries[0].Name == country);


		Order? order = null;

		if (type == "move") {
			if (player.Orders.FirstOrDefault(order => order.Unit == player.Unit(territoryFrom)) is Order existingOrder) {
				player.Orders.Remove(existingOrder);
			}
			order = new MoveOrder {
				Unit = player.Unit(territoryFrom),
				IsConvoyed = true,
				Target = handler.Board.Territory(territoryTo)
			};
		} else if (type == "hold") {
			if (player.Orders.FirstOrDefault(order => order.Unit == player.Unit(territoryFrom)) is Order existingOrder) {
				player.Orders.Remove(existingOrder);
			}
			order = new HoldOrder {
				Unit = player.Unit(territoryFrom),
			};
		} else if (type == "support") {
			if (player.Orders.FirstOrDefault(order => order.Unit == player.Unit(territoryUnit)) is Order existingOrder) {
				player.Orders.Remove(existingOrder);
			}
			order = new SupportOrder {
				Unit = player.Unit(territoryUnit),
				SupportedOrder = null,
				WillSupport = (territoryFrom, territoryTo),
			};
		}

		if (order is null) return Task.FromCanceled(CancellationToken.None);
		player.Orders.Add(order);

		if (player.Orders.Count == player.Units.Count) {
			handler.Players.ForEach(player => {
				if (!handler.IsPlayerReady.TryAdd(player, true)) {
					handler.IsPlayerReady[player] = true;
				}
			});

			if (handler.IsPlayerReady.All(kvp => kvp.Value) || true /* REMBER TO DELTE THSI */) {
				// everyone's ready

				handler.Players
					.Where(player => player.Orders.Count != player.Units.Count)
					.ToList()
					.ForEach(player =>
								player.Units.Where(unit => !player.Orders.Any(order => order.Unit == unit))
								.ToList()
								.ForEach(unit => player.Orders.Add(new HoldOrder {
									Unit = unit,
								})));
				handler.Players
					.ForEach(player => player.Orders
						.OfType<SupportOrder>()
						.Where(so => so.SupportedOrder is null)
						.ToList()
						.ForEach(so => {
							Order? supportedOrder = handler.Players
								.SelectMany(player => player.Orders)
								.FirstOrDefault(order =>
									order.Unit.Location == handler.Board.Territory(so.WillSupport.From)
									&& (order.Target is null
										|| (order.Target is not null
											&& order.Target == handler.Board.Territory(so.WillSupport.To))));
							if (order is null) {
								so.Status = OrderStatus.Failed;
							} else {
								so.SupportedOrder = supportedOrder;
							}
						}));
				handler.ResolveOrderResolutionPhase();
				handler.GameTurn.Phase = GamePhase.AdvanceTurn;
				handler.IsPlayerReady.Clear();
				// handler.Players.ForEach(p => handler.IsPlayerReady.Add(p, false));
				Clients.Group(gameId).SendAsync("AdvanceTurn");
			}
		}

		return Clients.Client(Context.ConnectionId).SendAsync("AddOrderResponse");
	}

	public Task RequestAvailableSupports(string gameId, string country) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Player player = handler!.Players.First(p => p.Countries[0].Name == country);
		Dictionary<string, Dictionary<string, List<string>>> supportLocations = player.Units
			.ToDictionary(
				unit =>
					unit.Location!.Name,
				unit =>
					unit.Location!.AdjacentTerritories
						.SelectMany(adjacency => adjacency.AdjacentTerritories)
						.Concat(unit.Location!.AdjacentTerritories)
						.Distinct()
						.Where(adjacency => adjacency.OccupyingUnit is not null)
						.Where(adjacency => unit.Location != adjacency)
						.ToDictionary(
							from => from.Name,
							from => from.AdjacentTerritories
								.Intersect(unit.Location!.AdjacentTerritories
									.Where(territory =>
										unit.Location != territory))
								.Select(territory => territory.Name)
								.ToList()
						)
				);

		return Clients.Client(Context.ConnectionId).SendAsync("RequestAvailableSupportsResponse", JsonConvert.SerializeObject(supportLocations));
	}

	public Task Meow() {
		return Task.CompletedTask;
	}
}

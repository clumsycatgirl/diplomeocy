using System.Diagnostics;

using Diplomacy;
using Diplomacy.Orders;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

		Dictionary<Territories, List<string>> adjacencies =
			handler.Players
				.First(player => player.Countries[0].Name == country)
				.Units
				.Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
				.ToDictionary(
					territory => territory,
					territory => Board
									.TerritoryAdjacency(handler.Board, territory)
									.Select(adjacency => adjacency.Name)
									.ToList()
				);
		string json = JsonConvert.SerializeObject(adjacencies);
		return Clients.Client(Context.ConnectionId).SendAsync("RequestAvailableMovementsResponse", json);
	}

	public Task AddOrder(string gameId, string country, string from, string to, string type) {
		Debug.WriteLine($"received {gameId} {country} {from} {to} {type}");
		// return Task.CompletedTask;
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Territories territoryFrom = Enum.Parse<Territories>(from);
		Territories territoryTo = Enum.Parse<Territories>(to);

		Player player = handler.Players.First(player => player.Countries[0].Name == country);

		if (player.Orders.FirstOrDefault(order => order.Unit == player.Unit(territoryFrom)) is Order existingOrder) {
			player.Orders.Remove(existingOrder);
		}

		Order order = new MoveOrder {
			Unit = player.Unit(territoryFrom),
			Target = handler.Board.Territory(territoryTo)
		};
		player.Orders.Add(order);

		Debug.WriteLine($"Adding {order} to {country}");

		if (player.Orders.Count == player.Units.Count) {
			handler.Players.ForEach(player => {
				if (!handler.IsPlayerReady.TryAdd(player, true)) {
					handler.IsPlayerReady[player] = true;
				}
			});

			if (handler.IsPlayerReady.All(kvp => kvp.Value) || true /* REMBER TO DELTE THSI */) {
				// everyone's ready
				handler.ResolveOrderResolutionPhase();
				handler.GameTurn.Phase = GamePhase.AdvanceTurn;
				handler.IsPlayerReady.Clear();
				// handler.Players.ForEach(p => handler.IsPlayerReady.Add(p, false));
				Clients.Group(gameId).SendAsync("AdvanceTurn");
			}
		}

		return Clients.Client(Context.ConnectionId).SendAsync("AddOrderResponse");
	}

	public Task Meow() {
		return Task.CompletedTask;
	}
}

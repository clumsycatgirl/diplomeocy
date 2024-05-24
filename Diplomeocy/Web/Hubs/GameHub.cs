using System.Diagnostics;

using Diplomacy;
using Diplomacy.Orders;

using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;

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

		GetConvoyMovements(handler).TryGetValue(player, out Dictionary<Territories, List<string>>? convoyMovements);
		if (convoyMovements is null) convoyMovements = new();

		// Dictionary<Territories, List<string>> adjacencies = player
		// 		.Units
		// 		.Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
		// 		.ToDictionary(
		// 			territory => territory,
		// 			territory => Board
		// 							.TerritoryAdjacency(handler.Board, territory)
		// 							.Where(adjacency =>
		// 								Board.CanUnitGoThere(player.Unit(territory), Enum.Parse<Territories>(adjacency.Name)))
		// 							.Select(adjacency => adjacency.Name)
		// 							.Concat(convoyMovements.GetValueOrDefault(territory, new()))
		// 							.Distinct()
		// 							.ToList()
		// 		);
		Dictionary<Territories, List<string>> adjacencies = player
			.Units
			.Where(unit => unit.Location is not null)
			.Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
			.ToDictionary(
				territory => territory,
				territory => Board
								.TerritoryAdjacency(handler.Board, territory)
								.Where(adjacency =>
									Board.CanUnitGoThere(player.Unit(territory), Enum.Parse<Territories>(adjacency.Name)))
								.Select(adjacency => adjacency.Name)
								.Concat(convoyMovements.GetValueOrDefault(territory, new()))
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
			bool isConvoyed = !handler.Board.Territory(territoryFrom)
				.AdjacentTerritories.Contains(handler.Board.Territory(territoryTo));
			order = new MoveOrder {
				Unit = player.Unit(territoryFrom),
				IsConvoyed = isConvoyed,
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
		} else if (type == "convoy") {
			order = new ConvoyOrder {
				Unit = player.Unit(territoryUnit),
				WillConvoy = (territoryFrom, territoryTo),
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
				handler.Players
					.ForEach(player => player.Orders
						.OfType<ConvoyOrder>()
						.Where(co => co.ConvoyedOrder is null)
						.ToList()
						.ForEach(co => {
							Order? convoyedOrder = handler.Players
								.SelectMany(player => player.Orders)
								.FirstOrDefault(order =>
									order.Unit.Location == handler.Board.Territory(co.WillConvoy.From)
									&& order.Target == handler.Board.Territory(co.WillConvoy.To));
							if (convoyedOrder is null) {
								co.Status = OrderStatus.Failed;
							} else {
								co.ConvoyedOrder = (MoveOrder)convoyedOrder;
							}
						}));
				handler.AdvanceTurn();
				handler.IsPlayerReady.Clear();
				handler.Players.ForEach(p => p.Orders.Clear());
				// handler.Players.ForEach(p => handler.IsPlayerReady.Add(p, false));
				Clients.Group(gameId).SendAsync("AdvanceTurn", handler.GameTurn);
			}
		}

		return Clients.Client(Context.ConnectionId).SendAsync("AddOrderResponse");
	}

	public Task RequestAvailableSupports(string gameId, string country) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Player player = handler!.Players.First(p => p.Countries[0].Name == country);
		//Dictionary<string, Dictionary<string, List<string>>> supportLocations = player.Units
		//	.Where(unit => unit.Location is not null)
		//	.ToDictionary(
		//		unit =>
		//			unit.Location!.Name,
		//		unit =>
		//			unit.Location!.AdjacentTerritories
		//				.SelectMany(adjacency => adjacency.AdjacentTerritories)
		//				.Concat(unit.Location!.AdjacentTerritories)
		//				.Distinct()
		//				.Where(adjacency => adjacency.OccupyingUnit is not null)
		//				.Where(adjacency => unit.Location != adjacency)
		//				.ToDictionary(
		//					from => from.Name,
		//					from => from.AdjacentTerritories
		//						.Intersect(unit.Location!.AdjacentTerritories
		//							.Where(territory =>
		//								unit.Location != territory))
		//						.Select(territory => territory.Name)
		//						.Distinct()
		//						.ToList()
		//				)
		//		);
		Dictionary<string, Dictionary<string, List<string>>> supportLocations = new Dictionary<string, Dictionary<string, List<string>>>();

		foreach (Unit unit in player.Units) {
			if (unit.Location == null) {
				continue;
			}

			string unitLocationName = unit.Location.Name;
			if (!supportLocations.ContainsKey(unitLocationName)) {
				supportLocations[unitLocationName] = new Dictionary<string, List<string>>();
			}

			HashSet<string> adjacentTerritoryNames = new HashSet<string>();

			// Collect all adjacent territories and their adjacent territories
			foreach (Territory adjacency in unit.Location.AdjacentTerritories) {
				foreach (Territory adjacentAdjacency in adjacency.AdjacentTerritories) {
					adjacentTerritoryNames.Add(adjacentAdjacency.Name);
				}
				adjacentTerritoryNames.Add(adjacency.Name);
			}

			// Remove the unit's own location from the set
			adjacentTerritoryNames.Remove(unitLocationName);

			// Iterate over the unique set of adjacent territories
			foreach (string adjacentTerritoryName in adjacentTerritoryNames) {
				Territory? adjacentTerritory = unit.Location.AdjacentTerritories.FirstOrDefault(at => at.Name == adjacentTerritoryName);
				if (adjacentTerritory is null || adjacentTerritory.OccupyingUnit is null) {
					continue;
				}

				if (!supportLocations[unitLocationName].ContainsKey(adjacentTerritoryName)) {
					supportLocations[unitLocationName][adjacentTerritoryName] = new List<string>();
				}

				foreach (Territory territory in adjacentTerritory.AdjacentTerritories) {
					bool isAdjacent = unit.Location.AdjacentTerritories.Any(at => at.Name == territory.Name);
					if (isAdjacent && unitLocationName != territory.Name) {
						supportLocations[unitLocationName][adjacentTerritoryName].Add(territory.Name);
					}
				}

				// Remove duplicates from the list
				List<string> distinctTerritories = supportLocations[unitLocationName][adjacentTerritoryName].Distinct().ToList();
				supportLocations[unitLocationName][adjacentTerritoryName] = distinctTerritories;
			}
		}


		return Clients.Client(Context.ConnectionId).SendAsync("RequestAvailableSupportsResponse", JsonConvert.SerializeObject(supportLocations));
	}

	public Task RequestConvoyRoutes(string gameId, string country) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Dictionary<Territories, List<string>> convoyRoutes = GetConvoyMovements(handler)
			.SelectMany(kvp => kvp.Value)
			.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value
			);

		convoyRoutes.ToList().ForEach(kvp => { Debug.WriteLine(kvp.Key); kvp.Value.ForEach(val => Debug.WriteLine($"\t{val}")); });

		Player player = handler.Players.First(player => player.Countries[0].Name == country);

		// {unit} -> {who} -> [where]
		Dictionary<string, Dictionary<string, List<string>>> result = new();
		// result["units"] = new();
		// result["destinations"] = new();

		player.Units
			.Where(unit => unit.Location is not null)
			.Where(unit => Board.WaterTerritories.Contains(Enum.Parse<Territories>(unit.Location!.Name)))
			.ToList()
			.ForEach(unit => {
				string unitLocation = unit.Location!.Name;

				result[unitLocation] = new();

				// result[unitLocation]["units"];

				// unit.Location!.AdjacentTerritories
				// 	.Where(territory => territory.OccupyingUnit is not null)
				// 	.Where(territory => territory.OccupyingUnit?.Type == UnitType.Army)
				// 	.Select(territory => territory.Name)
				// 	.ToList()
				// 	.ForEach(adjacentTerritory => {
				// convoyRoutes.TryGetValue(Enum.Parse<Territories>(adjacentTerritory), out List<string>? destinations);
				// destinations ??= new();

				HashSet<Territories> visited = new();
				Stack<Territory> territoriesToVisit = new();
				territoriesToVisit.Push(unit.Location!);

				List<string> destinations = new();

				while (territoriesToVisit.Any()) {
					Territory currentTerritory = territoriesToVisit.Pop();
					Territories currentAsEnum = Enum.Parse<Territories>(currentTerritory.Name);

					if (visited.Contains(currentAsEnum)) continue;
					visited.Add(currentAsEnum);

					IEnumerable<string> landNearMe = Board.TerritoryAdjacency(handler.Board, currentAsEnum)
						.Select(adjacentTerritory => Enum.Parse<Territories>(adjacentTerritory.Name))
						.Where(adjacentTerritory => Board.CoastalTerritories.Contains(adjacentTerritory))
						.Select(adjacentTerritory => adjacentTerritory.ToString());

					destinations.AddRange(landNearMe);

					Board.TerritoryAdjacency(handler.Board, currentAsEnum)
						.Where(adjacentTerritory => Board.WaterTerritories.Contains(Enum.Parse<Territories>(adjacentTerritory.Name)))
						.ToList()
						.ForEach(territoriesToVisit.Push);
				}

				result[unitLocation]["destinations"] = destinations;
				result[unitLocation]["units"] = destinations
					.Select(territory => handler.Board.Territory(territory).OccupyingUnit)
					.Where(unit => unit is not null && unit.Location is not null)
					.Select(unit => unit!.Location!.Name)
					.ToList();
				// });
			});

		string json = JsonConvert.SerializeObject(result);
		return Clients.Client(Context.ConnectionId).SendAsync("RequestConvoyRoutesResponse", json);
	}

	public Task RequestRetreats(string gameId, string country) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}

		Player? player = handler.Players.FirstOrDefault(player => player.Countries[0].Name == country);
		if (player is null) return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid country: '{country}'");

		// Dictionary<string, List<string>> retreats = player.Units
		// .Where(unit => unit.Location is null && unit.PreviousLocation is not null)
		// .ToDictionary(
		// 	unit => unit.PreviousLocation!.Name,
		// 	unit => {
		// 		Territories previousLocation = Enum.Parse<Territories>(unit.PreviousLocation!.Name);
		// 		List<string> possibleRetreats = Board.TerritoryAdjacency(handler.Board, previousLocation)
		// 			.Where(territory => Board.CanUnitGoThere(player.Unit(previousLocation), Enum.Parse<Territories>(territory.Name)))
		// 			.Select(territory => territory.Name)
		// 			.ToList();

		// 		return possibleRetreats.Any() ? possibleRetreats : new List<string>();
		// 	});
		Dictionary<string, List<string>> retreats = new Dictionary<string, List<string>>();

		foreach (Unit unit in player.Units) {
			if (unit.Location is null && unit.PreviousLocation is not null) {
				string previousLocationName = unit.PreviousLocation.Name;
				Territories previousLocation = (Territories)Enum.Parse(typeof(Territories), previousLocationName);

				Debug.WriteLine($"Retired unit: {previousLocationName}");

				List<string> possibleRetreats = new List<string>();

				foreach (Territory territory in Board.TerritoryAdjacency(handler.Board, previousLocation)) {
					if (Board.CanUnitGoThere(unit, (Territories)Enum.Parse(typeof(Territories), territory.Name)) && territory.OccupyingUnit is null) {
						possibleRetreats.Add(territory.Name);
					}
				}

				if (!retreats.ContainsKey(previousLocationName)) {
					retreats[previousLocationName] = possibleRetreats.Any() ? possibleRetreats : new List<string>();
				}

				possibleRetreats.ForEach(t => Debug.WriteLine($"\t{t}"));
			}
		}

		return Clients.Client(Context.ConnectionId).SendAsync("RequestRetreatsResponse", JsonConvert.SerializeObject(retreats));
	}

	public Task Meow() {
		return Task.CompletedTask;
	}

	private static Dictionary<Player, Dictionary<Territories, List<string>>> GetConvoyMovements(GameHandler handler) {
		Dictionary<Player, Dictionary<Territories, List<string>>> convoyMovements = new();

		handler.Players.ForEach(player => player.Units
		   .Where(unit => unit.Location is not null) // will be useless after I add the retreat phase
		   .Where(unit => Board.CoastalTerritories.Contains(Enum.Parse<Territories>(unit.Location!)))
		   .Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
		   .ToList()
		   .ForEach(t => {
			   convoyMovements.TryAdd(player, new());

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

				   if (!convoyMovements[player].TryGetValue(t, out List<string>? movements)) {
					   movements = new();
					   convoyMovements[player].Add(t, movements);
				   }

				   movements.AddRange(landAdjacencies.Select(adj => adj.ToString()));
				   waterAdjacencies.ToList().ForEach(territories.Push);
			   }
		   }));

		convoyMovements.Keys.ToList().ForEach(player =>
			convoyMovements[player]
				.Keys
				.ToList()
				.ForEach(key =>
					convoyMovements[player][key] = convoyMovements[player][key]
						.Distinct()
						.ToList()));

		return convoyMovements;
	}

	private static Dictionary<Player, Dictionary<Territories, List<string>>> GetConvoyMovementsThroughTerritory(GameHandler handler, Territories targetTerritory) {
		Dictionary<Player, Dictionary<Territories, List<string>>> convoyMovements = new();

		handler.Players.ForEach(player => player.Units
		   .Where(unit => unit.Location is not null) // will be useless after I add the retreat phase
		   .Where(unit => Board.CoastalTerritories.Contains(Enum.Parse<Territories>(unit.Location!)))
		   .Select(unit => Enum.Parse<Territories>(unit.Location!.Name))
		   .ToList()
		   .ForEach(t => {
			   convoyMovements.TryAdd(player, new());

			   Stack<Territories> territories = new();
			   territories.Push(t);
			   List<Territories> waterVisited = new();

			   while (territories.Any()) {
				   Territories currentTerritory = territories.Pop();

				   if (waterVisited.Contains(currentTerritory)) continue;
				   waterVisited.Add(currentTerritory);

				   Debug.WriteLine("Looking at " + currentTerritory);
				   IEnumerable<Territories> landAdjacencies = Board.TerritoryAdjacency(handler.Board, currentTerritory)
					   .Where(terr => !Board.WaterTerritories.Contains(Enum.Parse<Territories>(terr)))
					   .Select(terr => Enum.Parse<Territories>(terr.Name));
				   IEnumerable<Territories> waterAdjacencies = Board.TerritoryAdjacency(handler.Board, currentTerritory)
					   .Where(terr => terr.OccupyingUnit is not null && Board.WaterTerritories.Contains(Enum.Parse<Territories>(terr)))
					   .Select(terr => Enum.Parse<Territories>(terr.Name));

				   if (currentTerritory == targetTerritory) {
					   if (!convoyMovements[player].TryGetValue(t, out List<string>? movements)) {
						   movements = new();
						   convoyMovements[player].Add(t, movements);
					   }
					   movements.AddRange(landAdjacencies.Select(adj => adj.ToString()));
				   }
				   waterAdjacencies.ToList().ForEach(territories.Push);
			   }
		   }));

		convoyMovements.Keys.ToList().ForEach(player =>
			convoyMovements[player]
				.Keys
				.ToList()
				.ForEach(key =>
					convoyMovements[player][key] = convoyMovements[player][key]
						.Distinct()
						.ToList()));

		return convoyMovements;
	}

}

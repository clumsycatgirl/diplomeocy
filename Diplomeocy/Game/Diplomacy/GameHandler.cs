using System.Collections.Immutable;

namespace Diplomacy;

using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;

using Diplomacy.Orders;

using Utils;

using ECountries = Diplomacy.Countries;

public class GameHandler {
	public List<Player> Players { get; set; } = new();
	public Board Board { get; set; } = new();
	public GameTurn GameTurn { get; set; } = new();
	public readonly Dictionary<Player, bool> IsPlayerReady = new();

	public GameHandler StartGame() {
		Board = new();

		Players = new() {
			new Player {
				Name = "Meowmeow",
				Countries = new() {
					new Country {
						Name = "England",
						Territories = new() {
							Board.Territory(Territories.London),
							Board.Territory(Territories.Liverpool),
							Board.Territory(Territories.Edinburgh),
							Board.Territory(Territories.Wales),
							Board.Territory(Territories.Yorkshire),
							Board.Territory(Territories.Clyde),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.London),
					},
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Liverpool),
					},
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Edinburgh),
					},
				}
			},
			new Player {
				Name = "Willyx",
				Countries = new() {
					new Country {
						Name = "Germany",
						Territories = new() {
							Board.Territory(Territories.Berlin),
							Board.Territory(Territories.Munich),
							Board.Territory(Territories.Ruhr),
							Board.Territory(Territories.Kiel),
							Board.Territory(Territories.Silesia),
							Board.Territory(Territories.Prussia),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Berlin),
					},
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Munich),
					},
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Kiel),
					},
				}
			},
			new Player {
				Name = "Red",
				Countries = new() {
					new Country {
						Name = "Austria",
						Territories = new() {
							Board.Territory(Territories.Vienna),
							Board.Territory(Territories.Budapest),
							Board.Territory(Territories.Trieste),
							Board.Territory(Territories.Tyrolia),
							Board.Territory(Territories.Bohemia),
							Board.Territory(Territories.Galicia),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Vienna),
					},
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Budapest),
					},
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Trieste),
					},
				}
			},
			new Player {
				Name = "BrofessorAdamo",
				Countries = new() {
					new Country {
						Name = "Turkey",
						Territories = new() {
							Board.Territory(Territories.Ankara),
							Board.Territory(Territories.Constantinople),
							Board.Territory(Territories.Smyrna),
							Board.Territory(Territories.Armenia),
							Board.Territory(Territories.Syria),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Ankara),
					},
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Constantinople),
					},
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Smyrna),
					},
				}
			},
			new Player {
				Name = "Extra273",
				Countries = new() {
					new Country {
						Name = "France",
						Territories = new() {
							Board.Territory(Territories.Paris),
							Board.Territory(Territories.Marseilles),
							Board.Territory(Territories.Brest),
							Board.Territory(Territories.Picardy),
							Board.Territory(Territories.Burgundy),
							Board.Territory(Territories.Gascony),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Paris),
					},
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Marseilles),
					},
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Brest),
					},
				}
			},
			new Player {
				Name = "FakeJoakimBroden",
				Countries = new() {
					new Country {
						Name = "Italy",
						Territories = new() {
							Board.Territory(Territories.Rome),
							Board.Territory(Territories.Naples),
							Board.Territory(Territories.Venice),
							Board.Territory(Territories.Piedmont),
							Board.Territory(Territories.Tuscany),
							Board.Territory(Territories.Apuleia),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Rome),
					},
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Naples),
					},
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Venice),
					},
				}
			},
			new Player {
				Name = "Hatsune Miku",
				Countries = new() {
					new Country {
						Name = "Russia",
						Territories = new() {
							Board.Territory(Territories.Moscow),
							Board.Territory(Territories.SaintPetersburg),
							Board.Territory(Territories.Warsaw),
							Board.Territory(Territories.Sevastopol),
							Board.Territory(Territories.Ukraine),
							Board.Territory(Territories.Livonia),
							Board.Territory(Territories.Finland),
						}
					},
				},
				Units = new() {
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Moscow),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.SaintPetersburg),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Warsaw),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Sevastopol),
					},
				}
			},
		};

		Players[0].Unit(Territories.London).Location!.IsSupplyPoint = true;
		Players[0].Unit(Territories.London).Location!.OccupyingUnit = Players[0].Unit(Territories.London);
		Players[0].Unit(Territories.Liverpool).Location!.IsSupplyPoint = true;
		Players[0].Unit(Territories.Liverpool).Location!.OccupyingUnit = Players[0].Unit(Territories.Liverpool);
		Players[0].Unit(Territories.Edinburgh).Location!.IsSupplyPoint = true;
		Players[0].Unit(Territories.Edinburgh).Location!.OccupyingUnit = Players[0].Unit(Territories.Edinburgh);

		Players[1].Unit(Territories.Berlin).Location!.IsSupplyPoint = true;
		Players[1].Unit(Territories.Berlin).Location!.OccupyingUnit = Players[1].Unit(Territories.Berlin);
		Players[1].Unit(Territories.Munich).Location!.IsSupplyPoint = true;
		Players[1].Unit(Territories.Munich).Location!.OccupyingUnit = Players[1].Unit(Territories.Munich);
		Players[1].Unit(Territories.Kiel).Location!.IsSupplyPoint = true;
		Players[1].Unit(Territories.Kiel).Location!.OccupyingUnit = Players[1].Unit(Territories.Kiel);

		Players[2].Unit(Territories.Vienna).Location!.IsSupplyPoint = true;
		Players[2].Unit(Territories.Vienna).Location!.OccupyingUnit = Players[2].Unit(Territories.Vienna);
		Players[2].Unit(Territories.Budapest).Location!.IsSupplyPoint = true;
		Players[2].Unit(Territories.Budapest).Location!.OccupyingUnit = Players[2].Unit(Territories.Budapest);
		Players[2].Unit(Territories.Trieste).Location!.IsSupplyPoint = true;
		Players[2].Unit(Territories.Trieste).Location!.OccupyingUnit = Players[2].Unit(Territories.Trieste);

		Players[3].Unit(Territories.Ankara).Location!.IsSupplyPoint = true;
		Players[3].Unit(Territories.Ankara).Location!.OccupyingUnit = Players[3].Unit(Territories.Ankara);
		Players[3].Unit(Territories.Constantinople).Location!.IsSupplyPoint = true;
		Players[3].Unit(Territories.Constantinople).Location!.OccupyingUnit = Players[3].Unit(Territories.Constantinople);
		Players[3].Unit(Territories.Smyrna).Location!.IsSupplyPoint = true;
		Players[3].Unit(Territories.Smyrna).Location!.OccupyingUnit = Players[3].Unit(Territories.Smyrna);

		Players[4].Unit(Territories.Paris).Location!.IsSupplyPoint = true;
		Players[4].Unit(Territories.Paris).Location!.OccupyingUnit = Players[4].Unit(Territories.Paris);
		Players[4].Unit(Territories.Marseilles).Location!.IsSupplyPoint = true;
		Players[4].Unit(Territories.Marseilles).Location!.OccupyingUnit = Players[4].Unit(Territories.Marseilles);
		Players[4].Unit(Territories.Brest).Location!.IsSupplyPoint = true;
		Players[4].Unit(Territories.Brest).Location!.OccupyingUnit = Players[4].Unit(Territories.Brest);

		Players[5].Unit(Territories.Venice).Location!.IsSupplyPoint = true;
		Players[5].Unit(Territories.Venice).Location!.OccupyingUnit = Players[5].Unit(Territories.Venice);
		Players[5].Unit(Territories.Rome).Location!.IsSupplyPoint = true;
		Players[5].Unit(Territories.Rome).Location!.OccupyingUnit = Players[5].Unit(Territories.Rome);
		Players[5].Unit(Territories.Naples).Location!.IsSupplyPoint = true;
		Players[5].Unit(Territories.Naples).Location!.OccupyingUnit = Players[5].Unit(Territories.Naples);

		Players[6].Unit(Territories.Warsaw).Location!.IsSupplyPoint = true;
		Players[6].Unit(Territories.Warsaw).Location!.OccupyingUnit = Players[6].Unit(Territories.Warsaw);
		Players[6].Unit(Territories.Moscow).Location!.IsSupplyPoint = true;
		Players[6].Unit(Territories.Moscow).Location!.OccupyingUnit = Players[6].Unit(Territories.Moscow);
		Players[6].Unit(Territories.Sevastopol).Location!.IsSupplyPoint = true;
		Players[6].Unit(Territories.Sevastopol).Location!.OccupyingUnit = Players[6].Unit(Territories.Sevastopol);
		Players[6].Unit(Territories.SaintPetersburg).Location!.IsSupplyPoint = true;
		Players[6].Unit(Territories.SaintPetersburg).Location!.OccupyingUnit = Players[6].Unit(Territories.SaintPetersburg);

		Players.Clear();

		GameTurn = new GameTurn {
			Phase = GamePhase.Diplomacy,
			Year = 1901,
			Season = Season.Spring,
		};

		return this;
	}

	public void AdvanceTurn() {
		switch (GameTurn.Phase) {
			case GamePhase.Diplomacy:
				GameTurn.Phase = GamePhase.OrderResolution;
				AdvanceTurn();
				break;
			case GamePhase.OrderResolution:
				ResolveOrderResolutionPhase();
				GameTurn.Phase = GamePhase.Retreat;
				break;
			case GamePhase.Retreat:
				GameTurn.Phase = GamePhase.Build;
				break;
			case GamePhase.Build:
				GameTurn.Phase = GamePhase.AdvanceTurn;
				break;
			case GamePhase.AdvanceTurn:
				GameTurn.Season = GameTurn.Season switch {
					Season.Spring => Season.Winter,
					Season.Winter => Season.Spring,
					_ => throw new InvalidOperationException(),
				};

				if (GameTurn.Season == Season.Spring)
					GameTurn.Year++;

				GameTurn.Phase = GamePhase.Diplomacy;
				break;
		}
	}

	public void ResolveTurns() {
		switch (GameTurn.Phase) {
			case GamePhase.Diplomacy:
				ResolveDiplomacyPhase();
				break;
			case GamePhase.OrderResolution:
				ResolveOrderResolutionPhase();
				break;
		}
	}

	public void ResolveDiplomacyPhase() {
	}

	public void ResolveOrderResolutionPhase() {
		/*
		1.  all units have the same strength
		2.  there can only be one unit in a province at a time
		3.  equal strength units trying to occupy the same province will cause all those units to remain in their original provinces
		4.  a standoff does not dislodge a unit already in the province where the standoff took place
		5.  one unit not moving can stop a series of other units from moving
		6.  units cannot trade places without the use of a convoy
		7.  three or more units can rotate provinces during a turn provided none directly trade places
		8. a unit not ordered to move can be supported by a support order that only mentions its province
		9. a unit ordered to move can only be supported by a support order that matches the move the unit is trying to make
		10. a dislodged unit even with support has no effect on the province that dislodged it
		11. a country cannot dislodge or support the dislodgment of one of its own units even if that dislodgmenet is unexpected
		12. a country cannot dislodge or support the dislodgment of one of its own units even if that dislodgmenet is unexpected
		13. support is cut if the unit giving support is attacked from any province exc ept the one where support is being given
		14. support is cut if the supporting unit is dislodged
		15. a unit being dislodged by one province can still cut support in another
		16. an attack by a country on one of its own units does not cut support
		17. a dislodgement of a fleet necessary to a convoy causes that convoy to fail
		18. a convoy that causes the convoyed army to standoff at its destination results in that army remaining in its original province
		19. two units can exchange places if either or both are convoyed (this is the exception to rule 6)
		20. an army convoyed using alternate convoy orders reaches its destination as long as at least one convoy route remains open
		21. a convoyed army does not cut the support of a unit supporting an attack against one of the fleets necessary for the army to convoy (this supersedes rule 13)
		22. an army with at least one successful convoy route will cut the support given by a unit in the destination province that is supporting an attack on a fleet in an alternate route in that convoy (this supersedes rule 21)
		*/

		/*
		 * - execute all support orders
		 * - find dependences for all orders
		 * - reserve resolve orders by least to most dependences
		 *	- start with the ones that have no dependences
		 *	- then move out to ones that depend on those
		 *	- repeat until all orders are resolved
		 *	  - if 2 orders depends on each other recursively they both fail
		 *	    unless they're convoyed
		 */

		List<Order> orders = Players
			.SelectMany(player => player.Orders)
			.ToList();

		Dictionary<Unit, Territory> destinations = new();

		// handle support orderse
		// cut supporst will be handled later with some handy dandy graphs (<- trying not to cry)
		orders
			.AsParallel()
			.OfType<SupportOrder>()
			.Where(supportOrder => orders.Contains(supportOrder!.SupportedOrder))
			.ForAll(supportOrder => supportOrder.Resolve());

		if (orders.AsParallel().Any(o => o.Strength != 1)) {
			Log.WriteLine(Log.LogLevel.Info, "--support orders--");
			orders
				.Where(order => order.Strength != 1)
				.ToImmutableList()
				.ForEach(order => Log.WriteLine($"support: {order}"));
		}

		// find dependency graph
		/*
		 * - get an order
		 * - find order it depends on aka
		 *	- orders that interact in any way with the same target territory
		 *	- orders that interact with order unit's current territory
		 */
		Dictionary<Order, List<Order>> dependencyGraph = new();
		orders
			.AsParallel()
			//.Where(order => order is not SupportOrder)
			.ForAll(order => {
				List<Order> dependencies = orders
					.AsParallel()
					.Where(o => o != order
						&& (o.Target == order.Target
						|| o.Unit.Location == order.Unit.Location
						|| o.Unit.Location == order.Target
						|| o.Target == order.Unit.Location
						) || (order is ConvoyOrder co && co.ConvoyedOrder == o))
					.ToList();

				lock (dependencyGraph) {
					if (dependencies.Count != 0)
						dependencyGraph.Add(order, dependencies);
				}
			});

		Log.WriteLine(Log.LogLevel.Info, "--dependency graph--");
		dependencyGraph
			.Where(kvp => kvp.Value.Any())
			.ToImmutableList()
			.ForEach(kvp => Log.WriteLine($"{kvp.Key}: \n\t{String.Join("\n\t", kvp.Value)}"));

		// hold orders that didn't interact with anything will be set to success
		// we do this to avoid having to check hold orders in the main loop
		// when they do not interact with any other order
		orders
			.AsParallel()
			.OfType<HoldOrder>()
			.ForAll(order => order.Status = OrderStatus.Succeeded);
		orders
			.AsParallel()
			.OfType<ConvoyOrder>()
			.ForAll(order => order.Status = OrderStatus.Succeeded);

		List<Order>? previousOrders = null;
		int iterationsWithoutOrdersUpdates = 0;
		while (orders.Any(order => !order.Resolved)) {
			for (int i = 0; i < orders.Count; i++) {
				Order order = orders[i];
				List<Order> dependencies = dependencyGraph.GetValueOrDefault(order, new());

				if (order.Resolved) continue;
				Log.WriteLine($"\nlooking at {order} with \n\t{String.Join("\n\t", dependencyGraph.GetValueOrDefault(order, new()))}");

				// there should be only one of this *at all times*
				// a unit cannot move to two different places
				Order? forwardDependency = dependencies
					.AsParallel()
					.FirstOrDefault(deps => deps.Unit.Location == order.Target);

				// save starting deps cause we're gonna change them later on
				// and this is the input we receive so we have to meowmoise this input
				// not the one after the execution
				List<Order> meowmoiseDependencies = order.FullDependencyList(dependencyGraph);
				string key = Order.MeowmoisationKey(meowmoiseDependencies);

				// do the stuff
				order.Execute(dependencyGraph, forwardDependency);

				// make sure to save it so that we won't have to recalculate it
				order.MeowmoiseResult(key, order.Status);
			}

			if (previousOrders is not null && Enumerable.SequenceEqual(orders, previousOrders)) {
				iterationsWithoutOrdersUpdates++;
			} else {
				iterationsWithoutOrdersUpdates = 0;
			}

			// if we're cycling through the same orders we're in a deadlock
			// we'll just randomly pick one to succeed
			// it's not the best solution but it's the best we can do
			// it'll get handled during the next iteration
			if (previousOrders is not null && Enumerable.SequenceEqual(orders, previousOrders) && orders.Any(order => !order.Resolved) && iterationsWithoutOrdersUpdates >= 10) {
				orders[new Random(Guid.NewGuid().GetHashCode()).Next(orders.Count)].Status = OrderStatus.Succeeded;
			}

			previousOrders = orders.ToList();
		}

		Log.WriteLine(Log.LogLevel.Info, "--orders review--");
		orders
			.OfType<SupportOrder>()
			.ToImmutableList()
			.ForEach(supportOrder => Log.WriteLine(supportOrder));
		dependencyGraph
			.Where(kvp => kvp.Value.Any())
			.ToImmutableList()
			.ForEach(kvp => Log.WriteLine($"{kvp.Key}: \n\t{String.Join("\n\t", kvp.Value)}"));

		Players
			.SelectMany(player => player.Units)
			.ToList()
			.ForEach(unit => unit.PreviousLocation = unit.Location);

		orders
			.AsParallel()
			.Where(order => order.Status != OrderStatus.Succeeded)
			.ForAll(moveOrder => moveOrder.ResolveFailed());

		orders
			.AsParallel()
			.Where(order => order.Status == OrderStatus.Succeeded && (order is MoveOrder || order is HoldOrder))
			.ForAll(moveOrder => moveOrder.Resolve());

		Parallel.ForEach(Players, player => player.Orders.Clear());

		Log.WriteLine("\n");
	}

	public (Country country, List<Unit> units) CreatePlayerData(Countries country) {
		if (country == ECountries.England) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "England",
				Territories = new() {
					Board.Territory(Territories.London),
					Board.Territory(Territories.Liverpool),
					Board.Territory(Territories.Edinburgh),
					Board.Territory(Territories.Wales),
					Board.Territory(Territories.Yorkshire),
					Board.Territory(Territories.Clyde),
				}
			}, new() {
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.London),
					},
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Liverpool),
					},
					new Unit {
						Country = ECountries.England,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Edinburgh),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.London.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.London.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.London.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Liverpool.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Liverpool.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Liverpool.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Edinburgh.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Edinburgh.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Edinburgh.ToString());

			return data;
		}

		if (country == ECountries.Germany) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "Germany",
				Territories = new() {
					Board.Territory(Territories.Berlin),
					Board.Territory(Territories.Munich),
					Board.Territory(Territories.Ruhr),
					Board.Territory(Territories.Kiel),
					Board.Territory(Territories.Silesia),
					Board.Territory(Territories.Prussia),
				}
			}, new() {
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Berlin),
					},
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Munich),
					},
					new Unit {
						Country = ECountries.Germany,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Kiel),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Berlin.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Berlin.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Berlin.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Munich.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Munich.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Munich.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Kiel.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Kiel.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Kiel.ToString());

			return data;
		}

		if (country == ECountries.Austria) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "Austria",
				Territories = new() {
					Board.Territory(Territories.Vienna),
					Board.Territory(Territories.Budapest),
					Board.Territory(Territories.Trieste),
					Board.Territory(Territories.Tyrolia),
					Board.Territory(Territories.Bohemia),
					Board.Territory(Territories.Galicia),
				}
			}, new() {
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Vienna),
					},
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Budapest),
					},
					new Unit {
						Country = ECountries.Austria,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Trieste),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Vienna.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Vienna.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Vienna.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Budapest.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Budapest.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Budapest.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Trieste.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Trieste.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Trieste.ToString());

			return data;
		}

		if (country == ECountries.Turkey) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "Turkey",
				Territories = new() {
					Board.Territory(Territories.Ankara),
					Board.Territory(Territories.Constantinople),
					Board.Territory(Territories.Smyrna),
					Board.Territory(Territories.Armenia),
					Board.Territory(Territories.Syria),
				}
			}, new() {
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Ankara),
					},
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Constantinople),
					},
					new Unit {
						Country = ECountries.Turkey,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Smyrna),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Ankara.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Ankara.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Ankara.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Constantinople.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Constantinople.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Constantinople.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Smyrna.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Smyrna.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Smyrna.ToString());

			return data;
		}

		if (country == ECountries.France) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "France",
				Territories = new() {
					Board.Territory(Territories.Paris),
					Board.Territory(Territories.Marseilles),
					Board.Territory(Territories.Brest),
					Board.Territory(Territories.Picardy),
					Board.Territory(Territories.Burgundy),
					Board.Territory(Territories.Gascony),
				}
			}, new() {
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Paris),
					},
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Marseilles),
					},
					new Unit {
						Country = ECountries.France,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Brest),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Paris.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Paris.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Paris.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Marseilles.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Marseilles.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Marseilles.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Brest.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Brest.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Brest.ToString());

			return data;
		}

		if (country == ECountries.Italy) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "Italy",
				Territories = new() {
					Board.Territory(Territories.Rome),
					Board.Territory(Territories.Naples),
					Board.Territory(Territories.Venice),
					Board.Territory(Territories.Piedmont),
					Board.Territory(Territories.Tuscany),
					Board.Territory(Territories.Apuleia),
				}
			}, new() {
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Rome),
					},
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Naples),
					},
					new Unit {
						Country = ECountries.Italy,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Venice),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Rome.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Rome.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Rome.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Naples.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Naples.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Naples.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Venice.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Venice.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Venice.ToString());

			return data;
		}

		if (country == ECountries.Russia) {
			(Country country, List<Unit> units) data = (new Country {
				Name = "Russia",
				Territories = new() {
					Board.Territory(Territories.Moscow),
					Board.Territory(Territories.SaintPetersburg),
					Board.Territory(Territories.Warsaw),
					Board.Territory(Territories.Sevastopol),
					Board.Territory(Territories.Ukraine),
					Board.Territory(Territories.Livonia),
					Board.Territory(Territories.Finland),
				}
			}, new() {
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Moscow),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.SaintPetersburg),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Warsaw),
					},
					new Unit {
						Country = ECountries.Russia,
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Sevastopol),
					},
				});

			data.units.First(unit => unit.Location!.Name == Territories.Moscow.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Moscow.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Moscow.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.SaintPetersburg.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.SaintPetersburg.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.SaintPetersburg.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Warsaw.ToString()).Location!.IsSupplyPoint = true;
			data.units.First(unit => unit.Location!.Name == Territories.Warsaw.ToString()).Location!.OccupyingUnit = data.units.First(unit => unit.Location!.Name == Territories.Warsaw.ToString());
			data.units.First(unit => unit.Location!.Name == Territories.Sevastopol.ToString()).Location!.IsSupplyPoint = true;

			return data;
		}

		throw new UnreachableException();
	}
}

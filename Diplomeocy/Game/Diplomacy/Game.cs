using System.Diagnostics;

namespace Diplomacy;

public class Game {
	public List<Player> Players { get; private set; } = new();
	public Board Board { get; private set; } = new();
	public GameTurn GameTurn { get; private set; } = new();

	public void StartGame() {
		Board = new();

		Players = new() {
			new Player {
				Name = "Meowmeow",
				Countries = new() {
					new Country {
						Name = "England",
						HomeTerritories = new() {
							Board.Territory(Territories.London),
							Board.Territory(Territories.Liverpool),
							Board.Territory(Territories.Edinburgh),
							}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.London),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Liverpool),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Edinburgh),
					},
				}
			},
			new Player {
				Name = "Willyx",
				Countries = new() {
					new Country {
						Name = "Germany",
						HomeTerritories = new() {
							Board.Territory(Territories.Berlin),
							Board.Territory(Territories.Munich),
							Board.Territory(Territories.Kiel),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Berlin),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Munich),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Kiel),
					},
				}
			},
			new Player {
				Name = "Red",
				Countries = new() {
					new Country {
						Name = "Austria",
						HomeTerritories = new() {
							Board.Territory(Territories.Vienna),
							Board.Territory(Territories.Budapest),
							Board.Territory(Territories.Trieste),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Vienna),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Budapest),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Trieste),
					},
				}
			},
			new Player {
				Name = "BrofessorAdamo",
				Countries = new() {
					new Country {
						Name = "Turkey",
						HomeTerritories = new() {
							Board.Territory(Territories.Ankara),
							Board.Territory(Territories.Constantinople),
							Board.Territory(Territories.Smyrna),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Ankara),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Constantinople),
					},
					new Unit {
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
						HomeTerritories = new() {
							Board.Territory(Territories.Paris),
							Board.Territory(Territories.Marseilles),
							Board.Territory(Territories.Brest),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Paris),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Marseilles),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Brest),
					},
				}
			},
			new Player {
				Name = "FakeJoakimBroden",
				Countries = new() {
					new Country {
						Name = "Italy",
						HomeTerritories = new() {
							Board.Territory(Territories.Rome),
							Board.Territory(Territories.Naples),
							Board.Territory(Territories.Venice),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Rome),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Naples),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Venice),
					},
				}
			},
			new Player {
				Name = "Me",
				Countries = new() {
					new Country {
						Name = "Russia",
						HomeTerritories = new() {
							Board.Territory(Territories.Moscow),
							Board.Territory(Territories.SaintPetersburg),
							Board.Territory(Territories.Warsaw),
							Board.Territory(Territories.Sevastopol),
						}
					},
				},
				Units = new() {
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Moscow),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.SaintPetersburg),
					},
					new Unit {
						Type = UnitType.Army,
						Location = Board.Territory(Territories.Warsaw),
					},
					new Unit {
						Type = UnitType.Fleet,
						Location = Board.Territory(Territories.Sevastopol),
					},
				}
			},
		};

		GameTurn = new GameTurn {
			Phase = GamePhase.Diplomacy,
			Year = 1901,
			Season = Season.Spring,
		};
	}

	public void AdvanceTurn() {
		switch (GameTurn.Phase) {
			case GamePhase.Diplomacy:
				GameTurn.Phase = GamePhase.OrderResolution;
				break;
			case GamePhase.OrderResolution:
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

		Debug.WriteLine("\n");

		Dictionary<Unit, Territory> destinations = new();
		Dictionary<Unit, int> supportCounts = new();

		Players.ForEach(player =>
			player.Orders.ForEach(order => {
				Debug.WriteLine(order);
				if (order is MoveOrder moveOrder) {
					destinations[moveOrder.Unit] = moveOrder.Target;
				} else if (order is SupportOrder supportOrder && player.Orders.Contains(supportOrder.SupportedOrder)) {
					Debug.WriteLine("adding support for " + supportOrder.Unit);
					supportCounts[supportOrder.SupportedOrder.Unit] = supportCounts.GetValueOrDefault(supportOrder.SupportedOrder.Unit, 0) + 1;
				}
			}));

		Debug.WriteLine("\n--Calculated supports--");
		supportCounts.ToList().ForEach(pair => Debug.WriteLine($"support: {pair.Key} -> {pair.Value}"));

		// rember to fix double checks
		Debug.WriteLine("");
		destinations.ToList().ForEach(pair => {
			Unit unit = pair.Key;
			Territory territory = pair.Value;

			if (destinations.Count(kvp => kvp.Value == territory) == 1) {
				unit.Location = territory;
				territory.OccupyingUnit = unit;
				return;
			}

			Debug.WriteLine($"contesting {territory}");
			List<KeyValuePair<Unit, Territory>> attackingUnits = destinations
				.Where(pair => pair.Value == territory)
				.ToList();

			attackingUnits.ToList().ForEach(kvp => Debug.WriteLine($"{kvp.Key}: {kvp.Value} with support {supportCounts.GetValueOrDefault(kvp.Key, 0)}"));

			KeyValuePair<Unit, int> maxSupportUnit = attackingUnits
				.Select(unit => new KeyValuePair<Unit, int>(unit.Key, supportCounts.GetValueOrDefault(unit.Key, 0)))
				.OrderByDescending(pair => pair.Value)
				.First();

			bool isTie = attackingUnits
				.Any(unit => supportCounts.GetValueOrDefault(unit.Key, 0) == maxSupportUnit.Value && unit.Key != maxSupportUnit.Key);

			if (!isTie && maxSupportUnit.Key == unit) {
				unit.Location = territory;
				territory.OccupyingUnit = unit;
			}
		});

		Parallel.ForEach(Players, player => player.Orders.Clear());
	}
}

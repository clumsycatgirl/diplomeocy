using System.Diagnostics;

using Diplomacy;

using Orders = System.Collections.Generic.List<Diplomacy.Order>;

Console.WriteLine("meow\n");

Game game = new();
game.StartGame();

Player germany = game.Players[1];
Player russia = game.Players[game.Players.Count - 1];
List<Player> players = new() { germany, russia };
Order? order;

// log debug data
Action debug = () => {
	players.ForEach(player => {
		Console.WriteLine($"--{player.Countries[0].Name}: Units--");
		player.Units.ForEach(u => Console.WriteLine(u));
		Console.WriteLine($"--{player.Countries[0].Name}: Orders--");
		player.Orders.ForEach(o => Console.WriteLine(o));
		Console.WriteLine();
	});
	Console.WriteLine();
};
// advance -> log
Action step = () => {
	Console.WriteLine($"----Turn {game.GameTurn.Year} {game.GameTurn.Season}----");
	Debug.WriteLine($"----Turn {game.GameTurn.Year} {game.GameTurn.Season}----");
	debug();
	game.ResolveOrderResolutionPhase();
	game.GameTurn.Phase = GamePhase.AdvanceTurn;
	game.AdvanceTurn();
	game.GameTurn.Phase = GamePhase.OrderResolution;
	debug();
};

step();

// test movement 1
#if false
germany.Orders.AddRange(new Orders  {
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = germany.Unit(Territories.Munich),
		Target = game.Board.Territory(Territories.Silesia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.Moscow),
		Target = game.Board.Territory(Territories.Livonia),
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.SaintPetersburg),
		Target = game.Board.Territory(Territories.GulfOfBothania),
	},
});

step();

Order order = new MoveOrder {
	Unit = germany.Unit(Territories.Berlin),
	Target = game.Board.Territory(Territories.Prussia),
};
germany.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = germany.Unit(Territories.Silesia),
		SupportedOrder = order,
	},
});
order = new MoveOrder {
	Unit = russia.Unit(Territories.Warsaw),
	Target = game.Board.Territory(Territories.Prussia),
};
russia.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = russia.Unit(Territories.Livonia),
		SupportedOrder = order,
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.GulfOfBothania),
		Target = game.Board.Territory(Territories.BalticSea),
	},
});

step();

order = new MoveOrder {
	Unit = germany.Unit(Territories.Berlin),
	Target = game.Board.Territory(Territories.Prussia),
};
germany.Orders.AddRange(new Orders {
	order,
	new SupportOrder{
		Unit = germany.Unit(Territories.Silesia),
		SupportedOrder = order,
	},
});
order = new MoveOrder {
	Unit = russia.Unit(Territories.Warsaw),
	Target = game.Board.Territory(Territories.Prussia),
};
russia.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = russia.Unit(Territories.Livonia),
		SupportedOrder = order,
	},
	new SupportOrder {
		Unit = russia.Unit(Territories.BalticSea),
		SupportedOrder = order,
	},
});
#endif

// test movement 2
// multiple blocked units will block each other
#if false
germany.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = germany.Unit(Territories.Munich),
		Target = game.Board.Territory(Territories.Berlin),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Prussia),
	},
});
#endif

// test movement 3
#if false
// cheat
germany.Unit(Territories.Munich).Move(game.Board.Territory(Territories.Silesia));
germany.Unit(Territories.Kiel).Move(game.Board.Territory(Territories.BalticSea));
russia.Unit(Territories.Moscow).Move(game.Board.Territory(Territories.Kiel));

germany.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Prussia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.Kiel),
		Target = game.Board.Territory(Territories.Berlin),
	}
});

step();

order = new MoveOrder {
	Unit = germany.Unit(Territories.Berlin),
	Target = game.Board.Territory(Territories.Prussia),
};
germany.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = germany.Unit(Territories.Silesia),
		SupportedOrder = order,
	},
	new SupportOrder {
		Unit = germany.Unit(Territories.BalticSea),
		SupportedOrder = order,
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.Kiel),
		Target = game.Board.Territory(Territories.Berlin),
	}
});
#endif

#if true
germany.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = germany.Unit(Territories.Munich),
		Target = game.Board.Territory(Territories.Silesia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.SaintPetersburg),
		Target = game.Board.Territory(Territories.Livonia),
	}
});

step();

order = new MoveOrder {
	Unit = germany.Unit(Territories.Berlin),
	Target = game.Board.Territory(Territories.Prussia),
};
germany.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = germany.Unit(Territories.Silesia),
		SupportedOrder = order,
	}
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Silesia),
	},
	new MoveOrder {
		Unit = russia.Unit(Territories.Livonia),
		Target = game.Board.Territory(Territories.Prussia),
	}
});

#endif

step();

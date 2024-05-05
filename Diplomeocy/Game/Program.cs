using Diplomacy;
using Diplomacy.Orders;
using Diplomacy.Utils;


using Game.Diplomacy.Orders;

using Orders = System.Collections.Generic.List<Diplomacy.Orders.Order>;

Log.WriteLine(Log.LogLevel.Info, "meow\n");


GameHandler game = new();
game.StartGame();
Player england = game.Players[0];
Player germany = game.Players[1];
Player austria = game.Players[2];
Player turkey = game.Players[3];
Player france = game.Players[4];
Player italy = game.Players[5];
Player russia = game.Players[6];
List<Player> players = new();
Order? order;

Action resetGame = () => {
	game = new();
	game.StartGame();
	england = game.Players[0];
	germany = game.Players[1];
	austria = game.Players[2];
	turkey = game.Players[3];
	france = game.Players[4];
	italy = game.Players[5];
	russia = game.Players[6];
	players = new() { germany, france, russia, italy, austria };
};
resetGame();

// log debug data
Action debug = () => {
	players.ForEach(player => {
		Log.WriteLine(Log.LogLevel.Info, $"--{player.Countries[0].Name}: Units--");
		player.Units.ForEach(u => Log.WriteLine(u));
		Log.WriteLine(Log.LogLevel.Info, $"--{player.Countries[0].Name}: Orders--");
		player.Orders.ForEach(o => Log.WriteLine(o));
		Log.WriteLine("");
	});
	Log.WriteLine("");
};
// advance -> log
Action step = () => {
	Log.WriteLine(Log.LogLevel.Warning, $"----Turn {game.GameTurn.Year} {game.GameTurn.Season}----");
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

#if false
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

// test hold 1
#if false
germany.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = germany.Unit(Territories.Munich),
		Target = game.Board.Territory(Territories.Silesia),
	},
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Prussia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.SaintPetersburg),
		Target = game.Board.Territory(Territories.Livonia),
	},
});

step();

germany.Orders.AddRange(new Orders {
	new HoldOrder {
		Unit = germany.Unit(Territories.Prussia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Prussia),
	},
});

// check for errors
// if any of these is wrong it will throw an exception
germany.Unit(Territories.Prussia);
germany.Unit(Territories.Silesia);
germany.Unit(Territories.Kiel);
russia.Unit(Territories.Moscow);
russia.Unit(Territories.Livonia);
russia.Unit(Territories.Warsaw);
russia.Unit(Territories.Sevastopol);

#endif

#region rules_diagrams

resetGame();
#region diagram_4
#if true
Log.WriteLine(Log.LogLevel.Error, "------[diagram_4]------");
germany.Orders.AddRange(new List<Order> {
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Silesia),
	},
});
russia.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = russia.Unit(Territories.Warsaw),
		Target = game.Board.Territory(Territories.Silesia),
	},
});
step();

germany.Unit(Territories.Berlin);
russia.Unit(Territories.Warsaw);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_4_done]----");
#endif
#endregion

resetGame();
#region diagram_5
#if true
Log.WriteLine(Log.LogLevel.Error, "------[diagram_5]------");

russia.Unit(Territories.Warsaw).Move(game.Board.Territory(Territories.Prussia));
germany.Orders.AddRange(new Orders {
	new MoveOrder {
		Unit = germany.Unit(Territories.Berlin),
		Target = game.Board.Territory(Territories.Prussia),
	},
	new MoveOrder {
		Unit = germany.Unit(Territories.Kiel),
		Target = game.Board.Territory(Territories.Berlin),
	}
});
russia.Orders.Add(new HoldOrder { Unit = russia.Unit(Territories.Prussia) });

step();

germany.Unit(Territories.Berlin);
germany.Unit(Territories.Kiel);
russia.Unit(Territories.Prussia);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_5_done]----");
#endif
#endregion

resetGame();
#region diagram_6
#if true

Log.WriteLine(Log.LogLevel.Error, "------[diagram_6]------");

russia.Unit(Territories.Warsaw).Move(game.Board.Territory(Territories.Prussia));
germany.Orders.Add(new MoveOrder { Unit = germany.Unit(Territories.Berlin), Target = game.Board.Territory(Territories.Prussia) });
russia.Orders.Add(new MoveOrder { Unit = russia.Unit(Territories.Prussia), Target = game.Board.Territory(Territories.Berlin) });

step();

germany.Unit(Territories.Berlin);
russia.Unit(Territories.Prussia);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_6_done]----");
#endif
#endregion

#region diagram_7
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_7]------");
Log.WriteLine("implement those damned convoys coward!! stop running!!");
Log.WriteLine(Log.LogLevel.Error, "----[diagram_7_done]----");
#endif
#endregion

#region diagram_8
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_8]------");

germany.Unit(Territories.Munich).Move(game.Board.Territory(Territories.Burgundy));
france.Unit(Territories.Brest).Move(game.Board.Territory(Territories.Gascony));

germany.Orders.AddRange(new Orders {
	new HoldOrder {
		Unit = germany.Unit(Territories.Burgundy),
	},
});
order = new MoveOrder { Unit = france.Unit(Territories.Marseilles), Target = game.Board.Territory(Territories.Burgundy) };
france.Orders.AddRange(new Orders {
	order,
	new SupportOrder {
		Unit = france.Unit(Territories.Gascony),
		SupportedOrder = order,
	}
});
step();

france.Unit(Territories.Burgundy);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_8_done]----");
#endif
#endregion

#region diagram_9
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_9]------");

germany.Unit(Territories.Berlin).Move(game.Board.Territory(Territories.BalticSea));
germany.Unit(Territories.Munich).Move(game.Board.Territory(Territories.Silesia));
russia.Unit(Territories.Warsaw).Move(game.Board.Territory(Territories.Prussia));

order = new MoveOrder { Unit = germany.Unit(Territories.Silesia), Target = game.Board.Territory(Territories.Prussia) };
germany.Orders.AddRange(new Orders {
	order, new SupportOrder {  SupportedOrder = order, Unit = germany.Unit(Territories.BalticSea) },
});
russia.Orders.Add(new HoldOrder { Unit = russia.Unit(Territories.Prussia) });
step();

germany.Unit(Territories.BalticSea);
germany.Unit(Territories.Prussia);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_9_done]----");
#endif
#endregion

#region diagram_10
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_10]------");

france.Unit(Territories.Brest).Move(game.Board.Territory(Territories.MidAtlanticOcean));
france.Unit(Territories.MidAtlanticOcean).Move(game.Board.Territory(Territories.WesternMediterranean));
france.Unit(Territories.Marseilles).Move(game.Board.Territory(Territories.GulfOfLyon));

order = new MoveOrder { Unit = france.Unit(Territories.GulfOfLyon), Target = game.Board.Territory(Territories.TyrrhenianSea) };
france.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = france.Unit(Territories.WesternMediterranean) },
});
order = new MoveOrder { Unit = italy.Unit(Territories.Naples), Target = game.Board.Territory(Territories.TyrrhenianSea), };
italy.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = italy.Unit(Territories.Rome) },
});
step();

italy.Unit(Territories.Rome);
italy.Unit(Territories.Naples);
france.Unit(Territories.WesternMediterranean);
france.Unit(Territories.GulfOfLyon);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_10_done]----");
#endif
#endregion

#region diagram_11
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_11]------");

italy.Unit(Territories.Naples).Move(game.Board.Territory(Territories.TyrrhenianSea));
france.Unit(Territories.Brest).Move(game.Board.Territory(Territories.MidAtlanticOcean));
france.Unit(Territories.MidAtlanticOcean).Move(game.Board.Territory(Territories.WesternMediterranean));
france.Unit(Territories.Marseilles).Move(game.Board.Territory(Territories.GulfOfLyon));



order = new MoveOrder { Unit = france.Unit(Territories.GulfOfLyon), Target = game.Board.Territory(Territories.TyrrhenianSea) };
france.Orders.AddRange(new Orders {
	order, new SupportOrder {
		Unit = france.Unit(Territories.WesternMediterranean),
		SupportedOrder = order,
	},
});
order = new HoldOrder { Unit = italy.Unit(Territories.TyrrhenianSea) };
italy.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = italy.Unit(Territories.Rome) },
});
step();

italy.Unit(Territories.Rome);
italy.Unit(Territories.TyrrhenianSea);
france.Unit(Territories.WesternMediterranean);
france.Unit(Territories.GulfOfLyon);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_11_done]----");
#endif
#endregion

#region diagram_12
#if true
resetGame();
Log.WriteLine(Log.LogLevel.Error, "------[diagram_12]------");

russia.Unit(Territories.Warsaw).Move(game.Board.Territory(Territories.Prussia));
russia.Unit(Territories.Moscow).Move(game.Board.Territory(Territories.Warsaw));
austria.Unit(Territories.Trieste).Move(game.Board.Territory(Territories.Tyrolia));
austria.Unit(Territories.Vienna).Move(game.Board.Territory(Territories.Bohemia));

order = new MoveOrder { Unit = austria.Unit(Territories.Bohemia), Target = game.Board.Territory(Territories.Munich) };
austria.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = austria.Unit(Territories.Tyrolia) },
});

order = new MoveOrder { Unit = germany.Unit(Territories.Munich), Target = game.Board.Territory(Territories.Silesia) };
germany.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = germany.Unit(Territories.Berlin) },
});

order = new MoveOrder { Unit = russia.Unit(Territories.Warsaw), Target = game.Board.Territory(Territories.Silesia) };
russia.Orders.AddRange(new Orders {
	order, new SupportOrder { SupportedOrder = order, Unit = russia.Unit(Territories.Prussia) },
});
step();

germany.Unit(Territories.Berlin);
austria.Unit(Territories.Munich);
austria.Unit(Territories.Tyrolia);
russia.Unit(Territories.Prussia);
russia.Unit(Territories.Warsaw);

Log.WriteLine(Log.LogLevel.Error, "----[diagram_12_done]----");
#endif
#endregion

#endregion

//step();

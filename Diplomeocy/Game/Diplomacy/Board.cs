namespace Diplomacy;

using System.Text.Encodings.Web;

using ETerritories = Diplomacy.Territories;

public class Board {
	public List<Territory> Territories { get; init; }

	public Territory Territory(string name) => Territories.First(t => t.Name.ToLower().Equals(name.ToLower()));
	public Territory Territory(ETerritories territory) => Territories.First(t => t.Name.ToLower().Equals(territory.ToString().ToLower()));

	public Board() {
		Territories = Enum.GetNames(typeof(ETerritories))
				  		.Select(territory =>
							new Territory { Name = territory, })
				  		.ToList();
		// Territories
		// 	.Where(territory => Enum.GetNames<ETerritories>().Contains(territory.Name) && TerritoryAdjacencyMap.Any(kvp => kvp.Key == ))
		// 	.ToList()
		// 	.ForEach(territory =>
		// 		territory.AdjacentTerritories = TerritoryAdjacency(this, (ETerritories)Enum.Parse(typeof(ETerritories), territory.Name)));

		Territories
			.Select(territory => (territory, territoryEnum: Enum.Parse<ETerritories>(territory.Name)))
			.Where(pair => TerritoryAdjacencyMap.Any(kvp => kvp.Key == pair.territoryEnum))
			.ToList()
			.ForEach(pair => pair.territory.AdjacentTerritories = TerritoryAdjacency(this, pair.territoryEnum));
	}

	public static readonly Dictionary<Territories, List<Territories>> TerritoryAdjacencyMap = new();
	public static List<Territory> TerritoryAdjacency(Board board, Territories territory) =>
		TerritoryAdjacencyMap[territory]
			.Select(territory => board.Territory(territory))
			.ToList();

	static Board() {
		Board.TerritoryAdjacencyMap[ETerritories.Trieste] = new() {
			ETerritories.Venice,
			ETerritories.Tyrolia,
			ETerritories.Vienna,
			ETerritories.Albania,
			ETerritories.AdriaticSea,
			ETerritories.Budapest,
			ETerritories.Serbia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.AdriaticSea] = new() {
			ETerritories.Trieste,
			ETerritories.Venice,
			ETerritories.Albania,
			ETerritories.IonianSea,
			ETerritories.Apuleia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.AegeanSea] = new() {
			ETerritories.Greece,
			ETerritories.Bulgaria,
			ETerritories.Constantinople,
			ETerritories.Smyrna,
			ETerritories.EasternMediterranean,
			ETerritories.IonianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Apuleia] = new() {
			ETerritories.AdriaticSea,
			ETerritories.Venice,
			ETerritories.Naples,
			ETerritories.IonianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Albania] = new() {
			ETerritories.Trieste,
			ETerritories.Serbia,
			ETerritories.Greece,
			ETerritories.IonianSea,
			ETerritories.AdriaticSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Ankara] = new() {
			ETerritories.Constantinople,
			ETerritories.Smyrna,
			ETerritories.Armenia,
			ETerritories.BlackSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Armenia] = new() {
			ETerritories.Ankara,
			ETerritories.Smyrna,
			ETerritories.Sevastopol,
			ETerritories.BlackSea,
			ETerritories.Syria,
		};
		Board.TerritoryAdjacencyMap[ETerritories.BalticSea] = new() {
			ETerritories.Denmark,
			ETerritories.Sweden,
			ETerritories.Livonia,
			ETerritories.Prussia,
			ETerritories.Kiel,
			ETerritories.Berlin,
			ETerritories.GulfOfBothania,
		};
		Board.TerritoryAdjacencyMap[ETerritories.BarentsSea] = new() {
			ETerritories.NorwegianSea,
			ETerritories.Norway,
			ETerritories.SaintPetersburg,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Belgium] = new() {
			ETerritories.Holland,
			ETerritories.Ruhr,
			ETerritories.Burgundy,
			ETerritories.Picardy,
			ETerritories.EnglishChannel,
			ETerritories.NorthSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Bohemia] = new() {
			ETerritories.Munich,
			ETerritories.Tyrolia,
			ETerritories.Silesia,
			ETerritories.Galicia,
			ETerritories.Vienna,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Berlin] = new() {
			ETerritories.Kiel,
			ETerritories.Prussia,
			ETerritories.Silesia,
			ETerritories.Munich,
			ETerritories.BalticSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.BlackSea] = new() {
			ETerritories.Bulgaria,
			ETerritories.Rumania,
			ETerritories.Sevastopol,
			ETerritories.Armenia,
			ETerritories.Ankara,
			ETerritories.Constantinople,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Brest] = new() {
			ETerritories.Paris,
			ETerritories.Picardy,
			ETerritories.MidAtlanticOcean,
			ETerritories.EnglishChannel,
			ETerritories.Gascony,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Budapest] = new() {
			ETerritories.Vienna,
			ETerritories.Trieste,
			ETerritories.Serbia,
			ETerritories.Rumania,
			ETerritories.Galicia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Bulgaria] = new() {
			ETerritories.Constantinople,
			ETerritories.Greece,
			ETerritories.Serbia,
			ETerritories.Rumania,
			ETerritories.BlackSea,
			ETerritories.AegeanSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Burgundy] = new() {
			ETerritories.Paris,
			ETerritories.Picardy,
			ETerritories.Belgium,
			ETerritories.Marseilles,
			ETerritories.Ruhr,
			ETerritories.Munich,
			ETerritories.Gascony,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Clyde] = new() {
			ETerritories.Edinburgh,
			ETerritories.NorthAtlanticOcean,
			ETerritories.NorwegianSea,
			ETerritories.Liverpool,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Constantinople] = new() {
			ETerritories.Bulgaria,
			ETerritories.Smyrna,
			ETerritories.Ankara,
			ETerritories.BlackSea,
			ETerritories.AegeanSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Denmark] = new() {
			ETerritories.Sweden,
			ETerritories.Skagerrak,
			ETerritories.NorthSea,
			ETerritories.BalticSea,
			ETerritories.Kiel,
			ETerritories.HelgolandBight,
		};
		Board.TerritoryAdjacencyMap[ETerritories.EasternMediterranean] = new() {
			ETerritories.AegeanSea,
			ETerritories.Smyrna,
			ETerritories.Syria,
			ETerritories.IonianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Edinburgh] = new() {
			ETerritories.Clyde,
			ETerritories.NorthSea,
			ETerritories.NorwegianSea,
			ETerritories.Yorkshire,
			ETerritories.Liverpool,
		};
		Board.TerritoryAdjacencyMap[ETerritories.EnglishChannel] = new() {
			ETerritories.London,
			ETerritories.Wales,
			ETerritories.IrishSea,
			ETerritories.MidAtlanticOcean,
			ETerritories.Brest,
			ETerritories.Picardy,
			ETerritories.Belgium,
			ETerritories.NorthSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Finland] = new() {
			ETerritories.Norway,
			ETerritories.SaintPetersburg,
			ETerritories.GulfOfBothania,
			ETerritories.Sweden,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Galicia] = new() {
			ETerritories.Warsaw,
			ETerritories.Ukraine,
			ETerritories.Rumania,
			ETerritories.Budapest,
			ETerritories.Vienna,
			ETerritories.Bohemia,
			ETerritories.Bohemia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Gascony] = new() {
			ETerritories.Brest,
			ETerritories.Paris,
			ETerritories.Burgundy,
			ETerritories.Marseilles,
			ETerritories.Spain,
			ETerritories.GulfOfLyon,
			ETerritories.MidAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Greece] = new() {
			ETerritories.Bulgaria,
			ETerritories.Serbia,
			ETerritories.Albania,
			ETerritories.IonianSea,
			ETerritories.AegeanSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.GulfOfLyon] = new() {
			ETerritories.Spain,
			ETerritories.Marseilles,
			ETerritories.Piedmont,
			ETerritories.TyrrhenianSea,
			ETerritories.WesternMediterranean,
			ETerritories.Tuscany,
		};
		Board.TerritoryAdjacencyMap[ETerritories.GulfOfBothania] = new() {
			ETerritories.Sweden,
			ETerritories.Finland,
			ETerritories.BalticSea,
			ETerritories.SaintPetersburg,
			ETerritories.Livonia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.HelgolandBight] = new() {
			ETerritories.Denmark,
			ETerritories.Kiel,
			ETerritories.Holland,
			ETerritories.NorthSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Holland] = new() {
			ETerritories.Kiel,
			ETerritories.Ruhr,
			ETerritories.Belgium,
			ETerritories.NorthSea,
			ETerritories.HelgolandBight,
		};
		Board.TerritoryAdjacencyMap[ETerritories.IonianSea] = new() {
			ETerritories.AdriaticSea,
			ETerritories.Apuleia,
			ETerritories.Naples,
			ETerritories.Tunis,
			ETerritories.TyrrhenianSea,
			ETerritories.EasternMediterranean,
			ETerritories.AegeanSea,
			ETerritories.Greece,
			ETerritories.Albania,
		};
		Board.TerritoryAdjacencyMap[ETerritories.IrishSea] = new() {
			ETerritories.Liverpool,
			ETerritories.Wales,
			ETerritories.EnglishChannel,
			ETerritories.MidAtlanticOcean,
			ETerritories.NorthAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Kiel] = new() {
			ETerritories.Denmark,
			ETerritories.Holland,
			ETerritories.Ruhr,
			ETerritories.Berlin,
			ETerritories.Munich,
			ETerritories.BalticSea,
			ETerritories.HelgolandBight,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Liverpool] = new() {
			ETerritories.Edinburgh,
			ETerritories.Clyde,
			ETerritories.NorthAtlanticOcean,
			ETerritories.IrishSea,
			ETerritories.Wales,
			ETerritories.Yorkshire,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Livonia] = new() {
			ETerritories.SaintPetersburg,
			ETerritories.Moscow,
			ETerritories.Warsaw,
			ETerritories.Prussia,
			ETerritories.BalticSea,
			ETerritories.GulfOfBothania,
		};
		Board.TerritoryAdjacencyMap[ETerritories.London] = new() {
			ETerritories.Wales,
			ETerritories.Yorkshire,
			ETerritories.NorthSea,
			ETerritories.EnglishChannel,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Marseilles] = new() {
			ETerritories.Spain,
			ETerritories.Gascony,
			ETerritories.Burgundy,
			ETerritories.Piedmont,
			ETerritories.GulfOfLyon,
		};
		Board.TerritoryAdjacencyMap[ETerritories.MidAtlanticOcean] = new() {
			ETerritories.IrishSea,
			ETerritories.EnglishChannel,
			ETerritories.Brest,
			ETerritories.Gascony,
			ETerritories.Spain,
			ETerritories.Portugal,
			ETerritories.NorthAtlanticOcean,
			ETerritories.WesternMediterranean,
			ETerritories.NorthAfrica,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Moscow] = new() {
			ETerritories.SaintPetersburg,
			ETerritories.Livonia,
			ETerritories.Ukraine,
			ETerritories.Sevastopol,
			ETerritories.Warsaw,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Munich] = new() {
			ETerritories.Berlin,
			ETerritories.Kiel,
			ETerritories.Ruhr,
			ETerritories.Burgundy,
			ETerritories.Tyrolia,
			ETerritories.Bohemia,
			ETerritories.Silesia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Naples] = new() {
			ETerritories.Rome,
			ETerritories.Apuleia,
			ETerritories.IonianSea,
			ETerritories.TyrrhenianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.NorthAfrica] = new() {
			ETerritories.MidAtlanticOcean,
			ETerritories.WesternMediterranean,
			ETerritories.Tunis,
		};
		Board.TerritoryAdjacencyMap[ETerritories.NorthAtlanticOcean] = new() {
			ETerritories.IrishSea,
			ETerritories.Liverpool,
			ETerritories.Clyde,
			ETerritories.NorwegianSea,
			ETerritories.MidAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.NorthSea] = new() {
			ETerritories.NorwegianSea,
			ETerritories.Edinburgh,
			ETerritories.Yorkshire,
			ETerritories.London,
			ETerritories.EnglishChannel,
			ETerritories.Belgium,
			ETerritories.Holland,
			ETerritories.HelgolandBight,
			ETerritories.Denmark,
			ETerritories.Norway,
			ETerritories.Skagerrak,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Norway] = new() {
			ETerritories.NorwegianSea,
			ETerritories.NorthSea,
			ETerritories.Skagerrak,
			ETerritories.Sweden,
			ETerritories.Finland,
			ETerritories.BarentsSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.NorwegianSea] = new() {
			ETerritories.Norway,
			ETerritories.NorthSea,
			ETerritories.Clyde,
			ETerritories.Edinburgh,
			ETerritories.NorthAtlanticOcean,
			ETerritories.BarentsSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Paris] = new() {
			ETerritories.Brest,
			ETerritories.Picardy,
			ETerritories.Burgundy,
			ETerritories.Gascony,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Picardy] = new() {
			ETerritories.Belgium,
			ETerritories.Burgundy,
			ETerritories.Paris,
			ETerritories.Brest,
			ETerritories.EnglishChannel,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Portugal] = new() {
			ETerritories.Spain,
			ETerritories.MidAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Piedmont] = new() {
			ETerritories.Marseilles,
			ETerritories.Tuscany,
			ETerritories.Tyrolia,
			ETerritories.Venice,
			ETerritories.GulfOfLyon,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Prussia] = new() {
			ETerritories.Berlin,
			ETerritories.Silesia,
			ETerritories.Livonia,
			ETerritories.Warsaw,
			ETerritories.BalticSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Rome] = new() {
			ETerritories.Naples,
			ETerritories.TyrrhenianSea,
			ETerritories.Tuscany,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Ruhr] = new() {
			ETerritories.Holland,
			ETerritories.Kiel,
			ETerritories.Berlin,
			ETerritories.Munich,
			ETerritories.Burgundy,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Rumania] = new() {
			ETerritories.Bulgaria,
			ETerritories.Serbia,
			ETerritories.Budapest,
			ETerritories.Ukraine,
			ETerritories.Galicia,
			ETerritories.BlackSea,
			ETerritories.Sevastopol,
			ETerritories.Constantinople,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Serbia] = new() {
			ETerritories.Bulgaria,
			ETerritories.Greece,
			ETerritories.Albania,
			ETerritories.Trieste,
			ETerritories.Budapest,
			ETerritories.Rumania,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Smyrna] = new() {
			ETerritories.Ankara,
			ETerritories.Armenia,
			ETerritories.Syria,
			ETerritories.EasternMediterranean,
			ETerritories.AegeanSea,
			ETerritories.Constantinople,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Sevastopol] = new() {
			ETerritories.Armenia,
			ETerritories.Rumania,
			ETerritories.Ukraine,
			ETerritories.Moscow,
			ETerritories.BlackSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Skagerrak] = new() {
			ETerritories.Norway,
			ETerritories.NorthSea,
			ETerritories.Denmark,
			ETerritories.Sweden,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Silesia] = new() {
			ETerritories.Berlin,
			ETerritories.Munich,
			ETerritories.Bohemia,
			ETerritories.Galicia,
			ETerritories.Warsaw,
			ETerritories.Prussia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Spain] = new() {
			ETerritories.Portugal,
			ETerritories.Marseilles,
			ETerritories.Gascony,
			ETerritories.GulfOfLyon,
			ETerritories.WesternMediterranean,
			ETerritories.MidAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.SaintPetersburg] = new() {
			ETerritories.Finland,
			ETerritories.Norway,
			ETerritories.Livonia,
			ETerritories.Moscow,
			ETerritories.GulfOfBothania,
			ETerritories.BarentsSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Sweden] = new() {
			ETerritories.Norway,
			ETerritories.Finland,
			ETerritories.GulfOfBothania,
			ETerritories.BalticSea,
			ETerritories.Skagerrak,
			ETerritories.Denmark,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Syria] = new() {
			ETerritories.Smyrna,
			ETerritories.Armenia,
			ETerritories.EasternMediterranean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Tunis] = new() {
			ETerritories.NorthAfrica,
			ETerritories.WesternMediterranean,
			ETerritories.TyrrhenianSea,
			ETerritories.IonianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Tuscany] = new() {
			ETerritories.Piedmont,
			ETerritories.Venice,
			ETerritories.Rome,
			ETerritories.TyrrhenianSea,
			ETerritories.GulfOfLyon,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Tyrolia] = new() {
			ETerritories.Munich,
			ETerritories.Bohemia,
			ETerritories.Vienna,
			ETerritories.Trieste,
			ETerritories.Venice,
			ETerritories.Piedmont,
		};
		Board.TerritoryAdjacencyMap[ETerritories.TyrrhenianSea] = new() {
			ETerritories.Tunis,
			ETerritories.WesternMediterranean,
			ETerritories.GulfOfLyon,
			ETerritories.Piedmont,
			ETerritories.Tuscany,
			ETerritories.Rome,
			ETerritories.Naples,
			ETerritories.IonianSea,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Ukraine] = new() {
			ETerritories.Warsaw,
			ETerritories.Moscow,
			ETerritories.Sevastopol,
			ETerritories.Rumania,
			ETerritories.Galicia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Venice] = new() {
			ETerritories.Tyrolia,
			ETerritories.Piedmont,
			ETerritories.Tuscany,
			ETerritories.Apuleia,
			ETerritories.AdriaticSea,
			ETerritories.Trieste,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Vienna] = new() {
			ETerritories.Tyrolia,
			ETerritories.Bohemia,
			ETerritories.Trieste,
			ETerritories.Budapest,
			ETerritories.Galicia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Wales] = new() {
			ETerritories.London,
			ETerritories.Yorkshire,
			ETerritories.EnglishChannel,
			ETerritories.IrishSea,
			ETerritories.Liverpool,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Warsaw] = new() {
			ETerritories.Livonia,
			ETerritories.Moscow,
			ETerritories.Ukraine,
			ETerritories.Galicia,
			ETerritories.Silesia,
			ETerritories.Prussia,
		};
		Board.TerritoryAdjacencyMap[ETerritories.WesternMediterranean] = new() {
			ETerritories.NorthAfrica,
			ETerritories.Tunis,
			ETerritories.TyrrhenianSea,
			ETerritories.GulfOfLyon,
			ETerritories.Spain,
			ETerritories.MidAtlanticOcean,
		};
		Board.TerritoryAdjacencyMap[ETerritories.Yorkshire] = new() {
			ETerritories.Edinburgh,
			ETerritories.Liverpool,
			ETerritories.London,
			ETerritories.NorthSea,
		};
	}
}

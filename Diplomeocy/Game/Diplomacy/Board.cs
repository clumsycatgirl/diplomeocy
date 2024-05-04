namespace Diplomacy;

using ETerritories = Diplomacy.Territories;

public class Board {
	public List<Territory> Territories { get; init; }

	public Territory Territory(string name) => Territories.First(t => t.Name.ToLower().Equals(name.ToLower()));
	public Territory Territory(ETerritories territory) => Territories.First(t => t.Name.ToLower().Equals(territory.ToString().ToLower()));

	public Board() {
		Territories = Enum.GetNames(typeof(ETerritories))
				  .Select(name => new Territory { Name = name })
				  .ToList();

		Territory(ETerritories.Trieste).AdjacentTerritories = new() {
			Territory(ETerritories.Venice),
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Vienna),
			Territory(ETerritories.Albania),
			Territory(ETerritories.AdriaticSea),
			Territory(ETerritories.Budapest),
			Territory(ETerritories.Serbia),
		};
		Territory(ETerritories.AdriaticSea).AdjacentTerritories = new() {
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Venice),
			Territory(ETerritories.Albania),
			Territory(ETerritories.Ioniansea),
			Territory(ETerritories.Apuleia),
		};
		Territory(ETerritories.AegeanSea).AdjacentTerritories = new() {
			Territory(ETerritories.Greece),
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Constantinople),
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.EasternMediterranean),
			Territory(ETerritories.Ioniansea),
		};
		Territory(ETerritories.Apuleia).AdjacentTerritories = new() {
			Territory(ETerritories.AdriaticSea),
			Territory(ETerritories.Venice),
			Territory(ETerritories.Naples),
			Territory(ETerritories.Ioniansea),
		};
		Territory(ETerritories.Albania).AdjacentTerritories = new() {
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Serbia),
			Territory(ETerritories.Greece),
			Territory(ETerritories.Ioniansea),
			Territory(ETerritories.AdriaticSea),
		};
		Territory(ETerritories.Ankara).AdjacentTerritories = new() {
			Territory(ETerritories.Constantinople),
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.Armenia),
			Territory(ETerritories.BlackSea),
		};
		Territory(ETerritories.Armenia).AdjacentTerritories = new() {
			Territory(ETerritories.Ankara),
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.Sevastopol),
			Territory(ETerritories.BlackSea),
			Territory(ETerritories.Syria),
		};
		Territory(ETerritories.BalticSea).AdjacentTerritories = new() {
			Territory(ETerritories.Denmark),
			Territory(ETerritories.Sweden),
			Territory(ETerritories.Livonia),
			Territory(ETerritories.Prussia),
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Berlin),
			Territory(ETerritories.GulfOfBothania),
		};
		Territory(ETerritories.BarentsSea).AdjacentTerritories = new() {
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.Norway),
			Territory(ETerritories.SaintPetersburg),
		};
		Territory(ETerritories.Belgium).AdjacentTerritories = new() {
			Territory(ETerritories.Holland),
			Territory(ETerritories.Ruhr),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Picardy),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.NorthSea),
		};
		Territory(ETerritories.Bohemia).AdjacentTerritories = new() {
			Territory(ETerritories.Munich),
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Silesia),
			Territory(ETerritories.Galicia),
			Territory(ETerritories.Vienna),
		};
		Territory(ETerritories.Berlin).AdjacentTerritories = new() {
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Prussia),
			Territory(ETerritories.Silesia),
			Territory(ETerritories.Munich),
			Territory(ETerritories.BalticSea),
		};
		Territory(ETerritories.BlackSea).AdjacentTerritories = new() {
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.Sevastopol),
			Territory(ETerritories.Armenia),
			Territory(ETerritories.Ankara),
			Territory(ETerritories.Constantinople),
		};
		Territory(ETerritories.Brest).AdjacentTerritories = new() {
			Territory(ETerritories.Paris),
			Territory(ETerritories.Picardy),
			Territory(ETerritories.MidAtlanticOcean),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.Gascony),
		};
		Territory(ETerritories.Budapest).AdjacentTerritories = new() {
			Territory(ETerritories.Vienna),
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Serbia),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.Galicia),
		};
		Territory(ETerritories.Bulgaria).AdjacentTerritories = new() {
			Territory(ETerritories.Constantinople),
			Territory(ETerritories.Greece),
			Territory(ETerritories.Serbia),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.BlackSea),
			Territory(ETerritories.AegeanSea),
		};
		Territory(ETerritories.Burgundy).AdjacentTerritories = new() {
			Territory(ETerritories.Paris),
			Territory(ETerritories.Picardy),
			Territory(ETerritories.Belgium),
			Territory(ETerritories.Marseilles),
			Territory(ETerritories.Ruhr),
			Territory(ETerritories.Munich),
			Territory(ETerritories.Gascony),
		};
		Territory(ETerritories.Clyde).AdjacentTerritories = new() {
			Territory(ETerritories.Edinburgh),
			Territory(ETerritories.NorthAtlanticOcean),
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.Liverpool),
		};
		Territory(ETerritories.Constantinople).AdjacentTerritories = new() {
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.Ankara),
			Territory(ETerritories.BlackSea),
			Territory(ETerritories.AegeanSea),
		};
		Territory(ETerritories.Denmark).AdjacentTerritories = new() {
			Territory(ETerritories.Sweden),
			Territory(ETerritories.Skagerrak),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.BalticSea),
			Territory(ETerritories.Kiel),
			Territory(ETerritories.HelgolandBight),
		};
		Territory(ETerritories.EasternMediterranean).AdjacentTerritories = new() {
			Territory(ETerritories.AegeanSea),
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.Syria),
			Territory(ETerritories.Ioniansea),
		};
		Territory(ETerritories.Edinburgh).AdjacentTerritories = new() {
			Territory(ETerritories.Clyde),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.Yorkshire),
			Territory(ETerritories.Liverpool),
		};
		Territory(ETerritories.EnglishChannel).AdjacentTerritories = new() {
			Territory(ETerritories.London),
			Territory(ETerritories.Wales),
			Territory(ETerritories.IrishSea),
			Territory(ETerritories.MidAtlanticOcean),
			Territory(ETerritories.Brest),
			Territory(ETerritories.Picardy),
			Territory(ETerritories.Belgium),
			Territory(ETerritories.NorthSea),
		};
		Territory(ETerritories.Finland).AdjacentTerritories = new() {
			Territory(ETerritories.Norway),
			Territory(ETerritories.SaintPetersburg),
			Territory(ETerritories.GulfOfBothania),
			Territory(ETerritories.Sweden),
		};
		Territory(ETerritories.Galicia).AdjacentTerritories = new() {
			Territory(ETerritories.Warsaw),
			Territory(ETerritories.Ukraine),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.Budapest),
			Territory(ETerritories.Vienna),
			Territory(ETerritories.Bohemia),
			Territory(ETerritories.Bohemia),
		};
		Territory(ETerritories.Gascony).AdjacentTerritories = new() {
			Territory(ETerritories.Brest),
			Territory(ETerritories.Paris),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Marseilles),
			Territory(ETerritories.Spain),
			Territory(ETerritories.GulfOfLyon),
			Territory(ETerritories.MidAtlanticOcean),
		};
		Territory(ETerritories.Greece).AdjacentTerritories = new() {
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Serbia),
			Territory(ETerritories.Albania),
			Territory(ETerritories.Ioniansea),
			Territory(ETerritories.AegeanSea),
		};
		Territory(ETerritories.GulfOfLyon).AdjacentTerritories = new() {
			Territory(ETerritories.Spain),
			Territory(ETerritories.Marseilles),
			Territory(ETerritories.Piedmont),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.Tuscany),
		};
		Territory(ETerritories.GulfOfBothania).AdjacentTerritories = new() {
			Territory(ETerritories.Sweden),
			Territory(ETerritories.Finland),
			Territory(ETerritories.BalticSea),
			Territory(ETerritories.SaintPetersburg),
			Territory(ETerritories.Livonia),
		};
		Territory(ETerritories.HelgolandBight).AdjacentTerritories = new() {
			Territory(ETerritories.Denmark),
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Holland),
			Territory(ETerritories.NorthSea),
		};
		Territory(ETerritories.Holland).AdjacentTerritories = new() {
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Ruhr),
			Territory(ETerritories.Belgium),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.HelgolandBight),
		};
		Territory(ETerritories.Ioniansea).AdjacentTerritories = new() {
			Territory(ETerritories.AdriaticSea),
			Territory(ETerritories.Apuleia),
			Territory(ETerritories.Naples),
			Territory(ETerritories.Tunis),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.EasternMediterranean),
			Territory(ETerritories.AegeanSea),
			Territory(ETerritories.Greece),
			Territory(ETerritories.Albania),
		};
		Territory(ETerritories.IrishSea).AdjacentTerritories = new() {
			Territory(ETerritories.Liverpool),
			Territory(ETerritories.Wales),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.MidAtlanticOcean),
			Territory(ETerritories.NorthAtlanticOcean),
		};
		Territory(ETerritories.Kiel).AdjacentTerritories = new() {
			Territory(ETerritories.Denmark),
			Territory(ETerritories.Holland),
			Territory(ETerritories.Ruhr),
			Territory(ETerritories.Berlin),
			Territory(ETerritories.Munich),
			Territory(ETerritories.BalticSea),
			Territory(ETerritories.HelgolandBight),
		};
		Territory(ETerritories.Liverpool).AdjacentTerritories = new() {
			Territory(ETerritories.Edinburgh),
			Territory(ETerritories.Clyde),
			Territory(ETerritories.NorthAtlanticOcean),
			Territory(ETerritories.IrishSea),
			Territory(ETerritories.Wales),
			Territory(ETerritories.Yorkshire),
		};
		Territory(ETerritories.Livonia).AdjacentTerritories = new() {
			Territory(ETerritories.SaintPetersburg),
			Territory(ETerritories.Moscow),
			Territory(ETerritories.Warsaw),
			Territory(ETerritories.Prussia),
			Territory(ETerritories.BalticSea),
			Territory(ETerritories.GulfOfBothania),
		};
		Territory(ETerritories.London).AdjacentTerritories = new() {
			Territory(ETerritories.Wales),
			Territory(ETerritories.Yorkshire),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.EnglishChannel),
		};
		Territory(ETerritories.Marseilles).AdjacentTerritories = new() {
			Territory(ETerritories.Spain),
			Territory(ETerritories.Gascony),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Piedmont),
			Territory(ETerritories.GulfOfLyon),
		};
		Territory(ETerritories.MidAtlanticOcean).AdjacentTerritories = new() {
			Territory(ETerritories.IrishSea),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.Brest),
			Territory(ETerritories.Gascony),
			Territory(ETerritories.Spain),
			Territory(ETerritories.Portugal),
			Territory(ETerritories.NorthAtlanticOcean),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.NorthAfrica),
		};
		Territory(ETerritories.Moscow).AdjacentTerritories = new() {
			Territory(ETerritories.SaintPetersburg),
			Territory(ETerritories.Livonia),
			Territory(ETerritories.Ukraine),
			Territory(ETerritories.Sevastopol),
			Territory(ETerritories.Warsaw),
		};
		Territory(ETerritories.Munich).AdjacentTerritories = new() {
			Territory(ETerritories.Berlin),
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Ruhr),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Bohemia),
			Territory(ETerritories.Silesia),
		};
		Territory(ETerritories.Naples).AdjacentTerritories = new() {
			Territory(ETerritories.Rome),
			Territory(ETerritories.Apuleia),
			Territory(ETerritories.Ioniansea),
			Territory(ETerritories.TyrrhenianSea),
		};
		Territory(ETerritories.NorthAfrica).AdjacentTerritories = new() {
			Territory(ETerritories.MidAtlanticOcean),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.Tunis),
		};
		Territory(ETerritories.NorthAtlanticOcean).AdjacentTerritories = new() {
			Territory(ETerritories.IrishSea),
			Territory(ETerritories.Liverpool),
			Territory(ETerritories.Clyde),
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.MidAtlanticOcean),
		};
		Territory(ETerritories.NorthSea).AdjacentTerritories = new() {
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.Edinburgh),
			Territory(ETerritories.Yorkshire),
			Territory(ETerritories.London),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.Belgium),
			Territory(ETerritories.Holland),
			Territory(ETerritories.HelgolandBight),
			Territory(ETerritories.Denmark),
			Territory(ETerritories.Norway),
			Territory(ETerritories.Skagerrak),
		};
		Territory(ETerritories.Norway).AdjacentTerritories = new() {
			Territory(ETerritories.NorwegianSea),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.Skagerrak),
			Territory(ETerritories.Sweden),
			Territory(ETerritories.Finland),
			Territory(ETerritories.BarentsSea),
		};
		Territory(ETerritories.NorwegianSea).AdjacentTerritories = new() {
			Territory(ETerritories.Norway),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.Clyde),
			Territory(ETerritories.Edinburgh),
			Territory(ETerritories.NorthAtlanticOcean),
			Territory(ETerritories.BarentsSea),
		};
		Territory(ETerritories.Paris).AdjacentTerritories = new() {
			Territory(ETerritories.Brest),
			Territory(ETerritories.Picardy),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Gascony),
		};
		Territory(ETerritories.Picardy).AdjacentTerritories = new() {
			Territory(ETerritories.Belgium),
			Territory(ETerritories.Burgundy),
			Territory(ETerritories.Paris),
			Territory(ETerritories.Brest),
			Territory(ETerritories.EnglishChannel),
		};
		Territory(ETerritories.Portugal).AdjacentTerritories = new() {
			Territory(ETerritories.Spain),
			Territory(ETerritories.MidAtlanticOcean),
		};
		Territory(ETerritories.Piedmont).AdjacentTerritories = new() {
			Territory(ETerritories.Marseilles),
			Territory(ETerritories.Tuscany),
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Venice),
			Territory(ETerritories.GulfOfLyon),
		};
		Territory(ETerritories.Prussia).AdjacentTerritories = new() {
			Territory(ETerritories.Berlin),
			Territory(ETerritories.Silesia),
			Territory(ETerritories.Livonia),
			Territory(ETerritories.Warsaw),
			Territory(ETerritories.BalticSea),
		};
		Territory(ETerritories.Rome).AdjacentTerritories = new() {
			Territory(ETerritories.Naples),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.Tuscany),
		};
		Territory(ETerritories.Ruhr).AdjacentTerritories = new() {
			Territory(ETerritories.Holland),
			Territory(ETerritories.Kiel),
			Territory(ETerritories.Berlin),
			Territory(ETerritories.Munich),
			Territory(ETerritories.Burgundy),
		};
		Territory(ETerritories.Rumania).AdjacentTerritories = new() {
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Serbia),
			Territory(ETerritories.Budapest),
			Territory(ETerritories.Ukraine),
			Territory(ETerritories.Galicia),
			Territory(ETerritories.BlackSea),
			Territory(ETerritories.Sevastopol),
			Territory(ETerritories.Constantinople),
		};
		Territory(ETerritories.Serbia).AdjacentTerritories = new() {
			Territory(ETerritories.Bulgaria),
			Territory(ETerritories.Greece),
			Territory(ETerritories.Albania),
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Budapest),
			Territory(ETerritories.Rumania),
		};
		Territory(ETerritories.Smyrna).AdjacentTerritories = new() {
			Territory(ETerritories.Ankara),
			Territory(ETerritories.Armenia),
			Territory(ETerritories.Syria),
			Territory(ETerritories.EasternMediterranean),
			Territory(ETerritories.AegeanSea),
			Territory(ETerritories.Constantinople),
		};
		Territory(ETerritories.Sevastopol).AdjacentTerritories = new() {
			Territory(ETerritories.Armenia),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.Ukraine),
			Territory(ETerritories.Moscow),
			Territory(ETerritories.BlackSea),
		};
		Territory(ETerritories.Skagerrak).AdjacentTerritories = new() {
			Territory(ETerritories.Norway),
			Territory(ETerritories.NorthSea),
			Territory(ETerritories.Denmark),
			Territory(ETerritories.Sweden),
		};
		Territory(ETerritories.Silesia).AdjacentTerritories = new() {
			Territory(ETerritories.Berlin),
			Territory(ETerritories.Munich),
			Territory(ETerritories.Bohemia),
			Territory(ETerritories.Galicia),
			Territory(ETerritories.Warsaw),
			Territory(ETerritories.Prussia),
		};
		Territory(ETerritories.Spain).AdjacentTerritories = new() {
			Territory(ETerritories.Portugal),
			Territory(ETerritories.Marseilles),
			Territory(ETerritories.Gascony),
			Territory(ETerritories.GulfOfLyon),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.MidAtlanticOcean),
		};
		Territory(ETerritories.SaintPetersburg).AdjacentTerritories = new() {
			Territory(ETerritories.Finland),
			Territory(ETerritories.Norway),
			Territory(ETerritories.Livonia),
			Territory(ETerritories.Moscow),
			Territory(ETerritories.GulfOfBothania),
			Territory(ETerritories.BarentsSea),
		};
		Territory(ETerritories.Sweden).AdjacentTerritories = new() {
			Territory(ETerritories.Norway),
			Territory(ETerritories.Finland),
			Territory(ETerritories.GulfOfBothania),
			Territory(ETerritories.BalticSea),
			Territory(ETerritories.Skagerrak),
			Territory(ETerritories.Denmark),
		};
		Territory(ETerritories.Syria).AdjacentTerritories = new() {
			Territory(ETerritories.Smyrna),
			Territory(ETerritories.Armenia),
			Territory(ETerritories.EasternMediterranean),
		};
		Territory(ETerritories.Tunis).AdjacentTerritories = new() {
			Territory(ETerritories.NorthAfrica),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.Ioniansea),
		};
		Territory(ETerritories.Tuscany).AdjacentTerritories = new() {
			Territory(ETerritories.Piedmont),
			Territory(ETerritories.Venice),
			Territory(ETerritories.Rome),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.GulfOfLyon),
		};
		Territory(ETerritories.Tyrolia).AdjacentTerritories = new() {
			Territory(ETerritories.Munich),
			Territory(ETerritories.Bohemia),
			Territory(ETerritories.Vienna),
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Venice),
			Territory(ETerritories.Piedmont),
		};
		Territory(ETerritories.TyrrhenianSea).AdjacentTerritories = new() {
			Territory(ETerritories.Tunis),
			Territory(ETerritories.WesternMediterranean),
			Territory(ETerritories.GulfOfLyon),
			Territory(ETerritories.Piedmont),
			Territory(ETerritories.Tuscany),
			Territory(ETerritories.Rome),
			Territory(ETerritories.Naples),
			Territory(ETerritories.Ioniansea),
		};
		Territory(ETerritories.Ukraine).AdjacentTerritories = new() {
			Territory(ETerritories.Warsaw),
			Territory(ETerritories.Moscow),
			Territory(ETerritories.Sevastopol),
			Territory(ETerritories.Rumania),
			Territory(ETerritories.Galicia),
		};
		Territory(ETerritories.Venice).AdjacentTerritories = new() {
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Piedmont),
			Territory(ETerritories.Tuscany),
			Territory(ETerritories.Apuleia),
			Territory(ETerritories.AdriaticSea),
			Territory(ETerritories.Trieste),
		};
		Territory(ETerritories.Vienna).AdjacentTerritories = new() {
			Territory(ETerritories.Tyrolia),
			Territory(ETerritories.Bohemia),
			Territory(ETerritories.Trieste),
			Territory(ETerritories.Budapest),
			Territory(ETerritories.Galicia),
		};
		Territory(ETerritories.Wales).AdjacentTerritories = new() {
			Territory(ETerritories.London),
			Territory(ETerritories.Yorkshire),
			Territory(ETerritories.EnglishChannel),
			Territory(ETerritories.IrishSea),
			Territory(ETerritories.Liverpool),
		};
		Territory(ETerritories.Warsaw).AdjacentTerritories = new() {
			Territory(ETerritories.Livonia),
			Territory(ETerritories.Moscow),
			Territory(ETerritories.Ukraine),
			Territory(ETerritories.Galicia),
			Territory(ETerritories.Silesia),
			Territory(ETerritories.Prussia),
		};
		Territory(ETerritories.WesternMediterranean).AdjacentTerritories = new() {
			Territory(ETerritories.NorthAfrica),
			Territory(ETerritories.Tunis),
			Territory(ETerritories.TyrrhenianSea),
			Territory(ETerritories.GulfOfLyon),
			Territory(ETerritories.Spain),
			Territory(ETerritories.MidAtlanticOcean),
		};
		Territory(ETerritories.Yorkshire).AdjacentTerritories = new() {
			Territory(ETerritories.Edinburgh),
			Territory(ETerritories.Liverpool),
			Territory(ETerritories.London),
			Territory(ETerritories.NorthSea),
		};
	}
}

namespace Diplomacy;

using DTerritories = Diplomacy.Territories;

public class Board {
	public List<Territory> Territories { get; init; }

	public Territory Territory(string name) => Territories.First(t => t.Name.ToLower().Equals(name.ToLower()));
	public Territory Territory(DTerritories territory) => Territories.First(t => t.Name.ToLower().Equals(territory.ToString().ToLower()));

	public Board() {
		Territories = Enum.GetNames(typeof(DTerritories))
				  .Select(name => new Territory { Name = name })
				  .ToList();

		Territory(DTerritories.Trieste).AdjacentTerritories = new() {
			Territory(DTerritories.Venice),
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Vienna),
			Territory(DTerritories.Albania),
			Territory(DTerritories.AdriaticSea),
			Territory(DTerritories.Budapest),
			Territory(DTerritories.Serbia),
		};
		Territory(DTerritories.AdriaticSea).AdjacentTerritories = new() {
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Venice),
			Territory(DTerritories.Albania),
			Territory(DTerritories.Ioniansea),
			Territory(DTerritories.Apuleia),
		};
		Territory(DTerritories.AegeanSea).AdjacentTerritories = new() {
			Territory(DTerritories.Greece),
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Constantinople),
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.EasternMediterranean),
			Territory(DTerritories.Ioniansea),
		};
		Territory(DTerritories.Apuleia).AdjacentTerritories = new() {
			Territory(DTerritories.AdriaticSea),
			Territory(DTerritories.Venice),
			Territory(DTerritories.Naples),
			Territory(DTerritories.Ioniansea),
		};
		Territory(DTerritories.Albania).AdjacentTerritories = new() {
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Serbia),
			Territory(DTerritories.Greece),
			Territory(DTerritories.Ioniansea),
			Territory(DTerritories.AdriaticSea),
		};
		Territory(DTerritories.Ankara).AdjacentTerritories = new() {
			Territory(DTerritories.Constantinople),
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.Armenia),
			Territory(DTerritories.BlackSea),
		};
		Territory(DTerritories.Armenia).AdjacentTerritories = new() {
			Territory(DTerritories.Ankara),
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.Sevastopol),
			Territory(DTerritories.BlackSea),
			Territory(DTerritories.Syria),
		};
		Territory(DTerritories.BalticSea).AdjacentTerritories = new() {
			Territory(DTerritories.Denmark),
			Territory(DTerritories.Sweden),
			Territory(DTerritories.Livonia),
			Territory(DTerritories.Prussia),
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Berlin),
			Territory(DTerritories.GulfOfBothania),
		};
		Territory(DTerritories.BarentsSea).AdjacentTerritories = new() {
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.Norway),
			Territory(DTerritories.SaintPetersburg),
		};
		Territory(DTerritories.Belgium).AdjacentTerritories = new() {
			Territory(DTerritories.Holland),
			Territory(DTerritories.Ruhr),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Picardy),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.NorthSea),
		};
		Territory(DTerritories.Bohemia).AdjacentTerritories = new() {
			Territory(DTerritories.Munich),
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Silesia),
			Territory(DTerritories.Galicia),
			Territory(DTerritories.Vienna),
		};
		Territory(DTerritories.Berlin).AdjacentTerritories = new() {
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Prussia),
			Territory(DTerritories.Silesia),
			Territory(DTerritories.Munich),
			Territory(DTerritories.BalticSea),
		};
		Territory(DTerritories.BlackSea).AdjacentTerritories = new() {
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.Sevastopol),
			Territory(DTerritories.Armenia),
			Territory(DTerritories.Ankara),
			Territory(DTerritories.Constantinople),
		};
		Territory(DTerritories.Brest).AdjacentTerritories = new() {
			Territory(DTerritories.Paris),
			Territory(DTerritories.Picardy),
			Territory(DTerritories.MidAtlanticOcean),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.Gascony),
		};
		Territory(DTerritories.Budapest).AdjacentTerritories = new() {
			Territory(DTerritories.Vienna),
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Serbia),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.Galicia),
		};
		Territory(DTerritories.Bulgaria).AdjacentTerritories = new() {
			Territory(DTerritories.Constantinople),
			Territory(DTerritories.Greece),
			Territory(DTerritories.Serbia),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.BlackSea),
			Territory(DTerritories.AegeanSea),
		};
		Territory(DTerritories.Burgundy).AdjacentTerritories = new() {
			Territory(DTerritories.Paris),
			Territory(DTerritories.Picardy),
			Territory(DTerritories.Belgium),
			Territory(DTerritories.Marseilles),
			Territory(DTerritories.Ruhr),
			Territory(DTerritories.Munich),
			Territory(DTerritories.Gascony),
		};
		Territory(DTerritories.Clyde).AdjacentTerritories = new() {
			Territory(DTerritories.Edinburgh),
			Territory(DTerritories.NorthAtlanticOcean),
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.Liverpool),
		};
		Territory(DTerritories.Constantinople).AdjacentTerritories = new() {
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.Ankara),
			Territory(DTerritories.BlackSea),
			Territory(DTerritories.AegeanSea),
		};
		Territory(DTerritories.Denmark).AdjacentTerritories = new() {
			Territory(DTerritories.Sweden),
			Territory(DTerritories.Skagerrak),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.BalticSea),
			Territory(DTerritories.Kiel),
			Territory(DTerritories.HelgolandBight),
		};
		Territory(DTerritories.EasternMediterranean).AdjacentTerritories = new() {
			Territory(DTerritories.AegeanSea),
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.Syria),
			Territory(DTerritories.Ioniansea),
		};
		Territory(DTerritories.Edinburgh).AdjacentTerritories = new() {
			Territory(DTerritories.Clyde),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.Yorkshire),
			Territory(DTerritories.Liverpool),
		};
		Territory(DTerritories.EnglishChannel).AdjacentTerritories = new() {
			Territory(DTerritories.London),
			Territory(DTerritories.Wales),
			Territory(DTerritories.IrishSea),
			Territory(DTerritories.MidAtlanticOcean),
			Territory(DTerritories.Brest),
			Territory(DTerritories.Picardy),
			Territory(DTerritories.Belgium),
			Territory(DTerritories.NorthSea),
		};
		Territory(DTerritories.Finland).AdjacentTerritories = new() {
			Territory(DTerritories.Norway),
			Territory(DTerritories.SaintPetersburg),
			Territory(DTerritories.GulfOfBothania),
			Territory(DTerritories.Sweden),
		};
		Territory(DTerritories.Galicia).AdjacentTerritories = new() {
			Territory(DTerritories.Warsaw),
			Territory(DTerritories.Ukraine),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.Budapest),
			Territory(DTerritories.Vienna),
			Territory(DTerritories.Bohemia),
			Territory(DTerritories.Bohemia),
		};
		Territory(DTerritories.Gascony).AdjacentTerritories = new() {
			Territory(DTerritories.Brest),
			Territory(DTerritories.Paris),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Marseilles),
			Territory(DTerritories.Spain),
			Territory(DTerritories.GulfOfLyon),
			Territory(DTerritories.MidAtlanticOcean),
		};
		Territory(DTerritories.Greece).AdjacentTerritories = new() {
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Serbia),
			Territory(DTerritories.Albania),
			Territory(DTerritories.Ioniansea),
			Territory(DTerritories.AegeanSea),
		};
		Territory(DTerritories.GulfOfLyon).AdjacentTerritories = new() {
			Territory(DTerritories.Spain),
			Territory(DTerritories.Marseilles),
			Territory(DTerritories.Piedmont),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.Tuscany),
		};
		Territory(DTerritories.GulfOfBothania).AdjacentTerritories = new() {
			Territory(DTerritories.Sweden),
			Territory(DTerritories.Finland),
			Territory(DTerritories.BalticSea),
			Territory(DTerritories.SaintPetersburg),
			Territory(DTerritories.Livonia),
		};
		Territory(DTerritories.HelgolandBight).AdjacentTerritories = new() {
			Territory(DTerritories.Denmark),
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Holland),
			Territory(DTerritories.NorthSea),
		};
		Territory(DTerritories.Holland).AdjacentTerritories = new() {
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Ruhr),
			Territory(DTerritories.Belgium),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.HelgolandBight),
		};
		Territory(DTerritories.Ioniansea).AdjacentTerritories = new() {
			Territory(DTerritories.AdriaticSea),
			Territory(DTerritories.Apuleia),
			Territory(DTerritories.Naples),
			Territory(DTerritories.Tunis),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.EasternMediterranean),
			Territory(DTerritories.AegeanSea),
			Territory(DTerritories.Greece),
			Territory(DTerritories.Albania),
		};
		Territory(DTerritories.IrishSea).AdjacentTerritories = new() {
			Territory(DTerritories.Liverpool),
			Territory(DTerritories.Wales),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.MidAtlanticOcean),
			Territory(DTerritories.NorthAtlanticOcean),
		};
		Territory(DTerritories.Kiel).AdjacentTerritories = new() {
			Territory(DTerritories.Denmark),
			Territory(DTerritories.Holland),
			Territory(DTerritories.Ruhr),
			Territory(DTerritories.Berlin),
			Territory(DTerritories.Munich),
			Territory(DTerritories.BalticSea),
			Territory(DTerritories.HelgolandBight),
		};
		Territory(DTerritories.Liverpool).AdjacentTerritories = new() {
			Territory(DTerritories.Edinburgh),
			Territory(DTerritories.Clyde),
			Territory(DTerritories.NorthAtlanticOcean),
			Territory(DTerritories.IrishSea),
			Territory(DTerritories.Wales),
			Territory(DTerritories.Yorkshire),
		};
		Territory(DTerritories.Livonia).AdjacentTerritories = new() {
			Territory(DTerritories.SaintPetersburg),
			Territory(DTerritories.Moscow),
			Territory(DTerritories.Warsaw),
			Territory(DTerritories.Prussia),
			Territory(DTerritories.BalticSea),
			Territory(DTerritories.GulfOfBothania),
		};
		Territory(DTerritories.London).AdjacentTerritories = new() {
			Territory(DTerritories.Wales),
			Territory(DTerritories.Yorkshire),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.EnglishChannel),
		};
		Territory(DTerritories.Marseilles).AdjacentTerritories = new() {
			Territory(DTerritories.Spain),
			Territory(DTerritories.Gascony),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Piedmont),
			Territory(DTerritories.GulfOfLyon),
		};
		Territory(DTerritories.MidAtlanticOcean).AdjacentTerritories = new() {
			Territory(DTerritories.IrishSea),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.Brest),
			Territory(DTerritories.Gascony),
			Territory(DTerritories.Spain),
			Territory(DTerritories.Portugal),
			Territory(DTerritories.NorthAtlanticOcean),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.NorthAfrica),
		};
		Territory(DTerritories.Moscow).AdjacentTerritories = new() {
			Territory(DTerritories.SaintPetersburg),
			Territory(DTerritories.Livonia),
			Territory(DTerritories.Ukraine),
			Territory(DTerritories.Sevastopol),
			Territory(DTerritories.Warsaw),
		};
		Territory(DTerritories.Munich).AdjacentTerritories = new() {
			Territory(DTerritories.Berlin),
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Ruhr),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Bohemia),
			Territory(DTerritories.Silesia),
		};
		Territory(DTerritories.Naples).AdjacentTerritories = new() {
			Territory(DTerritories.Rome),
			Territory(DTerritories.Apuleia),
			Territory(DTerritories.Ioniansea),
			Territory(DTerritories.TyrrhenianSea),
		};
		Territory(DTerritories.NorthAfrica).AdjacentTerritories = new() {
			Territory(DTerritories.MidAtlanticOcean),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.Tunis),
		};
		Territory(DTerritories.NorthAtlanticOcean).AdjacentTerritories = new() {
			Territory(DTerritories.IrishSea),
			Territory(DTerritories.Liverpool),
			Territory(DTerritories.Clyde),
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.MidAtlanticOcean),
		};
		Territory(DTerritories.NorthSea).AdjacentTerritories = new() {
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.Edinburgh),
			Territory(DTerritories.Yorkshire),
			Territory(DTerritories.London),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.Belgium),
			Territory(DTerritories.Holland),
			Territory(DTerritories.HelgolandBight),
			Territory(DTerritories.Denmark),
			Territory(DTerritories.Norway),
			Territory(DTerritories.Skagerrak),
		};
		Territory(DTerritories.Norway).AdjacentTerritories = new() {
			Territory(DTerritories.NorwegianSea),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.Skagerrak),
			Territory(DTerritories.Sweden),
			Territory(DTerritories.Finland),
			Territory(DTerritories.BarentsSea),
		};
		Territory(DTerritories.NorwegianSea).AdjacentTerritories = new() {
			Territory(DTerritories.Norway),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.Clyde),
			Territory(DTerritories.Edinburgh),
			Territory(DTerritories.NorthAtlanticOcean),
			Territory(DTerritories.BarentsSea),
		};
		Territory(DTerritories.Paris).AdjacentTerritories = new() {
			Territory(DTerritories.Brest),
			Territory(DTerritories.Picardy),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Gascony),
		};
		Territory(DTerritories.Picardy).AdjacentTerritories = new() {
			Territory(DTerritories.Belgium),
			Territory(DTerritories.Burgundy),
			Territory(DTerritories.Paris),
			Territory(DTerritories.Brest),
			Territory(DTerritories.EnglishChannel),
		};
		Territory(DTerritories.Portugal).AdjacentTerritories = new() {
			Territory(DTerritories.Spain),
			Territory(DTerritories.MidAtlanticOcean),
		};
		Territory(DTerritories.Piedmont).AdjacentTerritories = new() {
			Territory(DTerritories.Marseilles),
			Territory(DTerritories.Tuscany),
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Venice),
			Territory(DTerritories.GulfOfLyon),
		};
		Territory(DTerritories.Prussia).AdjacentTerritories = new() {
			Territory(DTerritories.Berlin),
			Territory(DTerritories.Silesia),
			Territory(DTerritories.Livonia),
			Territory(DTerritories.Warsaw),
			Territory(DTerritories.BalticSea),
		};
		Territory(DTerritories.Rome).AdjacentTerritories = new() {
			Territory(DTerritories.Naples),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.Tuscany),
		};
		Territory(DTerritories.Ruhr).AdjacentTerritories = new() {
			Territory(DTerritories.Holland),
			Territory(DTerritories.Kiel),
			Territory(DTerritories.Berlin),
			Territory(DTerritories.Munich),
			Territory(DTerritories.Burgundy),
		};
		Territory(DTerritories.Rumania).AdjacentTerritories = new() {
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Serbia),
			Territory(DTerritories.Budapest),
			Territory(DTerritories.Ukraine),
			Territory(DTerritories.Galicia),
			Territory(DTerritories.BlackSea),
			Territory(DTerritories.Sevastopol),
			Territory(DTerritories.Constantinople),
		};
		Territory(DTerritories.Serbia).AdjacentTerritories = new() {
			Territory(DTerritories.Bulgaria),
			Territory(DTerritories.Greece),
			Territory(DTerritories.Albania),
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Budapest),
			Territory(DTerritories.Rumania),
		};
		Territory(DTerritories.Smyrna).AdjacentTerritories = new() {
			Territory(DTerritories.Ankara),
			Territory(DTerritories.Armenia),
			Territory(DTerritories.Syria),
			Territory(DTerritories.EasternMediterranean),
			Territory(DTerritories.AegeanSea),
			Territory(DTerritories.Constantinople),
		};
		Territory(DTerritories.Sevastopol).AdjacentTerritories = new() {
			Territory(DTerritories.Armenia),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.Ukraine),
			Territory(DTerritories.Moscow),
			Territory(DTerritories.BlackSea),
		};
		Territory(DTerritories.Skagerrak).AdjacentTerritories = new() {
			Territory(DTerritories.Norway),
			Territory(DTerritories.NorthSea),
			Territory(DTerritories.Denmark),
			Territory(DTerritories.Sweden),
		};
		Territory(DTerritories.Silesia).AdjacentTerritories = new() {
			Territory(DTerritories.Berlin),
			Territory(DTerritories.Munich),
			Territory(DTerritories.Bohemia),
			Territory(DTerritories.Galicia),
			Territory(DTerritories.Warsaw),
			Territory(DTerritories.Prussia),
		};
		Territory(DTerritories.Spain).AdjacentTerritories = new() {
			Territory(DTerritories.Portugal),
			Territory(DTerritories.Marseilles),
			Territory(DTerritories.Gascony),
			Territory(DTerritories.GulfOfLyon),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.MidAtlanticOcean),
		};
		Territory(DTerritories.SaintPetersburg).AdjacentTerritories = new() {
			Territory(DTerritories.Finland),
			Territory(DTerritories.Norway),
			Territory(DTerritories.Livonia),
			Territory(DTerritories.Moscow),
			Territory(DTerritories.GulfOfBothania),
			Territory(DTerritories.BarentsSea),
		};
		Territory(DTerritories.Sweden).AdjacentTerritories = new() {
			Territory(DTerritories.Norway),
			Territory(DTerritories.Finland),
			Territory(DTerritories.GulfOfBothania),
			Territory(DTerritories.BalticSea),
			Territory(DTerritories.Skagerrak),
			Territory(DTerritories.Denmark),
		};
		Territory(DTerritories.Syria).AdjacentTerritories = new() {
			Territory(DTerritories.Smyrna),
			Territory(DTerritories.Armenia),
			Territory(DTerritories.EasternMediterranean),
		};
		Territory(DTerritories.Tunis).AdjacentTerritories = new() {
			Territory(DTerritories.NorthAfrica),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.Ioniansea),
		};
		Territory(DTerritories.Tuscany).AdjacentTerritories = new() {
			Territory(DTerritories.Piedmont),
			Territory(DTerritories.Venice),
			Territory(DTerritories.Rome),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.GulfOfLyon),
		};
		Territory(DTerritories.Tyrolia).AdjacentTerritories = new() {
			Territory(DTerritories.Munich),
			Territory(DTerritories.Bohemia),
			Territory(DTerritories.Vienna),
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Venice),
			Territory(DTerritories.Piedmont),
		};
		Territory(DTerritories.TyrrhenianSea).AdjacentTerritories = new() {
			Territory(DTerritories.Tunis),
			Territory(DTerritories.WesternMediterranean),
			Territory(DTerritories.GulfOfLyon),
			Territory(DTerritories.Piedmont),
			Territory(DTerritories.Tuscany),
			Territory(DTerritories.Rome),
			Territory(DTerritories.Naples),
			Territory(DTerritories.Ioniansea),
		};
		Territory(DTerritories.Ukraine).AdjacentTerritories = new() {
			Territory(DTerritories.Warsaw),
			Territory(DTerritories.Moscow),
			Territory(DTerritories.Sevastopol),
			Territory(DTerritories.Rumania),
			Territory(DTerritories.Galicia),
		};
		Territory(DTerritories.Venice).AdjacentTerritories = new() {
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Piedmont),
			Territory(DTerritories.Tuscany),
			Territory(DTerritories.Apuleia),
			Territory(DTerritories.AdriaticSea),
			Territory(DTerritories.Trieste),
		};
		Territory(DTerritories.Vienna).AdjacentTerritories = new() {
			Territory(DTerritories.Tyrolia),
			Territory(DTerritories.Bohemia),
			Territory(DTerritories.Trieste),
			Territory(DTerritories.Budapest),
			Territory(DTerritories.Galicia),
		};
		Territory(DTerritories.Wales).AdjacentTerritories = new() {
			Territory(DTerritories.London),
			Territory(DTerritories.Yorkshire),
			Territory(DTerritories.EnglishChannel),
			Territory(DTerritories.IrishSea),
			Territory(DTerritories.Liverpool),
		};
		Territory(DTerritories.Warsaw).AdjacentTerritories = new() {
			Territory(DTerritories.Livonia),
			Territory(DTerritories.Moscow),
			Territory(DTerritories.Ukraine),
			Territory(DTerritories.Galicia),
			Territory(DTerritories.Silesia),
			Territory(DTerritories.Prussia),
		};
		Territory(DTerritories.WesternMediterranean).AdjacentTerritories = new() {
			Territory(DTerritories.NorthAfrica),
			Territory(DTerritories.Tunis),
			Territory(DTerritories.TyrrhenianSea),
			Territory(DTerritories.GulfOfLyon),
			Territory(DTerritories.Spain),
			Territory(DTerritories.MidAtlanticOcean),
		};
		Territory(DTerritories.Yorkshire).AdjacentTerritories = new() {
			Territory(DTerritories.Edinburgh),
			Territory(DTerritories.Liverpool),
			Territory(DTerritories.London),
			Territory(DTerritories.NorthSea),
		};
	}
}

namespace Diplomacy;

public class Unit {
	public UnitType Type { get; init; }
	public Territory Location { get; set; }

	public override string ToString() => $"({Type} in {Location.Name})";
}

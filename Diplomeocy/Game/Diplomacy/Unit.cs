
namespace Diplomacy;

public class Unit {
	public required UnitType Type { get; init; } = UnitType.Army;
	public required Territory Location { get; set; }

	public override string ToString() => $"({Type} in {Location.Name})";

	internal void Move(Territory destination) {
		Location.OccupyingUnit = null;
		Location = destination;
		destination.OccupyingUnit = this;
	}
}

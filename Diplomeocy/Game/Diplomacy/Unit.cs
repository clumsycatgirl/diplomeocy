
namespace Diplomacy;

public class Unit {
	public required UnitType Type { get; init; } = UnitType.Army;
	public required Territory? Location { get; set; }

	public bool IsRetired => Location is null;

	public override string ToString() => $"({Type} in {Location?.Name})";

	public void Move(Territory destination) {
		if (Location is not null) Location.OccupyingUnit = null;
		Location = destination;
		destination.OccupyingUnit = this;
	}
}

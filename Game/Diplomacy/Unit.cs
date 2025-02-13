
namespace Diplomacy;

public class Unit {
	public required Countries Country { get; init; }
	public required UnitType Type { get; init; } = UnitType.Army;
	public required Territory? Location { get; set; }

	public Territory? PreviousLocation { get; set; }

	public bool IsRetired => Location is null;

	public override string ToString() => $"([{Country}] {Type} in {Location?.Name})";

	public Unit Move(Territory destination) {
		if (Location is not null) Location.OccupyingUnit = null;
		Location = destination;
		destination.OccupyingUnit = this;
		return this;
	}
}

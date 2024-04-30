namespace Diplomacy;

public class Territory {
	public string Name { get; init; }
	public Unit OccupyingUnit { get; set; }
	public List<Territory> AdjacentTerritories { get; set; }

	public override string ToString() => $"({Name} occupied by {OccupyingUnit})";
}

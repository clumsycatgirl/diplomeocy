namespace Diplomacy;

public class Territory {
	public required string Name { get; init; }
	public Unit? OccupyingUnit { get; set; } = null;
	public List<Territory> AdjacentTerritories { get; set; } = new();

	public override string ToString() => $"({Name} occupied by {OccupyingUnit?.ToString() ?? "none"})";

	public static implicit operator string(Territory territory) => territory.Name;
}

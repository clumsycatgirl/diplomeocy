namespace Diplomacy;

public class Player {
	public required string Name { get; init; }
	public List<Country> Countries { get; init; } = new();
	public List<Unit> Units { get; init; } = new();
	public List<Order> Orders { get; init; } = new();

	public Unit Unit(Territories territory) => Units.First(u => u.Location.Name == territory.ToString());
}

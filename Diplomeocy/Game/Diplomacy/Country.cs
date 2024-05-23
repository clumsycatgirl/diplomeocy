namespace Diplomacy;

#pragma warning disable CS8618
public class Country {
	public string Name { get; init; }
	public List<Territory> Territories { get; init; }

	public readonly List<string> TerritoriesSerializationNames = new();
}

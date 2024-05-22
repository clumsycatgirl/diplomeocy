namespace Web.Models;

#pragma warning disable CS8618
public class Game {
	public int Id { get; set; }
	public int IdTable { get; set; }
	public string Moves { get; set; } = "";
	public string PlayerCountries { get; set; } = "";
	public string State { get; set; } = "";
}

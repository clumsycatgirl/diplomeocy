
namespace Web.Models;

#pragma warning disable CS8618
class GameViewModel {
	public Game Game { get; set; }
	public Table Table { get; set; }
	public List<Player> Players { get; set; }
}

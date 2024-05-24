
namespace Web.Models;

#pragma warning disable CS8618
class GameViewModel {
	public Game Game { get; set; }
	public User? User { get; set; }
	public string OwnCountry { get; set; }
	public Table Table { get; set; }
	public List<PlayerModel> Players { get; set; }
}

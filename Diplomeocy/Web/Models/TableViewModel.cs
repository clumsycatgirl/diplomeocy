
namespace Web.Models;

public class TableViewModel {
	public class PlayerData {
		public required Models.Player Player;
		public required Models.User User;
	}

	public required Models.Table Table;
	public required Models.TableViewModel.PlayerData[] Players;
	public required Models.Game Game;
}
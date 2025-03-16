using System.ComponentModel.DataAnnotations.Schema;

using Diplomeocy.Database.Models.Types;
using Diplomeocy.Database.Services;

namespace Diplomeocy.Database.Models;

public class Player : NotifierModel {
	[NotMapped]
	private int id;
	public int Id {
		get => id;
		set {
			id = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private int idUser;
	public int IdUser {
		get => idUser;
		set {
			idUser = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private int idTable;
	public int IdTable {
		get => idTable;
		set {
			idTable = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private Country country;
	public Country Country {
		get => country;
		set {
			country = value;
			OnPropertyChanged();
		}
	}
}

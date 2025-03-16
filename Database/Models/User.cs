using System.ComponentModel.DataAnnotations.Schema;

using Diplomeocy.Database.Models.Types;

namespace Diplomeocy.Database.Models;

#pragma warning disable CS8618
public class User : NotifierModel {
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
	private string username;
	public string Username {
		get => username;
		set {
			username = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private string password;
	public string Password {
		get => password;
		set {
			password = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private string pathImage;
	public string PathImage {
		get => pathImage;
		set {
			pathImage = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private Theme theme;
	public Theme Theme {
		get => theme;
		set {
			theme = value;
			OnPropertyChanged();
		}
	}
}

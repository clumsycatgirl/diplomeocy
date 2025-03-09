using Diplomeocy.Database.Models.Types;

namespace Diplomeocy.Database.Models.SessionModels;

public class SessionUser(IHttpContextAccessor httpContextAccessor, string key) : SessionModel<User>(httpContextAccessor, key) {
	public int Id {
		get => Value!.Id;
		set => SetProperty(nameof(Value.Id), value);
	}

	public string Username {
		get => Value!.Username;
		set => SetProperty(nameof(Value.Username), value);
	}

	public string Password {
		get => Value!.Password;
		set => SetProperty(nameof(Value.Password), value);
	}

	public string PathImage {
		get => Value!.PathImage;
		set => SetProperty(nameof(Value.PathImage), value);
	}

	public Theme Theme {
		get => Value!.Theme;
		set => SetProperty(nameof(Value.Theme), value);
	}
}

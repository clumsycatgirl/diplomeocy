
using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;
using Diplomeocy.Web.Exceptions;

namespace Diplomeocy.Database.Services;

public class UserService : BaseService<User> {
	private readonly ILogger<UserService> logger;

	public UserService(ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor, DatabaseContext databaseContext) : base(httpContextAccessor, databaseContext) {
		this.logger = logger;
	}

	public override required string Key { get; init; } = "CurrentUser";

	public User? CurrentUser {
		get => Value;
		set => Value = value;
	}

	public void RequireAuthentication(string? redirectTo = null) {
		if (CurrentUser is null) {
			throw new RedirectException(redirectTo ?? "/Auth");
		}
	}

	protected override void OnFirstLoad(User user) {
		user.PropertyChanged += (sender, args) => {
			httpContextAccessor.HttpContext?.Session.Set(Key, user);
			databaseContext.Users.Update(user);
			databaseContext.SaveChanges();
		};
	}
}


using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;
using Diplomeocy.Web.Exceptions;

using Microsoft.AspNetCore.Identity;

namespace Diplomeocy.Database.Services;

public class UserService {
	private readonly ILogger<UserService> logger;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly DatabaseContext databaseContext;
	private User? user = null;

	public UserService(ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor, DatabaseContext databaseContext) {
		this.logger = logger;
		this.httpContextAccessor = httpContextAccessor;
		this.databaseContext = databaseContext;
	}

	public User? CurrentUser {
		get {
			user ??= httpContextAccessor.HttpContext?.Session.Get<User?>("CurrentUser");
			if (user is not null) {
				user.PropertyChanged += (sender, args) => {
					httpContextAccessor.HttpContext?.Session.Set<User>("CurrentUser", CurrentUser!);
					databaseContext.Users.Update(CurrentUser!);
					databaseContext.SaveChanges();
				};
			}
			return user;
		}
		set {
			user = value;
			httpContextAccessor.HttpContext?.Session.Set<User>("CurrentUser", CurrentUser!);
		}
	}

	public void RequireAuthentication(string? redirectTo = null) {
		if (CurrentUser is null) {
			throw new RedirectException(redirectTo ?? "/Auth");
		}
	}
}

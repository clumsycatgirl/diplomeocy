using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;
using Diplomeocy.Web.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Database.Services;

public class UserService {
	private readonly IHttpContextAccessor httpContextAccessor = default!;

	public UserService(IHttpContextAccessor httpContextAccessor) {
		this.httpContextAccessor = httpContextAccessor;
	}

	public User? CurrentUser {
		get =>
			httpContextAccessor.HttpContext?.Session?.Get<User>("CurrentUser");
		set {
			ISession? session = httpContextAccessor.HttpContext?.Session;
			if (session is null) {
				return;
			}

			if (value is not null) {
				session.Set("CurrentUser", value);
			} else {
				session.Remove("CurrentUser");
			}
		}
	}

	public void RequireAuthentication(string? redirectTo = null) {
		if (CurrentUser is null) {
			throw new RedirectException(redirectTo ?? "/Auth");
		}
	}
}

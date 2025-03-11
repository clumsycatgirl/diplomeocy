//using Diplomeocy.Database.Models;
//using Diplomeocy.Extensions;
//using Diplomeocy.Web.Exceptions;

//namespace Diplomeocy.Database.Services;

//public class UserService {
//	private readonly IHttpContextAccessor httpContextAccessor = default!;

//	public UserService(IHttpContextAccessor httpContextAccessor) {
//		this.httpContextAccessor = httpContextAccessor;
//	}

//	public User? CurrentUser {
//		get =>
//			httpContextAccessor.HttpContext?.Session?.Get<User>("CurrentUser");
//		set {
//			ISession? session = httpContextAccessor.HttpContext?.Session;
//			if (session is null) {
//				return;
//			}

//			if (value is not null) {
//				session.Set("CurrentUser", value);
//			} else {
//				session.Remove("CurrentUser");
//			}
//		}
//	}

//	public void RequireAuthentication(string? redirectTo = null) {
//		if (CurrentUser is null) {
//			throw new RedirectException(redirectTo ?? "/Auth");
//		}
//	}
//}


// using Diplomeocy.Database.Models;
// using Diplomeocy.Database.Models.SessionModels;
// using Diplomeocy.Web.Exceptions;

// namespace Diplomeocy.Database.Services;

// public class UserService {
// 	private readonly IHttpContextAccessor httpContextAccessor;
// 	private SessionUser? user = null;

// 	public UserService(IHttpContextAccessor httpContextAccessor) {
// 		this.httpContextAccessor = httpContextAccessor;
// 	}

// 	public SessionUser? CurrentUser => user;

// 	public void SetUser(User? user) {
// 		this.user = new SessionUser(httpContextAccessor, "CurrentUser");
// 		this.user.Value = user;
// 	}

// 	public void RequireAuthentication(string? redirectTo = null) {
// 		if (CurrentUser is null) {
// 			throw new RedirectException(redirectTo ?? "/Auth");
// 		}
// 	}
// }


using Diplomeocy.Database.Models;
using Diplomeocy.Database.Models.SessionModels;
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

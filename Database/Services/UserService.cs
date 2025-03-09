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


using Diplomeocy.Database.Models;
using Diplomeocy.Database.Models.SessionModels;
using Diplomeocy.Web.Exceptions;

namespace Diplomeocy.Database.Services;

public class UserService {
	private readonly IHttpContextAccessor httpContextAccessor;
	private SessionUser? user = null;

	public UserService(IHttpContextAccessor httpContextAccessor) {
		this.httpContextAccessor = httpContextAccessor;
	}

	public SessionUser? CurrentUser => user;

	public void SetUser(User? user) {
		this.user = new SessionUser(httpContextAccessor, "CurrentUser");
		this.user.Value = user;
	}

	public void RequireAuthentication(string? redirectTo = null) {
		if (CurrentUser is null) {
			throw new RedirectException(redirectTo ?? "/Auth");
		}
	}
}


namespace Diplomeocy.Web.Exceptions;

public class RedirectException : Exception {
	public string RedirectUrl { get; }

	public RedirectException(string redirectUrl)
		: base($"Redirecting to {redirectUrl}") {
		RedirectUrl = redirectUrl;
	}
}

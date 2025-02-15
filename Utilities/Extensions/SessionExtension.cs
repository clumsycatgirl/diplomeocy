using Newtonsoft.Json;

namespace Diplomeocy.Extensions;

public static class SessionExtension {
	public static void Set<T>(this ISession session, string key, T value) {
		session.SetString(key, JsonConvert.SerializeObject(value));
	}

	public static T? Get<T>(this ISession session, string key) {
		string? value = session.GetString(key);
		return value is null ? default : JsonConvert.DeserializeObject<T>(value);
	}
}

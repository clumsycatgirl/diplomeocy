using Newtonsoft.Json;

namespace Web.Utils;

public static class SessionExtension {
	public static void Set<T>(this ISession session, string key, T value) {
		session.SetString(key, JsonConvert.SerializeObject(value));
	}

	public static T? Get<T>(this ISession session, string key) {
		String? value = session.GetString(key);
		return value is null ? default : JsonConvert.DeserializeObject<T>(value);
	}
}

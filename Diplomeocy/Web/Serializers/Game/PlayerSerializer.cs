
using Diplomacy;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web.Serializers.Game;

class PlayerConverter : JsonConverter<Player> {
	public override bool CanRead => base.CanRead;

	public override bool CanWrite => base.CanWrite;

	public override bool Equals(object? obj) {
		return base.Equals(obj);
	}

	public override int GetHashCode() {
		return base.GetHashCode();
	}

	public override Player? ReadJson(JsonReader reader, Type objectType, Player? existingValue, bool hasExistingValue, JsonSerializer serializer) {
		JObject playerObject = JObject.Load(reader);

		Player player = new Player {
			Name = ((string?)playerObject["Name"])!,
			Countries = playerObject["Countries"]!.ToObject<List<Country>>(serializer)!,
			Units = playerObject["Units"]!.ToObject<List<Unit>>(serializer)!
		};

		return player;
	}

	public override string? ToString() {
		return base.ToString();
	}

	public override void WriteJson(JsonWriter writer, Player? value, JsonSerializer serializer) {
		if (value is null) {
			return;
		}

		JObject playerObject = new JObject(
			new JProperty("Name", value.Name),
			new JProperty("Countries", JArray.FromObject(value.Countries.Select(country =>
				new JObject(
					new JProperty("Name", country.Name),
					new JProperty("Territories", JArray.FromObject(country.HomeTerritories.Select(territory =>
						new JObject(
							new JProperty("Name", territory.Name)
						)
					)))
				)
			))),
			new JProperty("Units", JArray.FromObject(value.Units.Select(unit =>
				new JObject(
					new JProperty("Country", unit.Country),
					new JProperty("Type", unit.Type),
					new JProperty("Location", unit.Location?.Name)
				)
			)))
		);

		playerObject.WriteTo(writer);
	}
}
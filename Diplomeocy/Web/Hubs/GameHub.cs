using System.Diagnostics;

using Diplomacy;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Framework;

using Newtonsoft.Json;

namespace Web.Hubs;

public class GameHub : Hub {
	private readonly Dictionary<string, GameHandler> gameHandlers;
	private readonly ILogger<GameHub> logger;

	public GameHub(ILogger<GameHub> logger, Dictionary<string, GameHandler> gameHandlers) : base() {
		this.logger = logger;
		this.gameHandlers = gameHandlers;
	}

	public Task JoinGameGroup(string gameId) {
		Groups.AddToGroupAsync(Context.ConnectionId, gameId);
		return Clients.Client(Context.ConnectionId).SendAsync("JoinGameGroupConfirm", gameId);
	}

	public Task RequestState(string gameId) {
		if (!gameHandlers.TryGetValue(gameId, out GameHandler? handler)) {
			return Clients.Client(Context.ConnectionId).SendAsync("RequestError", $"invalid gameId: '{gameId}'");
		}
		string state = JsonConvert.SerializeObject(handler!.Players, new JsonSerializerSettings {
			Converters = { new Web.Serializers.Game.PlayerConverter() }
		});
		return Clients.Client(Context.ConnectionId).SendAsync("RequestStateResponse", state);
	}
}

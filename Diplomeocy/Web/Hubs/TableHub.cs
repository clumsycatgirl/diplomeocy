
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using Web.Utils;

namespace Web.Hubs;

public class TableHub : Hub {
	private readonly DatabaseContext dbContext;
	private readonly static Dictionary<string, int> GroupCounts = new();

	public TableHub(DatabaseContext dbContext) {
		this.dbContext = dbContext;
	}

	public Task JoinTable(string gameId) {
		GroupCounts.TryAdd(gameId, 0);
		if (GroupCounts[gameId] == 7) return Task.CompletedTask;


		GroupCounts[gameId]++;
		Groups.AddToGroupAsync(Context.ConnectionId, gameId);

		Web.Models.User user = Context.GetHttpContext()!.Session.Get<Web.Models.User>("User")!;

		int tableId = int.Parse(gameId);
		if (!dbContext.Players.Any(player => player.IdTable == tableId && player.IdUser == user.Id)) {
			Clients.OthersInGroup(gameId).SendAsync("UserJoin", user.Username);
		}


		if (GroupCounts[gameId] == 7)
			Clients.Group(gameId).SendAsync("EnableGameStart");

		return Task.CompletedTask;
	}

	public Task LeaveTable(string gameId) {
		GroupCounts[gameId]--;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
	}

	public Task ForceStartGame(string gameId) {
		return Clients.Group(gameId).SendAsync("GetForcedIdiot", $"/Game/{gameId}");
	}
}
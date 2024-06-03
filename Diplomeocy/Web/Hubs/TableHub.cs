
using System.Diagnostics;

using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using Web.Utils;

namespace Web.Hubs;

public class TableHub : Hub {
	private readonly static Dictionary<string, int> GroupCounts = new();

	public Task JoinTable(string gameId) {
		GroupCounts.TryAdd(gameId, 0);
		if (GroupCounts[gameId] == 7) return Task.CompletedTask;

		GroupCounts[gameId]++;
		Groups.AddToGroupAsync(Context.ConnectionId, gameId);

		Web.Models.User user = Context.GetHttpContext()!.Session.Get<Web.Models.User>("User")!;
		Clients.GroupExcept(gameId, Context.ConnectionId).SendAsync("UserJoin", user.Username);

		if (GroupCounts[gameId] == 7)
			Clients.Group(gameId).SendAsync("EnableGameStart");

		return Task.CompletedTask;
	}

	public Task LeaveTable(string gameId) {
		GroupCounts[gameId]--;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
	}
}
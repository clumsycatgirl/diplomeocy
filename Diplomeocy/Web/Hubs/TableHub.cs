
using System.Diagnostics;

using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

namespace Web.Hubs;

public class TableHub : Hub {
	private readonly static Dictionary<string, int> GroupCounts = new();

	public Task JoinTable(string gameId) {
		GroupCounts.TryAdd(gameId, 0);
		if (GroupCounts[gameId] == 7) return Task.CompletedTask;

		GroupCounts[gameId]++;
		Groups.AddToGroupAsync(Context.ConnectionId, gameId);

		if (GroupCounts[gameId] == 7)
			Clients.Group(gameId).SendAsync("EnableGameStart");

		return Task.CompletedTask;
	}

	public Task LeaveTable(string gameId) {
		GroupCounts[gameId]--;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
	}
}
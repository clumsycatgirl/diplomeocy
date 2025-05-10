
using Diplomeocy.Communication.SignalR.Hubs.Messages;

using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

namespace Diplomeocy.Communication.SignalR.Hubs;

public class ChatHub : Hub {
	public static string EndPoint => "/hub/chat";

	public Task JoinGroup(string json) {
		ChatMessage? data = JsonConvert.DeserializeObject<ChatMessage>(json);
		if (data is null || data.Action != ChatMessageAction.JoinGroup) return Task.CompletedTask;
		return Groups.AddToGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task LeaveGroup(string json) {
		ChatMessage? data = JsonConvert.DeserializeObject<ChatMessage>(json);
		if (data is null || data.Action != ChatMessageAction.LeaveGroup) return Task.CompletedTask;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task SendMessage(string json) {
		ChatMessage? data = JsonConvert.DeserializeObject<ChatMessage>(json);
		if (data is null || data.Action != ChatMessageAction.SendMessage) return Task.CompletedTask;
		return Clients.Group(data.Group).SendAsync("ReceiveMessage", json);
	}
}

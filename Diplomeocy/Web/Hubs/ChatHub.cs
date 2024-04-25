using System.Text.Json;

using Microsoft.AspNetCore.SignalR;

namespace Web.Hubs;

public class ChatHub : Hub {
	public class MessageData {
		public enum MessageDataAction { JoinGroup, LeaveGroup, SendMessage, }

		public MessageDataAction Action { get; set; }
		public string Group { get; set; }
		public string Sender { get; set; }
		public string? Message { get; set; }
	}

	public Task JoinGroup(string json) {
		MessageData? data = JsonSerializer.Deserialize<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.JoinGroup) return Task.CompletedTask;
		return Groups.AddToGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task LeaveGroup(string json) {
		MessageData? data = JsonSerializer.Deserialize<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.JoinGroup) return Task.CompletedTask;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task SendMessageToGroup(string json) {
		MessageData? data = JsonSerializer.Deserialize<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.SendMessage) return Task.CompletedTask;
		return Clients.Group(data.Group).SendAsync("ReceiveMessage", data.Sender, data.Message);
	}
}

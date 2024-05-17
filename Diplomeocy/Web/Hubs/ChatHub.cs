using System.Diagnostics;

using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

namespace Web.Hubs;

public class ChatHub : Hub {
	public class MessageData {
		public enum MessageDataAction { JoinGroup, LeaveGroup, SendMessageToGroup, }

		public MessageDataAction Action { get; set; }
		public string Group { get; set; }
		public string Sender { get; set; }
		public string? Message { get; set; }
	}

	public Task JoinGroup(string json) {
		MessageData? data = JsonConvert.DeserializeObject<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.JoinGroup) return Task.CompletedTask;
		return Groups.AddToGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task LeaveGroup(string json) {
		MessageData? data = JsonConvert.DeserializeObject<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.LeaveGroup) return Task.CompletedTask;
		return Groups.RemoveFromGroupAsync(Context.ConnectionId, data.Group);
	}

	public Task SendMessageToGroup(string json) {
		MessageData? data = JsonConvert.DeserializeObject<MessageData>(json);
		if (data is null || data.Action != MessageData.MessageDataAction.SendMessageToGroup) return Task.CompletedTask;
		return Clients.Group(data.Group).SendAsync("ReceiveMessage", json);
	}

	public Task SendVoiceSignal(string signal) {
		Debug.WriteLine($"Received voice signal: {signal}");
		return Clients.All.SendAsync("ReceiveVoiceSignal", signal);
	}
}

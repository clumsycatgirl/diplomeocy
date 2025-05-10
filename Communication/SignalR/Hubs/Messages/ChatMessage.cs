
namespace Diplomeocy.Communication.SignalR.Hubs.Messages;

#pragma warning disable CS8618
public class ChatMessage {
	public ChatMessageAction Action { get; set; }
	public string Group { get; set; }
	public string? Sender { get; set; }
	public string? Message { get; set; }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Web.Middleware;

public class WebSocketMiddlerware {
	public static async Task Execute(HttpContext context, Func<Task> next) {
		if (!context.WebSockets.IsWebSocketRequest) {
			await next();
			return;
		}

		WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
		await HandleWebSocketCommunication(webSocket);
	}

	private static async Task HandleWebSocketCommunication(WebSocket webSocket) {
		byte[] buffer = new byte[1024 * 1024];
		WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);


		while (!result.CloseStatus.HasValue) {
			Debug.WriteLine($"count={result.Count}");
			await webSocket.SendAsync(
				new ArraySegment<byte>(buffer, 0, result.Count),
				result.MessageType,
				result.EndOfMessage,
				CancellationToken.None);

			result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
			Array.Clear(buffer);
		}

		await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
	}
}

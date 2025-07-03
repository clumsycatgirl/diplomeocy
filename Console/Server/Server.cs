using System.Net.Sockets;
using System.Text;

using Diplomeocy.Collections;

namespace Diplomeocy.Console.Server;

public class Server {
	private readonly TcpListener _listener;
	private readonly SynchronizedList<TcpClient> _clients;

	public static readonly int Port = 65535;

	public Server() {
		_listener = new TcpListener(System.Net.IPAddress.Any, Port);
		_clients = [];
	}

	public void Start() {
		_listener.Start();

		Task.Run(async () => {
			while (true) {
				TcpClient client = await _listener.AcceptTcpClientAsync();
				_clients.Add(client);

				_ = HandleClientAsync(client);
			}
		});
	}

	public async Task HandleClientAsync(TcpClient client) {
		using NetworkStream stream = client.GetStream();
		byte[] buffer = new byte[1024];
		string endpoint = client.Client.RemoteEndPoint?.ToString() ?? "Unknown";

		while (true) {
			int byteCount;
			try {
				byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
				if (byteCount == 0) break;
			} catch {
				break;
			}

			string message = Encoding.UTF8.GetString(buffer, 0, byteCount);

			string response = ""; // <-- process message

			byte[] responseBytes = Encoding.UTF8.GetBytes(response);
			await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
		}
	}
}

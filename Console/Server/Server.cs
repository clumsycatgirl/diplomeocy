using System.Net.Sockets;
using System.Text;

using Diplomeocy.Collections;

namespace Diplomeocy.Console.Server;

public class Server {
	private readonly TcpListener _listener;
	private Task? _listenerTask = null;
	private bool _running = true;
	private readonly SynchronizedList<TcpClient> _clients;

	public int Port = 65535;

	public event Action? OnStart;
	public event Action<TcpClient>? OnNewConnection;

	public Server() {
		_listener = new TcpListener(System.Net.IPAddress.Any, Port);
		_clients = [];
	}

	public virtual void Start() {
		_listener.Start();
		OnStart?.Invoke();

		_listenerTask = Task.Run(async () => {
			while (_running) {
				TcpClient client = await _listener.AcceptTcpClientAsync();
				_clients.Add(client);

				OnNewConnection?.Invoke(client);

				_ = HandleClientAsync(client);
			}
		});
	}

	public virtual async void Stop() {
		_running = false;
		if (_listenerTask is not null) await _listenerTask;
		_listener.Stop();
	}

	public virtual async Task HandleClientAsync(TcpClient client) {
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

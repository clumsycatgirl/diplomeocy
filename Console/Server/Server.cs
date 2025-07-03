using System.Net.Sockets;
using System.Text;

using Diplomeocy.Collections;
using Diplomeocy.Console.Server.Data;

using Newtonsoft.Json;

namespace Diplomeocy.Console.Server;

public class Server {
	private readonly TcpListener _listener;
	private Task? _listenerTask = null;
	private bool _running = true;
	private readonly SynchronizedList<ClientData> _clients;

	public int Port = 65535;

	public event Action? OnStart;
	public event Action<ClientData>? OnNewConnection;
	public event Action<ClientData>? OnConnectionEnd;
	public event Action<ClientData, string>? OnMessage;

	private static int _idCounter = 0;

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
				ClientData data = new ClientData {
					Id = _idCounter++,
					TcpClient = client
				};
				_clients.Add(data);

				OnNewConnection?.Invoke(data);

				_ = HandleClientAsync(data);
			}
		});
	}

	public virtual async void Stop() {
		_running = false;
		if (_listenerTask is not null) await _listenerTask;
		_listener.Stop();
	}

	public virtual async Task HandleClientAsync(ClientData data) {
		using NetworkStream stream = data.TcpClient.GetStream();

		string endpoint = data.TcpClient.Client.RemoteEndPoint?.ToString() ?? "Unknown";

		while (true) {
			(string? Message, bool Failure) messageData = await ReadMessage(stream);
			if (messageData.Failure) break;

			string response = HandleCommand(data, messageData.Message!);
			data.Messages.Add(messageData.Message!);
			OnMessage?.Invoke(data, messageData.Message!);

			await Sendmessage(stream, response);
		}

		OnConnectionEnd?.Invoke(data);
	}

	protected static byte[] buffer = new byte[1024];
	private async Task<(string? Response, bool Failure)> ReadMessage(NetworkStream stream) {
		(string? Response, bool Failure) ret = (null, false);
		int byteCount;

		try {
			byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
			if (byteCount == 0) ret.Failure = true;
		} catch {
			ret.Failure = true;
			return ret;
		}

		ret.Response = Encoding.UTF8.GetString(buffer, 0, byteCount);

		return ret;
	}

	private async Task Sendmessage(NetworkStream stream, string message) {
		byte[] data = Encoding.UTF8.GetBytes(message);
		await stream.WriteAsync(data, 0, data.Length);
	}

	private string HandleCommand(ClientData client, string data) {
		Command? command = JsonConvert.DeserializeObject<Command>(data);
		if (command is null) return Error;

		switch (command.Kind) {
			case "JoinGroup":
				JoinGroupCommand? joinGroupCommand = JsonConvert.DeserializeObject<JoinGroupCommand>(data);
				if (joinGroupCommand is null) return Error;

				client.Group = joinGroupCommand.Group;
				break;
			default:
				return Error;
		}

		return Success;
	}

	protected string Success => "{\"success\":\"yay\"}";
	protected string Error => "{\"error\":\"nyo\"}";
}

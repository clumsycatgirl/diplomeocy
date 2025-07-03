using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

using Diplomeocy.Console.Client.Data;

using Newtonsoft.Json;

namespace Diplomeocy.Console.Client;

using Console = System.Console;

public class Client {
	private readonly TcpClient _client;
	private NetworkStream _stream;
	private readonly string _host;
	private readonly int _port;

	private bool _running = false;

	public Client(string host = "127.0.0.1", int port = 65535) {
		_client = new TcpClient();
		_host = host;
		_port = port;
	}

	public async Task StartAsync() {
		_running = true;

		try {
			await _client.ConnectAsync(_host, _port);
			_stream = _client.GetStream();

			Console.WriteLine($"Connected to server at {_host}:{_port}");
			_ = ListenForServerMessagesAsync();

			while (_running) {
				System.Console.Write(">");
				string? input = Console.ReadLine()?.Trim().ToLower();

				HandleCommand(input);
			}
		} catch (Exception ex) {
			Console.WriteLine($"Connection error: {ex.Message}");
		} finally {
			_stream?.Close();
			_client?.Close();
		}
	}

	protected static byte[] buffer = new byte[1024];
	private async Task ListenForServerMessagesAsync() {
		try {
			while (true) {
				(string? Response, bool Failure) data = await ReadMessage();
				if (data.Failure) {
					break;
				}

				string response = data.Response;

				HandleResponse(response);
			}
		} catch {
			Console.WriteLine("Disconnected from server.");
		}
	}

	private void HandleCommand(string? command) {
		if (command is null) {
			_running = false;
			return;
		}

		string[] splits = command.Split(' ');
		switch (splits[0]) {
			case "exit":
				_running = false;
				break;
			case "send":
				string message = String.Join(" ", splits.Skip(1));
				Sendmessage(message);
				break;
			case "join":
				string group = splits[1];
				Sendmessage(new JoinGroupCommand {
					Group = group
				});
				break;
		}
	}

	private void HandleResponse(string response) {
		System.Console.WriteLine($"Received '{response}'");
	}

	private async Task<(string? Response, bool Failure)> ReadMessage() {
		(string? Response, bool Failure) ret = (null, false);
		int byteCount;

		try {
			byteCount = await _stream.ReadAsync(buffer, 0, buffer.Length);
			if (byteCount == 0) ret.Failure = true;
		} catch {
			ret.Failure = true;
			return ret;
		}

		ret.Response = Encoding.UTF8.GetString(buffer, 0, byteCount);

		return ret;
	}

	protected async Task Sendmessage(string message) {
		byte[] data = Encoding.UTF8.GetBytes(message);
		await _stream.WriteAsync(data, 0, data.Length);
	}

	protected async Task Sendmessage(Command command) {
		string message = JsonConvert.SerializeObject(command);
		byte[] data = Encoding.UTF8.GetBytes(message);
		await _stream.WriteAsync(data, 0, data.Length);
	}
}

using System.Net.Sockets;
using System.Text;

namespace Diplomeocy.Console.Client;

using Console = System.Console;

public class Client {
	private readonly TcpClient _client;
	private NetworkStream _stream;
	private readonly string _host;
	private readonly int _port;

	public Client(string host = "127.0.0.1", int port = 65535) {
		_client = new TcpClient();
		_host = host;
		_port = port;
	}

	public async Task StartAsync() {
		try {
			await _client.ConnectAsync(_host, _port);
			_stream = _client.GetStream();

			Console.WriteLine($"Connected to server at {_host}:{_port}");
			_ = ListenForServerMessagesAsync();

			while (true) {
				string? input = Console.ReadLine();
				if (input == null || input.ToLower() == "exit") break;

				byte[] data = Encoding.UTF8.GetBytes(input);
				await _stream.WriteAsync(data, 0, data.Length);
			}
		} catch (Exception ex) {
			Console.WriteLine($"Connection error: {ex.Message}");
		} finally {
			_stream?.Close();
			_client?.Close();
		}
	}

	private async Task ListenForServerMessagesAsync() {
		byte[] buffer = new byte[1024];

		try {
			while (true) {
				int byteCount = await _stream.ReadAsync(buffer, 0, buffer.Length);
				if (byteCount == 0) break;

				string response = Encoding.UTF8.GetString(buffer, 0, byteCount);
				Console.WriteLine($"[Server]: {response}");
			}
		} catch {
			Console.WriteLine("Disconnected from server.");
		}
	}
}

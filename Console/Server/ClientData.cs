using System.Net.Sockets;

namespace Diplomeocy.Console.Server;

public class ClientData {
	public required int Id { get; init; }
	public required TcpClient TcpClient { get; init; }
	public string Group { get; set; } = "";
	public List<string> Messages { get; set; } = [];
}
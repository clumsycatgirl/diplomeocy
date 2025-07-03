namespace Diplomeocy.Console.Client;

internal class Program {
	static void Main(string[] args) {
		Client client = new();
		client.StartAsync().Wait();
	}
}

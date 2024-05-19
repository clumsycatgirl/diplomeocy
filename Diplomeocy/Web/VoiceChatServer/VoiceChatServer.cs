using System.Net.Sockets;

namespace Web.VoiceChatServer;

public class VoiceChatServer {
	public readonly int Port;
	private readonly UdpClient udpClient;

	// don't run this with terraria
	public VoiceChatServer(int port = 7777) {
		Port = port;
		udpClient = new UdpClient(Port);
	}

	public async Task StartAsync() {
	start:

		UdpReceiveResult receivedResult = await udpClient.ReceiveAsync();

		await udpClient.SendAsync(receivedResult.Buffer, receivedResult.Buffer.Length, receivedResult.RemoteEndPoint);

		goto start;
	}

	public void Stop() {
		udpClient.Close();
	}
}

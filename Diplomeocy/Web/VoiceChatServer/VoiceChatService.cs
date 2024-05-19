using System.Diagnostics.CodeAnalysis;

namespace Web.VoiceChatServer;

public class VoiceChatService {
	private VoiceChatServer voiceChatServer;

	public VoiceChatService() {
		voiceChatServer = new();
	}

	public async Task StartAsync() {
		await voiceChatServer.StartAsync();
	}

	public void Stop() {
		voiceChatServer.Stop();
	}
}

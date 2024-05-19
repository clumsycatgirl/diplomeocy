using Microsoft.AspNetCore.SignalR;

namespace Web.Hubs;

public class VoiceChatHub : Hub {
	private readonly ILogger<VoiceChatHub> logger;

	public VoiceChatHub(ILogger<VoiceChatHub> logger) {
		this.logger = logger;
		this.logger.LogInformation("Instantiated VoiceChatHub");
	}

	public Task Send(string audio) {
		//logger.LogDebug($"{audio}; content-type={(audio as IFormFile)?.ContentType}; length={(audio as IFormFile)?.Length}");
		return Clients.All.SendAsync("Receive", audio);
	}
}

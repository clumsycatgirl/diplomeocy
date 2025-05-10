using Diplomeocy.Database.Models;
using Diplomeocy.Database.Models.Types;

using Microsoft.EntityFrameworkCore;

namespace Diplomeocy.Database.Services;

public class ChannelService {
	private readonly DatabaseContext context;
	private readonly PlayerService playerService;
	private readonly ILogger<ChannelService> logger;

	public ChannelService(ILogger<ChannelService> logger, DatabaseContext context, PlayerService playerService) {
		this.context = context;
		this.playerService = playerService;
		this.logger = logger;
	}

	private string? channel = null;
	public string? Channel {
		get {
			if (playerService.CurrentPlayer is null) return null;
			if (channel is null) {
				Message? latestJoin = context.Messages
					.Where(m => m.Sender == playerService.CurrentPlayer.Id)
					.Where(m => m.Type == MessageType.Join)
					.OrderByDescending(m => m.Id)
					.FirstOrDefault();
				Message? latestLeave = context.Messages
					.Where(m => m.Sender == playerService.CurrentPlayer.Id)
					.Where(m => m.Type == MessageType.Leave)
					.OrderByDescending(m => m.Id)
					.FirstOrDefault();
				// Message? latestJoin = null, latestLeave = null;

				logger.LogInformation($"last-join={latestJoin?.Id}, last-leave={latestLeave?.Id}");

				if (latestJoin is not null) {
					channel = latestLeave is not null && latestLeave.Channel == latestJoin.Channel
						? null
						: latestJoin.Channel;
				}
			}
			return channel;
		}
		set {
			playerService.RequireValidPlayer();
			JoinChannel(value);
		}
	}

	public async Task JoinChannelAsync(string? channel) {
		if (Channel == channel) return;
		await LeaveChannelAsync();
		this.channel = channel;
		if (this.channel is not null)
			await SendMessageAsync(MessageType.Join, "");
	}

	public void JoinChannel(string? channel) {
		if (Channel == channel) return;
		LeaveChannel();
		this.channel = channel;
		if (this.channel is not null)
			SendMessage(MessageType.Join, "");
	}

	public async Task LeaveChannelAsync() {
		if (Channel is null) return;
		await SendMessageAsync(MessageType.Leave, "");
		channel = null;
	}

	public void LeaveChannel() {
		if (channel is null) return;
		SendMessage(MessageType.Leave, "");
		channel = null;
	}

	public Task<List<Message>> GetChannelMessagesAsync() {
		return context.Messages
			.Where(m => m.Channel == Channel)
			.ToListAsync();
	}

	public async Task<List<Message>> GetChannelMessagesAsync(string channel) {
		await JoinChannelAsync(channel);
		return await GetChannelMessagesAsync();
	}

	public List<Message> GetChannelMessages() {
		return context.Messages
			.Where(m => m.Channel == Channel)
			.ToList();
	}

	public List<Message> GetChannelMessages(string channel) {
		JoinChannel(channel);
		return GetChannelMessages();
	}

	public async Task<List<User>> GetActiveChannelMembers() {
		RequireValidChannel();

		return await context.Messages
			.Where(m => m.Channel == Channel)
			.Join(context.Players,
				message => message.Sender,
				player => player.Id,
				(message, player) => new { message, player })
			.Join(context.Users,
				data => data.player.IdUser,
				user => user.Id,
				(data, user) => new { data.message, data.player, user })
			.GroupBy(data => data.user.Id)
			.Select(group => group
				.OrderByDescending(data => data.message.CreatedAt)
				.First())
			.Where(data => data.message.Type == MessageType.Join)
			.Select(data => data!.user)
			.ToListAsync();
	}

	public async Task<List<User>> GetActiveChannelMembers(string channel) {
		await JoinChannelAsync(channel);
		return await GetActiveChannelMembers();
	}

	public async Task<List<User>> GetChannelMembers() {
		RequireValidChannel();
		return await context.Messages
			.Where(m => m.Channel == Channel)
			.Join(context.Players,
				message => message.Sender,
				player => player.Id,
				(message, player) => new { message, player })
			.Join(context.Users,
				data => data.player.IdUser,
				user => user.Id,
				(data, user) => new { data.message, data.player, user })
			.GroupBy(data => data.user.Id)
			.Select(group => group
				.OrderByDescending(data => data.message.CreatedAt)
				.First())
			.Where(data => data.message.Type == MessageType.Join)
			.Select(data => data!.user)
			.ToListAsync();
	}

	public async Task<List<User>> GetChannelMembers(string channel) {
		await JoinChannelAsync(channel);
		return await GetChannelMembers();
	}

	public async Task SendMessageAsync(MessageType type, string data) {
		RequireValidChannel();

		Message message = new() {
			Channel = Channel!,
			IdTable = playerService.CurrentPlayer!.IdTable,
			Sender = playerService.CurrentPlayer!.Id,
			Type = type,
			Data = data,
		};

		await context.Messages.AddAsync(message);
		await context.SaveChangesAsync();
	}

	public async Task SendMessageAsync(string channel, MessageType type, string data) {
		await JoinChannelAsync(channel);
		await SendMessageAsync(type, data);
	}

	public void SendMessage(MessageType type, string data) {
		RequireValidChannel();

		Message message = new() {
			Channel = Channel!,
			IdTable = playerService.CurrentPlayer!.IdTable,
			Sender = playerService.CurrentPlayer!.Id,
			Type = type,
			Data = data,
		};

		context.Messages.Add(message);
		context.SaveChanges();
	}

	public void SendMessage(string channel, MessageType type, string data) {
		JoinChannel(channel);
		SendMessage(type, data);
	}

	public void RequireValidChannel() {
		playerService.RequireValidPlayer();
		if (Channel is null) {
			throw new Exception("Calling channel methods without a valid channel");
		}
	}
}

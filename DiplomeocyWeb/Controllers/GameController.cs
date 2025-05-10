using Diplomeocy.Database;
using Diplomeocy.Database.Extensions;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;
using Diplomeocy.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;

public class GameController : Controller {
	private readonly ILogger<GameController> logger;
	private readonly DatabaseContext context;
	private readonly TablesService tablesService;
	private readonly UserService userService;
	private readonly PlayerService playerService;
	private readonly ChannelService channelService;

	public GameController(ILogger<GameController> logger, DatabaseContext context, TablesService tablesService, UserService userService, PlayerService playerService, ChannelService channelService) {
		this.logger = logger;
		this.context = context;
		this.tablesService = tablesService;
		this.userService = userService;
		this.playerService = playerService;
		this.channelService = channelService;
	}

	[HttpGet]
	[Route("/Game/{table?}")]
	public IActionResult Index(int table) {
		tablesService.RequireValidTable(table);
		playerService.RequireValidPlayer();

		channelService.JoinChannel("test");

		tablesService.CurrentTable = tablesService.Tables.First(t => t.Id == table);

		List<Player> players = tablesService.CurrentTable.Players(context).ToList();

		return View(new GameViewModel {
			TablesService = tablesService,
			Players = players,
			Context = context,
			ChannelService = channelService,
		});
	}
}

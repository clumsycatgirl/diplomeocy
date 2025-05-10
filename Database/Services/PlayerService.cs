using Diplomeocy.Database.Extensions;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Models.Types;
using Diplomeocy.Web.Exceptions;

namespace Diplomeocy.Database.Services;

public class PlayerService : BaseService<Player> {
	private readonly ILogger<PlayerService> logger;
	private readonly UserService userService;
	private readonly TablesService tablesService;

	public PlayerService(ILogger<PlayerService> logger, DatabaseContext databaseContext, UserService userService, TablesService tablesService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, databaseContext) {
		this.logger = logger;
		this.userService = userService;
		this.tablesService = tablesService;
	}

	public override required string Key { get; init; } = "CurrentPlayer";
	public Player? CurrentPlayer {
		get => Value;
		set => Value = value;
	}

	public Player CreatePlayer() {
		tablesService.RequireValidTable();

		Player? player = databaseContext.Players.FirstOrDefault((p) => p.IdUser == userService.CurrentUser!.Id && p.IdTable == tablesService.CurrentTable!.Id);
		if (player is null) {
			IEnumerable<Player> players = tablesService.CurrentTable!.Players(databaseContext);

			Country country = (Country)tablesService.CurrentTable!.GetRandomAvailableCountry(databaseContext)!;

			player = new Player {
				IdTable = tablesService.CurrentTable!.Id,
				IdUser = userService.CurrentUser!.Id,
				Country = country,
			};
			databaseContext.Players.Add(player);
			databaseContext.SaveChanges();
		}

		CurrentPlayer = player;

		return player;
	}

	public void RequireValidPlayer() {
		userService.RequireAuthentication();
		tablesService.RequireValidTable();

		CurrentPlayer = databaseContext.Players.FirstOrDefault(p => p.IdTable == tablesService.CurrentTable!.Id && p.IdUser == userService.CurrentUser!.Id);
		if (CurrentPlayer is null) {
			throw new RedirectException("/Tables");
		}
	}
}

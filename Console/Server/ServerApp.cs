using System.Net.Sockets;
using System.Text;

using ClumsyCatGui;

namespace Diplomeocy.Console.Server;

public class ServerApp {
	public static ServerApp Instance { get; private set; }
	private readonly Server server;
	private readonly UIApp app;

	public ServerApp(int port) {
		if (Instance is not null) throw new Exception("ServerApp already instantiated");
		Instance = this;
		server = new Server {
			Port = port
		};
		server.OnStart += () => {
			Log("Server started");
		};
		server.OnNewConnection += (TcpClient client) => {
			Log($"New connection from {client.Client.RemoteEndPoint}");

			Panel clientsContainer = app!.GetById<Panel>("ClientsContainer")!;
			int index = (clientsContainer.Children.LastOrDefault()?.Y ?? 0) + 1;
			clientsContainer.Add(new Button {
				X = 1,
				Width = clientsContainer.Width - 4,
				Text = $"({index}) {client.Client.RemoteEndPoint}",
				OnClickAction = () => {
					Log($"({index}) {client.Client.RemoteEndPoint}");
				}
			});

			clientsContainer.Render(app.Renderer);
		};

		app = new UIApp();
		CreateApp();
	}

	~ServerApp() {
		server.Stop();
	}

	public void Run() {
		Task uiTask = Task.Run(() => {
			app.Run();
		});
		Task.Delay(100);

		server.Start();

		Log("a", "b", "c", "d", "e", "f", "g", "h");

		uiTask.Wait();
	}

	private void CreateApp() {
		Panel serverInfo = new Panel {
			X = System.Console.WindowWidth - 24,
			Y = 1,
			Width = 24,
			Height = 3,
			Title = "Address",
			Style = new Style { Foreground = ConsoleColor.DarkMagenta },
			Padding = 1,
			Children = [
				new Label {
					X = (24 - $"127.0.0.1:{server.Port}".Length) / 2 - 1,
					Text = $"127.0.0.1/{server.Port}",
					Style = new Style {
						Foreground = ConsoleColor.White,
					},
				},
			]
		};
		Panel topbar = new Panel {
			Id = "Console",
			X = 1,
			Y = 1,
			Height = 3,
			Width = System.Console.WindowWidth - serverInfo.Width - 2,
			Title = "Server Console",
			Style = new Style {
				Foreground = ConsoleColor.Magenta,
			},
			Children = [
				new Label {
					Id = "ConsoleOutput",
					X = 1,
					Text = "meow~ :3",
					Style = new Style {
						Foreground = ConsoleColor.White,
					}
				},
			],
		};
		Panel sidebar = new ScrollPanel {
			Id = "ClientsContainer",
			X = 1,
			Y = 4,
			Width = System.Console.WindowWidth / 5,
			Height = System.Console.WindowHeight - topbar.Height - 2,
			Title = "Clients",
			Style = new Style {
				Foreground = ConsoleColor.Blue,
			},
			ScrollbarStyle = new Style { Foreground = ConsoleColor.DarkBlue },
		};
		Panel commandBar = new Panel {
			X = sidebar.X + sidebar.Width + 1,
			Y = System.Console.WindowHeight - 10 - 1,
			Width = System.Console.WindowWidth - sidebar.Width - 3,
			Height = 10,
			Title = "Commands",
			Style = new Style { Foreground = ConsoleColor.Green }
		};
		Panel content = new Panel {
			X = sidebar.X + sidebar.Width + 1,
			Y = topbar.Height + 1,
			Width = System.Console.WindowWidth - sidebar.Width - 3,
			Height = System.Console.WindowHeight - topbar.Height - commandBar.Height - 2,
			Title = "Content",
			Style = new Style { Foreground = ConsoleColor.White },
		};

		app.Add(serverInfo, sidebar, topbar, commandBar, content);
	}

	public static void Log(params string[] messages) {
		if (Instance is null || Instance.app is null) return;
		Task.Run(async () => {
			foreach (string message in messages) {
				Label label = Instance.app.GetById<Label>("ConsoleOutput")!;
				label.Text = message;

				Panel container = Instance.app.GetById<Panel>("Console")!;
				container.Render(Instance.app.Renderer);

				await Task.Delay(250);
			}
		});
	}
}

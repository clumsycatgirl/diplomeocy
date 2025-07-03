using System.Net.Sockets;

using ClumsyCatGui;

using Diplomeocy.Console.Server;

namespace Server;

internal class Program {
	private static void Main(string[] args) {
		UIApp app = new();

		Label portLabel = new Label {
			X = 2,
			Y = 1,
			Text = "Port: ",
		};
		TextBox portInput = new TextBox {
			X = portLabel.X + portLabel.Width + 1,
			Y = portLabel.Y,
			Width = 20,
			Height = 1,
			Text = "65535",
			KeyFilter = (char key) => int.TryParse(key.ToString(), out int parsed),
		};

		Button confirmButton = new Button {
			X = 2,
			Y = 2,
			Width = 10,
			Height = 1,
			Text = "Start",
			OnClickAction = () => {
				try {
					ServerApp serverApp = new(int.Parse(portInput.Text));
					serverApp.Run();
				} catch (Exception) {
					ServerApp.Instance.Run();
					throw;
				}
			},
		};
		Button exit = new Button {
			X = 2,
			Y = 3,
			Width = 10,
			Height = 1,
			Text = "Exit",
			OnClickAction = app.Stop,
		};

		Panel main = new Panel {
			X = 1,
			Y = 1,
			Width = Console.WindowWidth - 2,
			Height = Console.WindowHeight - 2,
			Title = "CCG Server",
			Children = [
				portLabel,
				portInput,
				confirmButton,
				exit,
			],
			Style = new Style {
				Foreground = ConsoleColor.White,
			},
		};
		app.Add(main);
		app.Run();
	}

	private static void TestServer() {
		Diplomeocy.Console.Server.Server server = new Diplomeocy.Console.Server.Server {
			Port = 65535,
		};
		server.OnStart += () => {
			Console.WriteLine("server started");
		};
		server.OnNewConnection += (TcpClient client) => {
			Console.WriteLine($"new connection from {client.Client.RemoteEndPoint}");
		};

		server.Start();
		Console.ReadKey();
		server.Stop();
	}

	private static void TestGui() {
		UIApp app = new();

		Panel mainPanel = new Panel {
			X = 0,
			Y = 0,
			Width = Console.WindowWidth,
			Height = Console.WindowHeight,
			Title = "Main Menu",
			Style = ThemeManager.Get("Border")
		};

		Panel homePage = new Panel { X = 2, Y = 2, Width = 50, Height = 15, Title = "Home Page" };
		Panel settingsPage = new Panel { X = 2, Y = 2, Width = 50, Height = 15, Title = "Settings" };

		Label welcomeLabel = new Label { X = 2, Y = 1, Width = 46, Text = "Welcome to ClumsyCatGui Console UI!" };
		TextBox input = new TextBox { X = 2, Y = 4, Width = 20, Text = "Input something" };
		Button gotoSettingsBtn = new Button {
			X = 2, Y = 3, Width = 20, Text = "Go to Settings",
			OnClickAction = () => {
				mainPanel.Children.Clear();
				mainPanel.Children.Add(settingsPage);
				settingsPage.ResetFocus();
			}
		};
		homePage.Children.Add(welcomeLabel);
		homePage.Children.Add(input);
		homePage.Children.Add(gotoSettingsBtn);

		ScrollPanel scrollPanel = new ScrollPanel {
			X = 55,
			Y = 1,
			Width = 30,
			Height = 15,
			Title = "Scrollable List",
		};
		for (int i = 0; i < 30; i++) {
			scrollPanel.Children.Add(new Label { X = 1, Y = i, Width = 28, Text = $"Item #{i + 1}" });
		}
		homePage.Children.Add(scrollPanel);

		Checkbox checkbox = new Checkbox { X = 2, Y = 1, Width = 30, Label = "Enable Feature X" };
		Button backBtn = new Button {
			X = 2, Y = 3, Width = 10, Text = "Back",
			OnClickAction = () => {
				mainPanel.Children.Clear();
				mainPanel.Children.Add(homePage);
				homePage.ResetFocus();
			}
		};
		settingsPage.Children.Add(checkbox);
		settingsPage.Children.Add(backBtn);

		mainPanel.Children.Add(homePage);
		mainPanel.ResetFocus();

		app.Add(mainPanel);

		app.Run();
	}
}

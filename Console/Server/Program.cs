using ClumsyCatGui;

namespace Server;

internal class Program {
	static void Main(string[] args) {
		var app = new UIApp();

		// Main Panel (layout container)
		var mainPanel = new Panel {
			X = 0,
			Y = 0,
			Width = Console.WindowWidth,
			Height = Console.WindowHeight,
			Title = "Main Menu",
			Style = ThemeManager.Get("Border")
		};

		// Subpage panels for different screens
		var homePage = new Panel { X = 2, Y = 2, Width = 50, Height = 15, Title = "Home Page" };
		var settingsPage = new Panel { X = 2, Y = 2, Width = 50, Height = 15, Title = "Settings" };

		// Add components to Home Page
		var welcomeLabel = new Label { X = 2, Y = 1, Width = 46, Text = "Welcome to ClumsyCatGui Console UI!" };
		var gotoSettingsBtn = new Button {
			X = 2, Y = 3, Width = 20, Text = "Go to Settings",
			OnClickAction = () => {
				mainPanel.Children.Clear();
				mainPanel.Children.Add(settingsPage);
				settingsPage.ResetFocus();
			}
		};
		homePage.Children.Add(welcomeLabel);
		homePage.Children.Add(gotoSettingsBtn);

		// Scroll Panel example inside Home Page
		var scrollPanel = new ScrollPanel {
			X = 55,
			Y = 1,
			Width = 30,
			Height = 15,
			Title = "Scrollable List"
		};
		for (int i = 0; i < 30; i++) {
			scrollPanel.Children.Add(new Label { X = 1, Y = i, Width = 28, Text = $"Item #{i + 1}" });
		}
		homePage.Children.Add(scrollPanel);

		// Add components to Settings Page
		var checkbox = new Checkbox { X = 2, Y = 1, Width = 30, Label = "Enable Feature X" };
		var backBtn = new Button {
			X = 2, Y = 3, Width = 10, Text = "Back",
			OnClickAction = () => {
				mainPanel.Children.Clear();
				mainPanel.Children.Add(homePage);
				homePage.ResetFocus();
			}
		};
		settingsPage.Children.Add(checkbox);
		settingsPage.Children.Add(backBtn);

		// Add initial children to main panel
		mainPanel.Children.Add(homePage);
		mainPanel.ResetFocus();

		// Add main panel to app
		app.AddComponent(mainPanel);

		app.Run();
	}
}

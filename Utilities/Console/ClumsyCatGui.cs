using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

using Microsoft.AspNetCore.Components.RenderTree;

namespace ClumsyCatGui;

public interface IRenderable {
	void Render(ConsoleRenderer renderer);
}

public interface IInputHandler {
	bool HandleInput(ConsoleKeyInfo keyInfo);
}

public class Style {
	public ConsoleColor? Foreground { get; set; }
	public ConsoleColor? Background { get; set; }
	public bool Bold { get; set; }

	public Style(ConsoleColor? fg = null, ConsoleColor? bg = null, bool bold = false) {
		Foreground = fg;
		Background = bg;
		Bold = bold;
	}
}

public static class ThemeManager {
	private static readonly Dictionary<string, Style> _themes = new Dictionary<string, Style>() {
		["Default"] = new Style(ConsoleColor.White, ConsoleColor.Black),
		["Highlight"] = new Style(ConsoleColor.Black, ConsoleColor.White, true),
		["Border"] = new Style(ConsoleColor.DarkGray, ConsoleColor.Black),
		["Scrollbar"] = new Style(ConsoleColor.DarkGray, ConsoleColor.DarkBlue),
		["Title"] = new Style(ConsoleColor.Cyan, ConsoleColor.Black, true),
		["Button"] = new Style(ConsoleColor.Green, ConsoleColor.Black),
		["ButtonHighlight"] = new Style(ConsoleColor.Black, ConsoleColor.Green, true),
		["Checkbox"] = new Style(ConsoleColor.Yellow, ConsoleColor.Black),
		["Textbox"] = new Style(ConsoleColor.White, ConsoleColor.DarkGray),
		["TextboxFocus"] = new Style(ConsoleColor.Black, ConsoleColor.Gray),
		["PanelBorder"] = new Style(ConsoleColor.DarkGray, ConsoleColor.Black)
	};

	private static string _currentTheme = "Default";

	public static Style GetCurrent() => _themes[_currentTheme];
	public static Style GetHighlight() => _themes["Highlight"];
	public static Style Get(string name) => _themes.TryGetValue(name, out Style s) ? s : GetCurrent();
}

public class ConsoleRenderer {
	private readonly object _lock = new object();

	private static ConsoleColor ToBright(ConsoleColor color) => color switch {
		ConsoleColor.Black => ConsoleColor.DarkGray,
		ConsoleColor.DarkBlue => ConsoleColor.Blue,
		ConsoleColor.DarkGreen => ConsoleColor.Green,
		ConsoleColor.DarkCyan => ConsoleColor.Cyan,
		ConsoleColor.DarkRed => ConsoleColor.Red,
		ConsoleColor.DarkMagenta => ConsoleColor.Magenta,
		ConsoleColor.DarkYellow => ConsoleColor.Yellow,
		ConsoleColor.Gray => ConsoleColor.White,
		_ => color,
	};

	public void Clear() {
		Clear(0, 0, Console.WindowWidth, Console.WindowHeight);
	}

	public void Clear(int top, int left, int width, int height) {
		lock (_lock) {
			int cursorTop = Console.CursorTop;
			int cursorLeft = Console.CursorLeft;

			for (int y = top; y < top + height; y++) {
				Console.SetCursorPosition(left, y);
				Console.Write(new string(' ', width));
			}

			Console.SetCursorPosition(cursorLeft, cursorTop);
		}
	}

	public void DrawText(int x, int y, string text, Style? style = null) {
		lock (_lock) {
			Console.SetCursorPosition(Math.Max(0, x), Math.Max(0, y));
			if (style != null) {
				if (style.Foreground.HasValue) {
					ConsoleColor fg = style.Foreground.Value;
					if (style.Bold) fg = ToBright(fg);
					Console.ForegroundColor = fg;
				}
				if (style.Background.HasValue) {
					Console.BackgroundColor = style.Background.Value;
				}
			}
			Console.Write(text);
			Console.ResetColor();
		}
	}

	public void DrawBox(int x, int y, int width, int height, string? title = null, Style? style = null) {
		lock (_lock) {
			Style borderStyle = style ?? ThemeManager.Get("PanelBorder");

			string horizontal = new string('-', width - 2);
			DrawText(x, y, "+" + horizontal + "+", borderStyle);
			for (int i = 1; i < height - 1; i++) {
				DrawText(x, y + i, "|" + new string(' ', width - 2) + "|", borderStyle);
			}
			DrawText(x, y + height - 1, "+" + horizontal + "+", borderStyle);

			if (!string.IsNullOrWhiteSpace(title)) {
				int maxTitleLen = Math.Min(title.Length, width - 4);
				Style titleStyle = new Style(borderStyle.Foreground, borderStyle.Background, true);
				DrawText(x + 2, y, title.Substring(0, maxTitleLen), titleStyle);
			}
		}
	}
}

public abstract class UIComponent : IRenderable, IInputHandler {
	public string? Id { get; init; } = null;
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; } = 10;
	public int Height { get; set; } = 1;
	public bool IsFocused { get; set; } = false;
	public Style? Style { get; set; }
	public object? Data { get; set; } = null;

	public virtual bool IsFocusable => true;

	public virtual void Render(ConsoleRenderer renderer) { }
	public virtual bool HandleInput(ConsoleKeyInfo keyInfo) { return false; }
	public virtual void OnResize(int newWidth, int newHeight) { }
}

public class Label : UIComponent {
	public override bool IsFocusable => false;
	public string Text { get; set; } = "";

	public override void Render(ConsoleRenderer renderer) {
		Style styleToUse = Style ?? ThemeManager.GetCurrent();
		renderer.DrawText(X, Y, Text.PadRight(Width), styleToUse);
	}
}

public class Button : UIComponent {
	public string Text { get; set; } = "Button";
	public Action? OnClickAction { get; set; }

	public override void Render(ConsoleRenderer renderer) {
		Style styleToUse = IsFocused ? ThemeManager.GetHighlight() : (Style ?? ThemeManager.GetCurrent());
		string buttonText = $"[{Text}]".PadRight(Width);
		renderer.DrawText(X, Y, buttonText.Substring(0, Math.Min(buttonText.Length, Width)), styleToUse);
	}

	public override bool HandleInput(ConsoleKeyInfo keyInfo) {
		if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar) {
			OnClickAction?.Invoke();
			return true;
		}
		return false;
	}
}

public class Checkbox : UIComponent {
	public bool Checked { get; private set; } = false;
	public string Label { get; set; } = "";

	public override void Render(ConsoleRenderer renderer) {
		Style styleToUse = IsFocused ? ThemeManager.GetHighlight() : (Style ?? ThemeManager.GetCurrent());
		string checkMark = Checked ? "[x]" : "[ ]";
		renderer.DrawText(X, Y, $"{checkMark} {Label}".PadRight(Width), styleToUse);
	}

	public override bool HandleInput(ConsoleKeyInfo keyInfo) {
		if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter) {
			Checked = !Checked;
			return true;
		}
		return false;
	}
}

public class TextBox : UIComponent {
	private StringBuilder _text = new StringBuilder();
	private int _cursorPos = 0;

	public string Text {
		get => _text.ToString();
		set {
			_text.Clear();
			_text.Append(value);
			_cursorPos = _text.Length;
		}
	}

	public Func<char, bool>? KeyFilter { get; set; } = null;

	public override void Render(ConsoleRenderer renderer) {
		Style styleToUse = IsFocused ? ThemeManager.Get("TextboxFocus") : (Style ?? ThemeManager.GetCurrent());
		string display = _text.ToString();
		if (IsFocused) {
			if (_cursorPos >= display.Length)
				display += "_";
			else
				display = display.Insert(_cursorPos, "_");
		}
		display = display.PadRight(Width);
		renderer.DrawText(X, Y, display.Substring(0, Math.Min(display.Length, Width)), styleToUse);
	}

	public override bool HandleInput(ConsoleKeyInfo keyInfo) {
		if (keyInfo.Key == ConsoleKey.Backspace && _cursorPos > 0) {
			_text.Remove(_cursorPos - 1, 1);
			_cursorPos--;
			return true;
		} else if (!char.IsControl(keyInfo.KeyChar)) {
			if (KeyFilter is not null && !KeyFilter.Invoke(keyInfo.KeyChar)) {
				return false;
			}

			if (_text.Length < Width) {
				_text.Insert(_cursorPos, keyInfo.KeyChar);
				_cursorPos++;
			}
			return true;
		} else if (keyInfo.Key == ConsoleKey.LeftArrow) {
			_cursorPos = Math.Max(0, _cursorPos - 1);
			return true;
		} else if (keyInfo.Key == ConsoleKey.RightArrow) {
			_cursorPos = Math.Min(_text.Length, _cursorPos + 1);
			return true;
		}
		return false;
	}
}

public class Panel : UIComponent {
	public string? Title { get; set; }
	public List<UIComponent> Children { get; set; } = new List<UIComponent>();
	public int Padding { get; set; } = 1;

	internal int _focusedChildIndex = -1;
	public bool IsVisible { get; set; } = true;

	public override bool IsFocusable => IsVisible && Children.Count > 0;

	public override void Render(ConsoleRenderer renderer) {
		if (!IsVisible) return;
		Style styleToUse = Style ?? ThemeManager.Get("PanelBorder");
		renderer.DrawBox(X, Y, Width, Height, Title, styleToUse);

		int contentX = X + Padding;
		int contentY = Y + Padding;
		int contentWidth = Width - Padding * 2;
		int contentHeight = Height - Padding * 2;

		foreach (UIComponent child in Children) {
			if (child.Style == null) {
				child.Style = this.Style ?? ThemeManager.GetCurrent();
			}
		}

		foreach (UIComponent child in Children) {
			int originalX = child.X;
			int originalY = child.Y;

			child.X = contentX + originalX;
			child.Y = contentY + originalY;

			child.Render(renderer);

			child.X = originalX;
			child.Y = originalY;
		}
	}

	public void ResetFocus() {
		for (int i = 0; i < Children.Count; i++) {
			if (Children[i].IsFocusable) {
				SetFocus(i);
				return;
			}
		}
		_focusedChildIndex = -1;
	}

	public void SetFocus(int index) {
		if (_focusedChildIndex >= 0 && _focusedChildIndex < Children.Count) {
			Children[_focusedChildIndex].IsFocused = false;
		}
		_focusedChildIndex = index;
		if (_focusedChildIndex >= 0 && _focusedChildIndex < Children.Count) {
			Children[_focusedChildIndex].IsFocused = true;
		}
	}

	public override bool HandleInput(ConsoleKeyInfo keyInfo) {
		if (!IsVisible) return false;

		if (Children.Count == 0) return false;

		if (_focusedChildIndex == -1) {
			ResetFocus();
			if (_focusedChildIndex == -1) return false;
		}

		if (keyInfo.Key == ConsoleKey.Tab) {
			UIComponent focusedChild = Children[_focusedChildIndex];

			// If focused child is a panel, let it handle input first (recursive)
			if (focusedChild is Panel nestedPanel) {
				bool handled = nestedPanel.HandleInput(keyInfo);
				if (!handled) {
					// If nested panel couldn't move focus, move focus in this panel
					return CycleFocus(keyInfo);
				} else {
					return true;
				}
			} else {
				// Cycle focus inside this panel
				return CycleFocus(keyInfo);
			}
		} else {
			UIComponent focusedChild = Children[_focusedChildIndex];

			if (focusedChild is Panel nestedPanel) {
				return nestedPanel.HandleInput(keyInfo);
			} else {
				focusedChild.HandleInput(keyInfo);
				return true;
			}
		}
	}

	private bool CycleFocus(ConsoleKeyInfo keyInfo) {
		int oldIndex = _focusedChildIndex;
		Children[_focusedChildIndex].IsFocused = false;

		do {
			if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0) {
				_focusedChildIndex = (_focusedChildIndex - 1 + Children.Count) % Children.Count;
			} else {
				_focusedChildIndex = (_focusedChildIndex + 1) % Children.Count;
			}
		} while (!Children[_focusedChildIndex].IsFocusable && _focusedChildIndex != oldIndex);

		Children[_focusedChildIndex].IsFocused = true;

		bool wrappedAround = _focusedChildIndex == oldIndex;

		// If we wrapped around, no more focus inside panel, bubble up
		return !wrappedAround;
	}

	public UIComponent? GetById(string id) {
		return Children.FirstOrDefault((UIComponent c) => c.Id == id);
	}

	public virtual void Add(UIComponent component) {
		Children.Add(component);
	}
}

public class ScrollPanel : Panel {
	private int _scrollOffset = 0;
	public Style? ScrollbarStyle { get; set; }

	public override void Render(ConsoleRenderer renderer) {
		Style styleToUse = Style ?? ThemeManager.Get("PanelBorder");
		renderer.DrawBox(X, Y, Width, Height, Title, styleToUse);

		int contentX = X + Padding;
		int contentY = Y + Padding;
		int contentWidth = Width - Padding * 2;
		int contentHeight = Height - Padding * 2;

		foreach (UIComponent child in Children) {
			child.Style ??= this.Style ?? ThemeManager.GetCurrent();
		}

		int currentY = 0;
		foreach (UIComponent child in Children) {
			if (currentY + child.Height > _scrollOffset && currentY < _scrollOffset + contentHeight) {
				int drawY = contentY + currentY - _scrollOffset;
				int originalX = child.X;
				int originalY = child.Y;

				child.X = contentX + child.X;
				child.Y = drawY;
				child.Render(renderer);

				child.X = originalX;
				child.Y = originalY;
			}
			currentY += child.Height;
		}

		// Draw scrollbar
		ScrollbarStyle ??= ThemeManager.Get("Scrollbar");
		int totalHeight = 0;
		foreach (var c in Children) totalHeight += c.Height;

		if (totalHeight > contentHeight) {
			int barHeight = Math.Max(1, contentHeight * contentHeight / totalHeight);
			int barPos = _scrollOffset * contentHeight / totalHeight;
			for (int i = 0; i < contentHeight; i++) {
				if (i >= barPos && i < barPos + barHeight) {
					renderer.DrawText(X + Width - 1, contentY + i, "█", ScrollbarStyle);
				} else {
					renderer.DrawText(X + Width - 1, contentY + i, " ", ScrollbarStyle);
				}
			}
		}
	}

	public override bool HandleInput(ConsoleKeyInfo keyInfo) {
		bool handledInside = base.HandleInput(keyInfo);
		if (handledInside) return true;

		if (keyInfo.Key == ConsoleKey.UpArrow) {
			_scrollOffset = Math.Max(0, _scrollOffset - 1);
			return true;
		} else if (keyInfo.Key == ConsoleKey.DownArrow) {
			_scrollOffset = Math.Min(Children.Count - 1, _scrollOffset + 1);
			return true;
		}

		return false;
	}

	public override void Add(UIComponent component) {
		component.Y = (Children.LastOrDefault()?.Y ?? -1) + 1;
		Children.Add(component);
	}
}

public class UIApp {
	private ConsoleRenderer _renderer = new ConsoleRenderer();
	public ConsoleRenderer Renderer => _renderer;
	private List<UIComponent> _components = new List<UIComponent>();
	private int _focusIndex = -1;
	private bool _running = false;
	public bool Running => _running;
	private Thread _renderingThread;

	public void Add(UIComponent component) {
		_components.Add(component);
	}

	public void Add(params UIComponent[] components) {
		_components.AddRange(components);
	}

	public void Run() {
		Console.CursorVisible = false;

		if (_components.Count == 0) return;

		_focusIndex = 0;
		_components[_focusIndex].IsFocused = true;

		_renderingThread = new Thread(RenderingLoop);
		_renderingThread.Start();

		_running = true;
		while (_running) {
			ConsoleKeyInfo key = Console.ReadKey(true);

			if (key.Key == ConsoleKey.Escape) {
				_running = false;
			}

			// Handle Tab and Shift+Tab for focus cycling
			if (key.Key == ConsoleKey.Tab) {
				bool reverse = (key.Modifiers & ConsoleModifiers.Shift) != 0;
				UIComponent? currentFocus = _focusIndex >= 0 && _focusIndex < _components.Count ? _components[_focusIndex] : null;

				bool handledInsidePanel = false;

				if (currentFocus != null && currentFocus is Panel currentPanel) {
					handledInsidePanel = currentPanel.HandleInput(key);
				}

				if (!handledInsidePanel) {
					MoveFocus(reverse);
				}
			} else {
				// If focused component is a panel, let it handle input (non-tab keys)
				UIComponent? currentFocus = _focusIndex >= 0 && _focusIndex < _components.Count ? _components[_focusIndex] : null;
				if (currentFocus is not null && currentFocus is Panel currentPanel) {
					bool handled = currentPanel.HandleInput(key);
					if (!handled) {
						currentFocus.HandleInput(key);
					}
				} else {
					currentFocus?.HandleInput(key);
				}
			}
		}

		Console.Clear();
		Console.CursorVisible = false;
	}

	public void RenderingLoop() {
		while (_running) {
			_renderer.Clear();

			foreach (UIComponent comp in _components) {
				comp.Render(_renderer);
			}
		}
	}

	private void MoveFocus(bool reverse = false) {
		if (_components.Count == 0) return;

		_components[_focusIndex].IsFocused = false;

		int startIndex = _focusIndex;
		do {
			_focusIndex = reverse ? (_focusIndex - 1 + _components.Count) % _components.Count : (_focusIndex + 1) % _components.Count;
		} while (!_components[_focusIndex].IsFocusable && _focusIndex != startIndex);

		_components[_focusIndex].IsFocused = true;
	}

	public T? GetById<T>(string? id) where T : UIComponent {
		if (id is null) return null;

		foreach (UIComponent component in _components) {
			if (component.Id == id) return (T?)component;

			if (component is Panel panel && panel.GetById(id) is UIComponent found && found is not null)
				return (T?)found;
		}

		return null;
	}

	public void Stop() {
		_running = false;
	}
}

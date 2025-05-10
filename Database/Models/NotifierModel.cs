using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Diplomeocy.Database.Models;

public abstract class NotifierModel : INotifyPropertyChanged {
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string? name = null) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

using Diplomeocy.Database.Models.Types;

namespace Diplomeocy.Database.Models;

public abstract class NotifierModel : INotifyPropertyChanged {
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string? name = null) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
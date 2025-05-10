using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomeocy.Database.Models;

public class TrackableModel : NotifierModel, ITrackable {
	[NotMapped]
	private DateTime createdAt;
	public DateTime CreatedAt {
		get => createdAt;
		set {
			createdAt = value;
			// OnPropertyChanged();

		}
	}

	[NotMapped]
	private int createdBy;
	public int CreatedBy {
		get => createdBy;
		set {
			createdBy = value;
			// OnPropertyChanged();
		}
	}

	[NotMapped]
	private DateTime updatedAt;
	public DateTime UpdatedAt {
		get => updatedAt;
		set {
			updatedAt = value;
			// OnPropertyChanged();
		}
	}

	[NotMapped]
	private int updatedBy;
	public int UpdatedBy {
		get => updatedBy;
		set {
			updatedBy = value;
			// OnPropertyChanged();
		}
	}
}

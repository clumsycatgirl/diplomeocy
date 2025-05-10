using System.ComponentModel.DataAnnotations.Schema;

using Diplomeocy.Database.Models.Types;

namespace Diplomeocy.Database.Models;

#pragma warning disable CS8618
public class Message : TrackableModel {
	[NotMapped]
	private int id;
	public int Id {
		get => id;
		set {
			id = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private int idTable;
	public int IdTable {
		get => idTable;
		set {
			idTable = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private string channel;
	public required string Channel {
		get => channel;
		set {
			channel = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private int sender;
	public required int Sender {
		get => sender;
		set {
			sender = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private MessageType type;
	public required MessageType Type {
		get => type;
		set {
			type = value;
			OnPropertyChanged();
		}
	}

	[NotMapped]
	private string? data;
	public string? Data {
		get => data;
		set {
			data = value;
			OnPropertyChanged();
		}

	}
}

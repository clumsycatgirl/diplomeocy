namespace Diplomacy;

public enum OrderStatus {
	Pending, Succeeded, Failed, Disbanded, Retired
}

public abstract class Order {
	public required Unit Unit { get; set; }
	public int Strength { get; set; } = 1;
	public OrderStatus Status { get; set; } = OrderStatus.Pending;

	private Territory? target = null;
	public Territory? Target {
		get => target;
		set {
			if (value is null || !Unit.Location.AdjacentTerritories.Contains(value)) {
				throw new InvalidOperationException($"wtf physics says you can't go from {Unit.Location.Name} to {value!.Name} in one turn sowwy");
			}
			target = value;
		}
	}

	public bool Resolved => Status != OrderStatus.Pending;

	protected string ToString(string type) => $"[{Status}] ({Unit?.Type} in {Unit?.Location.Name}) {type} to ({Target?.Name})";
	public override string ToString() => ToString("*order*");
}

public class MoveOrder : Order {
	public override string ToString() => ToString("moves");
}

public class SupportOrder : Order {
	public Order SupportedOrder { get; set; }

	public override string ToString() => $"{ToString("supports")} supported ({SupportedOrder})";
}

public class ConvoyOrder : Order {
	public MoveOrder ConvoyedOrder { get; set; }

	public override string ToString() => $"{ToString("convoy")} convoyed ({ConvoyedOrder})";
}

public class HoldOrder : Order {
	public override string ToString() => ToString("holds");
}

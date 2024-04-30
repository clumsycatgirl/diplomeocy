namespace Diplomacy;

public abstract class Order {
	public Unit Unit { get; set; }
	private Territory target;
	public Territory Target {
		get => target;
		set {
			if (value is null || !Unit.Location.AdjacentTerritories.Contains(value)) {
				throw new InvalidOperationException($"wtf physics says you can't go from london to moscow in one turn sowwy");
			}
			target = value;
		}
	}

	protected string ToString(string type) => $"({Unit?.Type} in {Unit?.Location?.Name})  {type} to ({Target?.Name})";
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

namespace Diplomacy;

public abstract class Order {
	public Unit Unit { get; set; }
	public Territory Target { get; set; }

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

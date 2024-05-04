using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class SupportOrder : Order {
	public required Order SupportedOrder { get; set; }

	public override string ToString() => $"{ToString("supports")} supported ({SupportedOrder})";
}

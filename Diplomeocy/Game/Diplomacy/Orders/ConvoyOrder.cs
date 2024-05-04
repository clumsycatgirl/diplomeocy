using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class ConvoyOrder : Order {
	public required MoveOrder ConvoyedOrder { get; set; }

	public override string ToString() => $"{ToString("convoy")} convoyed ({ConvoyedOrder})";
}

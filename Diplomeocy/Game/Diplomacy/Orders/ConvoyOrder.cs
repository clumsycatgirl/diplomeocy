using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class ConvoyOrder : Order {
	public required MoveOrder ConvoyedOrder { get; set; }

	public override void Resolve() { }

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		throw new Exception("fix thsi shit");
	}

	public override string ToString() => $"{ToString("convoy")} convoyed ({ConvoyedOrder})";
}

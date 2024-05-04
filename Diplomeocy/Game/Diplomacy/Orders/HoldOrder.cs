using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;

public class HoldOrder : Order {
	public override void Resolve() { }

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
	}

	public override string ToString() => ToString("holds");
}

using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class SupportOrder : Order {
	public required Order SupportedOrder { get; set; }

	public override void Resolve() {
		lock (SupportedOrder) SupportedOrder.Strength++;
		Status = OrderStatus.Succeeded;
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (SupportedOrder.Status == OrderStatus.Failed) {
			Status = OrderStatus.Failed;
		}

		// this should happen only when we backtrack on the dependency graph
		// cause we're cutting this support specifically
		if (Status == OrderStatus.Pending) {
		}
	}

	public override string ToString() => $"{ToString("supports")} supported ({SupportedOrder})";
}

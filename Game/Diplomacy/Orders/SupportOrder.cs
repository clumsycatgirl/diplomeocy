
namespace Diplomacy.Orders;
public class SupportOrder : Order {
	public required Order? SupportedOrder { get; set; }

	public (Territories From, Territories To) WillSupport { get; set; }

	public override void Resolve() {
		if (SupportedOrder is null) {
			Status = OrderStatus.Failed;
			return;
		}

		lock (SupportedOrder) {
			SupportedOrder.Strength++;
			SupportedOrder.SupportedBy.Add(this);
		}
		Status = OrderStatus.Succeeded;
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (SupportedOrder is null) {
			Status = OrderStatus.Failed;
			return;
		}

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

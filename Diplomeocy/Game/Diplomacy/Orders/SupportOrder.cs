using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class SupportOrder : Order {
	public required Order SupportedOrder { get; set; }

	public override void Resolve() {
		lock (SupportedOrder) SupportedOrder.Strength++;
		Status = OrderStatus.Succeeded;
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) { }

	public override string ToString() => $"{ToString("supports")} supported ({SupportedOrder})";
}

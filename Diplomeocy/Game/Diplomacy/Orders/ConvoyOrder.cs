using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class ConvoyOrder : Order {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	private MoveOrder convoyedOrder;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public required MoveOrder ConvoyedOrder {
		get => convoyedOrder;
		set {
			convoyedOrder = value;
			convoyedOrder.IsConvoyed = true;
		}
	}

	public override void Resolve() { }

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (Unit.Location!.AdjacentTerritories.Contains(ConvoyedOrder.Target!)) {
			ConvoyedOrder.Status = OrderStatus.Succeeded;
			Status = OrderStatus.Succeeded;
		} else {
			ConvoyedOrder.Status = OrderStatus.Failed;
			Status = OrderStatus.Failed;
		}
	}

	public override string ToString() => $"{ToString("convoy")} convoyed ({ConvoyedOrder})";
}

using Diplomacy;
using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;
public class ConvoyOrder : Order {

#pragma warning disable CS8618
	private MoveOrder convoyedOrder;
#pragma warning restore CS8618

	public required MoveOrder ConvoyedOrder {
		get => convoyedOrder;
		set {
			convoyedOrder = value;
			convoyedOrder.IsConvoyed = true;
		}
	}

	public override void Resolve() { }

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		// Check if the convoyed order's target is reachable by sea
		if (!Unit.Location!.AdjacentTerritories.Contains(ConvoyedOrder.Target!)) {
			Status = OrderStatus.Failed;
			return;
		}

		// Find all successful convoy orders
		List<ConvoyOrder> convoyOrders = dependencyGraph!
			.Where(kvp => kvp.Value.Contains(this) && kvp.Key.Status == OrderStatus.Succeeded)
			.Select(kvp => (ConvoyOrder)kvp.Key)
			.ToList();

		// Check for an unbroken chain of fleets
		if (IsUnbrokenChainOfFleets(convoyOrders, ConvoyedOrder)) {
			Status = OrderStatus.Succeeded;
		} else {
			Status = OrderStatus.Failed;
		}
	}

	private bool IsUnbrokenChainOfFleets(List<ConvoyOrder> convoyOrders, MoveOrder moveOrder) {
		// Create a dictionary mapping territories to convoy orders
		Dictionary<Territory, ConvoyOrder> territoryToOrder = convoyOrders.ToDictionary(
			 order => order.Unit.Location!,
			  order => order);

		// Create a queue for the BFS and enqueue the origin
		Queue<Territory> queue = new();
		queue.Enqueue(moveOrder.Unit.Location!);

		// Create a set to keep track of visited territories
		HashSet<Territory> visited = new();

		while (queue.Count > 0) {
			Territory current = queue.Dequeue();
			visited.Add(current);

			// If we've reached the destination, return true
			if (current == moveOrder.Target) {
				return true;
			}

			// Enqueue all adjacent territories that have a convoy order and haven't been visited yet
			foreach (Territory adjacent in current.AdjacentTerritories) {
				if (territoryToOrder.ContainsKey(adjacent) && !visited.Contains(adjacent)) {
					queue.Enqueue(adjacent);
				}
			}
		}

		// If we've exhausted all possibilities without reaching the destination, return false
		return false;
	}

	public override string ToString() => $"{ToString("convoy")} convoyed ({ConvoyedOrder})";
}

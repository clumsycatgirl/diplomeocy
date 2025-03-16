namespace Diplomacy.Orders;
public class ConvoyOrder : Order {

	private MoveOrder? convoyedOrder;
	public (Territories From, Territories To) WillConvoy { get; set; }

	public MoveOrder ConvoyedOrder {
		get => convoyedOrder!;
		set {
			convoyedOrder = value;
			convoyedOrder.IsConvoyed = true;
		}
	}

	public override void Resolve() { }

	public override void ResolveFailed() {
		if (Status == OrderStatus.Dislodged) {
			if (Unit.Location!.OccupyingUnit == Unit) Unit.Location!.OccupyingUnit = null;
			Unit.Location = null;
		}
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (convoyedOrder is null) {
			Status = OrderStatus.Failed;
			return;
		}

		Status = OrderStatus.Succeeded;
	}

	public bool IsUnbrokenChainOfFleets(List<ConvoyOrder> convoyOrders) {
		// Create a dictionary mapping territories to convoy orders
		Dictionary<Territory, ConvoyOrder> territoryToOrder = convoyOrders.ToDictionary(
			 order => order.Unit.Location!,
			 order => order);

		// Create a queue for the BFS and enqueue the origin
		Queue<Territory> queue = new();
		queue.Enqueue(ConvoyedOrder.Unit.Location!);

		// Create a set to keep track of visited territories
		HashSet<Territory> visited = new();

		while (queue.Count > 0) {
			Territory current = queue.Dequeue();
			visited.Add(current);

			// If we've reached the destination, return true
			if (current == ConvoyedOrder.Target) {
				return true;
			}

			if (current.AdjacentTerritories.Contains(ConvoyedOrder.Target!)) {
				return true;
			}

			// Enqueue all adjacent territories that have a convoy order and haven't been visited yet
			current.AdjacentTerritories
				.Where(adjacent => territoryToOrder.ContainsKey(adjacent) && !visited.Contains(adjacent))
				.AsParallel()
				.ForAll(adjacent => queue.Enqueue(adjacent));
		}

		// If we've exhausted all possibilities without reaching the destination, return false
		return false;
	}

	public override string ToString() => $"{ToString("convoy")} ({ConvoyedOrder})";
}

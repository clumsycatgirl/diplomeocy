using System.Collections.Immutable;

using Game.Diplomacy.Orders;

namespace Diplomacy.Orders;

public enum OrderStatus {
	Pending, Succeeded, Failed, Dislodged, Retired
}

public abstract class Order {
	public required Unit Unit { get; set; }
	public int Strength { get; set; } = 1;
	public OrderStatus Status { get; set; } = OrderStatus.Pending;

	private Territory? target = null;
	public Territory? Target {
		get => target;
		set {
			if (value is null || (!Unit.Location?.AdjacentTerritories.Contains(value) ?? false)) {
				throw new InvalidOperationException($"wtf physics says you can't go from {Unit.Location?.Name} to {value?.Name} in one turn sowwy");
			}
			target = value;
		}
	}

	public bool Resolved => Status != OrderStatus.Pending;

	public abstract void Resolve();
	public virtual void ResolveFailed() { }
	public abstract void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDepedency);

	protected string ToString(string type) => $"[{Status}][{Strength}] ({Unit?.Type} in {Unit?.Location?.Name}) {type}{(target is null ? "" : $" targets {target}")}";
	public override string ToString() => ToString("*order*");

	internal void SetDependenciesToPending(Dictionary<Order, List<Order>> dependencyGraph) {
		if (!dependencyGraph.ContainsKey(this)) {
			return;
		}

		Status = OrderStatus.Pending;
		List<Order> dependencies = dependencyGraph.GetValueOrDefault(this, new());
		dependencies
			.AsParallel()
			.Where(order => order.Status != OrderStatus.Pending)
			.ForAll(dependency => {
				//Log.WriteLine($"setting {dependency} to pending");
				dependency.Status = OrderStatus.Pending;
				dependency.SetDependenciesToPending(dependencyGraph);
			});
	}

	internal void SetBackwardsDependenciesToPending(Dictionary<Order, List<Order>> depencenyGraph) {
		if (!depencenyGraph.ContainsKey(this)) {
			return;
		}

		Status = OrderStatus.Pending;
		List<Order> orders = depencenyGraph.Keys.ToList();
		orders.
			AsParallel()
			.Where(order => order is not SupportOrder)
			.Where(order => depencenyGraph[order].Contains(this) && order.Status != OrderStatus.Pending)
			.ForAll(order => {
				//Log.WriteLine($"setting {order} to pending");
				order.Status = OrderStatus.Pending;
				order.SetBackwardsDependenciesToPending(depencenyGraph);
			});
	}
}

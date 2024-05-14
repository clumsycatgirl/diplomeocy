using System.Collections.Immutable;

namespace Diplomacy.Orders;

public enum OrderStatus {
	Pending, Succeeded, Failed, Dislodged, Retired
}

public abstract class Order {
	public required Unit Unit { get; set; }
	public int Strength { get; set; } = 1;
	public List<SupportOrder> SupportedBy { get; set; } = new();
	public OrderStatus Status { get; set; } = OrderStatus.Pending;

	public bool IsConvoyed { get; set; } = false;

	private Territory? target = null;
	public Territory? Target {
		get => target;
		set {
			if (value is null) {
				throw new InvalidOperationException($"wtf physics says you can't go from {Unit.Location?.Name} to {value?.Name} in one turn sowwy");
			}
			if (!Unit.Location?.AdjacentTerritories.Contains(value) ?? false) {
				if (!IsConvoyed) {
					throw new InvalidOperationException($"must convoy to go from {Unit.Location?.Name} to {value?.Name} this way");
				}
			}
			target = value;
		}
	}

	public bool Resolved => Status != OrderStatus.Pending;

	public Dictionary<string, OrderStatus> MeowmoisedResults { get; } = new();

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

	internal static string MeowmoisationKey(List<Order> deps) => $"[{String.Join(", ", deps.Select(dep => dep.ToString()))}]";

	internal void MeowmoiseResult(List<Order> dependences) => MeowmoiseResult(Status, dependences);

	internal void MeowmoiseResult(OrderStatus status, List<Order> dependences) {
		string key = MeowmoisationKey(dependences);
		MeowmoiseResult(key, status);
	}

	internal void MeowmoiseResult(String key, OrderStatus status) => MeowmoisedResults[key] = status;

	internal bool TryMeowmoise(List<Order> dependences) {
		bool result = MeowmoisedResults.TryGetValue(MeowmoisationKey(dependences), out OrderStatus status);
		if (status == OrderStatus.Pending || !result) return false;
		Status = status;
		return true;
	}

	internal List<Order> FullDependencyList(Dictionary<Order, List<Order>> dependencyGraph) =>
		dependencyGraph.GetValueOrDefault(this, new())
			.ToList()
			.Concat(dependencyGraph
					.Where(kvp => kvp.Value.Contains(this) && kvp.Key.Status == OrderStatus.Succeeded && kvp.Key is ConvoyOrder)
					.Select(kvp => (ConvoyOrder)kvp.Key)
					.DistinctBy(order => order.Unit.Location)
					.ToList())
			.ToList();
}

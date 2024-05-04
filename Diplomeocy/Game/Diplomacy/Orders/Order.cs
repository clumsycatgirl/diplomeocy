namespace Diplomacy.Orders;

public enum OrderStatus {
	Pending, Succeeded, Failed, Disbanded, Retired
}

public abstract class Order {
	public required Unit Unit { get; set; }
	public int Strength { get; set; } = 1;
	public OrderStatus Status { get; set; } = OrderStatus.Pending;

	private Territory? target = null;
	public Territory? Target {
		get => target;
		set {
			if (value is null || !Unit.Location.AdjacentTerritories.Contains(value)) {
				throw new InvalidOperationException($"wtf physics says you can't go from {Unit.Location.Name} to {value!.Name} in one turn sowwy");
			}
			target = value;
		}
	}

	public bool Resolved => Status != OrderStatus.Pending;

	protected string ToString(string type) => $"[{Status}] ({Unit?.Type} in {Unit?.Location.Name}) {type}";
	public override string ToString() => ToString("*order*");
}

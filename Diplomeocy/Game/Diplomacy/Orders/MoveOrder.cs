using Diplomacy.Orders;
using Diplomacy.Utils;

namespace Game.Diplomacy.Orders;

public class MoveOrder : Order {
	public override void Resolve() {
		Unit.Move(Target ?? throw new InvalidOperationException("moving to nowhere good job idiot"));
	}

	public override void ResolveFailed() {
		if (Status == OrderStatus.Disbanded) {
			if (Unit.Location!.OccupyingUnit == Unit) Unit.Location!.OccupyingUnit = null;
			Unit.Location = null;
		}
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (dependencyGraph is null) throw new Exception("come on");

		List<Order> dependencies = dependencyGraph.GetValueOrDefault(this, new());
		List<Order> conflictingDependencies = dependencies
					.Where(dependency => dependency is MoveOrder moveOrder && moveOrder.Target == Target && moveOrder.Status == OrderStatus.Pending)
					.ToList();
		// multiple orders trying to get to the same territory
		if (conflictingDependencies.Any()) {
			int highestStrength = Math.Max(
				conflictingDependencies.Max(dependency => dependency.Strength),
				Strength);

			// get the winner of the movement using the strengh property
			int highStrengthOrderCount = 0;
			if (Strength == highestStrength) highStrengthOrderCount++;

			// find all other orders we depend on that have the same strength
			highStrengthOrderCount += conflictingDependencies
				.Count(dependency => dependency.Strength == highestStrength);

			List<Order> totalConflictingOrders = conflictingDependencies
				.Concat(new[] { this })
				.ToList();

			// set all conflicting orders as failed
			if (highStrengthOrderCount != 1) {
				totalConflictingOrders
					.AsParallel()
					.ForAll(order => order.Status = OrderStatus.Failed);
				return;
			}

			// find winner and set it to success everything else fails
			Order winner = totalConflictingOrders
				.OrderByDescending(dependency => dependency.Strength)
				.First();
			winner.Status = OrderStatus.Succeeded;

			totalConflictingOrders
				.Where(order => order != winner)
				.AsParallel()
				.ForAll(order => order.Status = OrderStatus.Failed);
			return;
		}

		if (forwardDependency is null) {
			Status = OrderStatus.Succeeded;
			return;
		}

		// set all dependencies for the cancelled support order to pending
		if (forwardDependency is SupportOrder cancelledSupportOrder && cancelledSupportOrder.Resolved) {
			cancelledSupportOrder.Status = OrderStatus.Failed;
			cancelledSupportOrder.SupportedOrder.Status = OrderStatus.Pending;
			cancelledSupportOrder.SupportedOrder.Strength--;

			cancelledSupportOrder.SupportedOrder.SetDependenciesToPending(dependencyGraph!);

			Status = OrderStatus.Failed; // shouldn't need idr it was late but I'm not gonna go cehck
			return;
		}

		if (forwardDependency is HoldOrder holdOrder) {
			if (holdOrder.Strength >= Strength) {
				Status = OrderStatus.Failed;
			} else {
				Status = OrderStatus.Succeeded;
				holdOrder.Status = OrderStatus.Retired;
			}
			return;
		}

		if (forwardDependency is MoveOrder moveOrder) {
			Log.WriteLine($"{this} forward dependency is {moveOrder}");
			// check if the order is trying to get to the same place the current order is takign place on
			if (Unit.Location == moveOrder.Target && Strength == moveOrder.Strength) {
				Status = OrderStatus.Failed;
				moveOrder.Status = OrderStatus.Failed;
			} else if (moveOrder.Status == OrderStatus.Succeeded) {
				Status = OrderStatus.Succeeded;
			} else if (moveOrder.Status == OrderStatus.Failed) {
				// forwardUnit should stay in place

				// if we can win retired the forwardUnit
				if (Strength > 1) {
					moveOrder.SetBackwardsDependenciesToPending(dependencyGraph!);
					moveOrder.Status = OrderStatus.Disbanded;
					Status = OrderStatus.Succeeded;
				} else {
					Status = OrderStatus.Failed;
				}
			} else if (moveOrder.Status == OrderStatus.Disbanded) {
				Status = OrderStatus.Succeeded;
			} else {
				Status = OrderStatus.Failed;
			}
			return;
		}

		if (forwardDependency!.Resolved) {
			// if the one in front is done check if it's goign to a different place cause then we can go there
			if (forwardDependency.Status == OrderStatus.Succeeded && forwardDependency.Target != Target) {
				Status = OrderStatus.Succeeded;
			} else {
				// if that fucker of a forward faield just like I did at spelling
				// then we also fail
				Status = OrderStatus.Failed;
			}
			return;
		}
	}

	public override string ToString() => ToString("moves");
}

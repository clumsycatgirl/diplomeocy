using Diplomacy;
using Diplomacy.Orders;

namespace Game.Diplomacy.Orders;

public class MoveOrder : Order {
	public override void Resolve() {
		Unit.Move(Target ?? throw new InvalidOperationException("moving to nowhere good job idiot"));
	}

	public override void ResolveFailed() {
		if (Status == OrderStatus.Dislodged) {
			if (Unit.Location!.OccupyingUnit == Unit) Unit.Location!.OccupyingUnit = null;
			Unit.Location = null;
		}
	}

	public override void Execute(Dictionary<Order, List<Order>>? dependencyGraph, Order? forwardDependency) {
		if (dependencyGraph is null) throw new Exception("come on");

		List<Order> dependencies = dependencyGraph.GetValueOrDefault(this, new());
		List<Order> conflictingDependencies = dependencies
					.Where(dependency =>
						dependency.Status == OrderStatus.Pending
						&& dependency is MoveOrder moveOrder
						&& moveOrder.Target == Target)
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

		// there's nothing so we just go
		if (forwardDependency is null) {
			Status = OrderStatus.Succeeded;
			return;
		}

		// set all dependencies for the cancelled support order to pending
		if (forwardDependency is SupportOrder forwardSupportOrder && forwardSupportOrder.Resolved) {
			if (forwardSupportOrder.SupportedOrder.Target == Unit.Location) {
				// cannot cut support order as it's trying to support against *our* location

				// if we cannot dislodge the unit we can't cut the support and thus we fail
				if (Strength <= forwardSupportOrder.Strength) {
					Status = OrderStatus.Failed;
					return;
				}

				// if we're stronger we can dislodge the unit and cut the support
				forwardSupportOrder.SupportedOrder.SetDependenciesToPending(dependencyGraph!);
				forwardSupportOrder.SupportedOrder.Strength--;
				forwardSupportOrder.Status = OrderStatus.Failed;
				Status = OrderStatus.Succeeded;
				return;
			}

			forwardSupportOrder.Status = OrderStatus.Dislodged;
			forwardSupportOrder.SupportedOrder.Status = OrderStatus.Pending;
			forwardSupportOrder.SupportedOrder.Strength--;

			forwardSupportOrder.SupportedOrder.SetBackwardsDependenciesToPending(dependencyGraph!);

			Status = OrderStatus.Failed; // shouldn't need idr it was late but I'm not gonna go cehck
			return;
		}

		if (forwardDependency is HoldOrder holdOrder) {
			if (holdOrder.Strength >= Strength) {
				Status = OrderStatus.Failed;
				holdOrder.Status = OrderStatus.Succeeded;
			} else {
				Status = OrderStatus.Succeeded;
				holdOrder.Status = OrderStatus.Retired;
			}
			return;
		}

		if (forwardDependency is MoveOrder moveOrder) {
			// check if the order is trying to get to the same place the current order is takign place on
			if (Unit.Location == moveOrder.Target && moveOrder.Status == OrderStatus.Pending) {
				if (Strength == moveOrder.Strength) {
					Status = OrderStatus.Failed;
					moveOrder.Status = OrderStatus.Failed;
				} else if (Strength > moveOrder.Strength) {
					Status = OrderStatus.Succeeded;
					moveOrder.Status = OrderStatus.Dislodged;
				} else {
					Status = OrderStatus.Dislodged;
					moveOrder.Status = OrderStatus.Succeeded;
				}
			} else if (moveOrder.Status == OrderStatus.Succeeded) {
				// check if the forward order succeded in moving
				if (moveOrder.Target != Unit.Location) {
					// arey trying to get to a different location from ours then that means we can go where they were
					Status = OrderStatus.Succeeded;
					return;
				}

				// if the forward unit is trying to get to the same place we are

				// try to dislodge them
				//if (Strength <= 1) {
				//	Status = OrderStatus.Failed;
				//	return;
				//}

				//moveOrder.SetBackwardsDependenciesToPending(dependencyGraph!);
				//moveOrder.Status = OrderStatus.Dislodged;
				//Status = OrderStatus.Succeeded;
			} else if (moveOrder.Status == OrderStatus.Failed) {
				// forwardUnit should stay in place

				// standoff
				if (Strength <= 1) {
					Status = OrderStatus.Failed;
					return;
				}

				// if we can win retire the forwardUnit
				// this means all things that tried to get to that location and failed
				// could now succeed so set them to pending for the next iteration
				moveOrder.SetBackwardsDependenciesToPending(dependencyGraph!);
				//dependencyGraph!
				//	.ToList()
				//	.Where(kvp => kvp.Value.Contains(moveOrder))
				//	.ToList()
				//	.ForEach(kvp => kvp.Key.Status = OrderStatus.Pending);
				moveOrder.Status = OrderStatus.Dislodged;
				Status = OrderStatus.Succeeded;
			} else if (moveOrder.Status == OrderStatus.Dislodged) {
				// forwardUnit is no more
				Status = OrderStatus.Succeeded;
			} else {
				// idk what this means but it seems to be working so <- apparently that doesn't work anymore
				//Status = OrderStatus.Failed;

				// other unit is pending so do nothing for now instead of that *wrong* thing
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

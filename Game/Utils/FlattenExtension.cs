using System.Collections;

namespace Game.Utils;

public static class FlattenExtension {
	/// <summary>
	/// Given a N-dimensional array, flattens it into a new one-dimensional array without modifying the elements' order
	/// </summary>
	/// <typeparam name="T">The type of elements contained in the array</typeparam>
	/// <param name="data">The input array</param>
	/// <returns>A flattened array</returns>
	public static T[] Flatten<T>(this Array data) {
		List<T> list = new List<T>();
		Stack<IEnumerator> stack = new Stack<IEnumerator>();
		stack.Push(data.GetEnumerator());

		do {
			for (IEnumerator iterator = stack.Pop(); iterator.MoveNext();) {
				if (iterator.Current is Array) {
					stack.Push(iterator);
					iterator = (iterator.Current as IEnumerable)!.GetEnumerator();
				} else
					list.Add((T)iterator.Current);
			}
		} while (stack.Count > 0);

		return list.ToArray();
	}

	/// <summary>
	/// Given a N-dimensional IEnumerable, flattens it into a new one-dimensional IEnumerable without modifying the elements' order
	/// </summary>
	/// <typeparam name="T">The type of elements contained in the IEnumerable</typeparam>
	/// <param name="data">The input IEnumerable</param>
	/// <returns>A flattened IEnumerable</returns>
	public static T[] Flatten<T>(this IEnumerable data) {
		List<T> list = new List<T>();
		Stack<IEnumerator> stack = new Stack<IEnumerator>();
		stack.Push(data.GetEnumerator());

		do {
			for (IEnumerator iterator = stack.Pop(); iterator.MoveNext();) {
				if (iterator.Current is Array) {
					stack.Push(iterator);
					iterator = (iterator.Current as IEnumerable)!.GetEnumerator();
				} else
					list.Add((T)iterator.Current);
			}
		} while (stack.Count > 0);

		return list.ToArray();
	}
}

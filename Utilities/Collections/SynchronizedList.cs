using System.Collections;

namespace Diplomeocy.Collections;

public class SynchronizedList<T> : IList<T> {
	private readonly List<T> _innerList = new();
	private readonly object _lock = new();

	public void Add(T item) {
		lock (_lock) {
			_innerList.Add(item);
		}
	}

	public bool Remove(T item) {
		lock (_lock) {
			return _innerList.Remove(item);
		}
	}

	public void Clear() {
		lock (_lock) {
			_innerList.Clear();
		}
	}

	public bool Contains(T item) {
		lock (_lock) {
			return _innerList.Contains(item);
		}
	}

	public void CopyTo(T[] array, int arrayIndex) {
		lock (_lock) {
			_innerList.CopyTo(array, arrayIndex);
		}
	}

	public int Count {
		get {
			lock (_lock) {
				return _innerList.Count;
			}
		}
	}

	public bool IsReadOnly => false;

	public int IndexOf(T item) {
		lock (_lock) {
			return _innerList.IndexOf(item);
		}
	}

	public void Insert(int index, T item) {
		lock (_lock) {
			_innerList.Insert(index, item);
		}
	}

	public void RemoveAt(int index) {
		lock (_lock) {
			_innerList.RemoveAt(index);
		}
	}

	public T this[int index] {
		get {
			lock (_lock) {
				return _innerList[index];
			}
		}
		set {
			lock (_lock) {
				_innerList[index] = value;
			}
		}
	}

	public IEnumerator<T> GetEnumerator() {
		lock (_lock) {
			return new List<T>(_innerList).GetEnumerator();
		}
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public List<T> ToListSnapshot() {
		lock (_lock) {
			return new List<T>(_innerList);
		}
	}
}

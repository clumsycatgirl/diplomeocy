
using Diplomeocy.Extensions;

namespace Diplomeocy.Database.Services;

public abstract class BaseService<T> where T : class {
	protected readonly IHttpContextAccessor httpContextAccessor;
	protected readonly DatabaseContext databaseContext;
	private T? value = null;
	public virtual required string Key { get; init; }

	protected BaseService(IHttpContextAccessor httpContextAccessor, DatabaseContext databaseContext) {
		this.httpContextAccessor = httpContextAccessor;
		this.databaseContext = databaseContext;
	}

	protected T? Value {
		get {
			bool firstLoad = value is null;
			value ??= httpContextAccessor.HttpContext?.Session.Get<T?>(Key);
			if (firstLoad && value is not null) OnFirstLoad(value);
			return value;
		}
		set {
			this.value = value;
			httpContextAccessor.HttpContext?.Session.Set(Key, this.value);
		}
	}

	protected virtual void OnFirstLoad(T value) { }
}

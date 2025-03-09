using System.ComponentModel;
using System.Reflection;

using Diplomeocy.Extensions;

namespace Diplomeocy.Database.Models.SessionModels;

public class SessionModel<T> : INotifyPropertyChanged where T : class {
	public Type ModelType { get; } = typeof(T);
	public T? value { get; set; }
	private readonly IHttpContextAccessor httpContextAccessor;
	public string Key { get; init; }

	public SessionModel(IHttpContextAccessor httpContextAccessor, string key) {
		this.httpContextAccessor = httpContextAccessor;
		Key = key;
		value = httpContextAccessor.HttpContext?.Session?.Get<T?>(Key);
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public T? Value {
		get => httpContextAccessor.HttpContext?.Session.Get<T?>(Key);
		set {
			ISession? session = httpContextAccessor.HttpContext?.Session;
			if (session is null) {
				return;
			}

			if (value is not null) {
				session.Set(Key, value);
			} else {
				session.Remove(Key);
			}
		}
	}

	protected void SetProperty<J>(string propertyName, J value) {
		PropertyInfo? property = ModelType.GetProperty(propertyName);
		if (property is null) {
			throw new ArgumentNullException(nameof(property));
		}

		object? currentValue = property.GetValue(Value);
		if (!Equals(currentValue, value)) {
			property.SetValue(Value, value);
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

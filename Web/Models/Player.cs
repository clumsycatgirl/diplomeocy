
namespace Web.Models;

public class Player {
	public int Id { get; set; }
	public int IdTable { get; set; }
	public int IdUser { get; set; }

	public static implicit operator List<object>(Player? v) {
		throw new NotImplementedException();
	}
}

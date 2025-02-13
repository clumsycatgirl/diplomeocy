using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models;

public class Table {
	[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int Id { get; set; }
	public DateOnly Date { get; set; }
	public int Host { get; set; }
}

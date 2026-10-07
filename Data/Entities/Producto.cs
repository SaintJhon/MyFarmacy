using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaFarmacia.Data.Abstractions;

namespace SistemaFarmacia.Data.Entities
{
	public class Producto : IId
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		public required string CodigoBarras { get; set; }

		[MaxLength(100)]
		public required string Nombre { get; set; }

		[MaxLength(250)]
		public string? Descripcion { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal PrecioVenta { get; set; }

		public DateTime FechaVencimiento { get; set; }

		public int IdProveedor { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;
using SistemaFarmacia.Data.Abstractions;

namespace SistemaFarmacia.Data.Entities
{
	public class Sucursal : IId
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(100)]
		public required string Nombre { get; set; }

		[MaxLength(200)]
		public required string Direccion { get; set; }

		[MaxLength(20)]
		public required string Telefono { get; set; }
	}
}
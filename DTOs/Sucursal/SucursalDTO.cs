namespace SistemaFarmacia.DTOs.Sucursal
{
	public class SucursalDTO
	{
		public int Id { get; set; }

		public required string Nombre { get; set; }

		public required string Direccion { get; set; }

		public required string Telefono { get; set; }
	}
}
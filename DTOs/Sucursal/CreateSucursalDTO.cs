namespace SistemaFarmacia.DTOs.Sucursal
{
	public class CreateSucursalDTO
	{
		public required string Nombre { get; set; }

		public required string Direccion { get; set; }

		public required string Telefono { get; set; }
	}
}
namespace SistemaFarmacia.DTOs.Producto
{
	public class ProductoDTO
	{
		public int Id { get; set; }

		public required string CodigoBarras { get; set; }

		public required string Nombre { get; set; }

		public string? Descripcion { get; set; }

		public decimal PrecioVenta { get; set; }

		public DateTime FechaVencimiento { get; set; }

		public int IdProveedor { get; set; }
	}
}
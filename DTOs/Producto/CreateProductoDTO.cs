namespace SistemaFarmacia.DTOs.Producto
{
	public class CreateProductoDTO
	{
		public required string CodigoBarras { get; set; }

		public required string Nombre { get; set; }

		public string? Descripcion { get; set; }

		public decimal PrecioVenta { get; set; }

		public DateTime FechaVencimiento { get; set; }

		public int IdProveedor { get; set; }
	}
}
using SistemaFarmacia.DTOs.Producto;

namespace SistemaFarmacia.Services.Abstractions
{
	public interface IProductosService
	{
		Task<IEnumerable<ProductoDTO>> GetAllAsync();

		Task<IEnumerable<ProductoDTO>> SearchAsync(string? search);

		Task<CreateProductoDTO> CreateAsync(CreateProductoDTO dto);

		Task<ProductoDTO?> GetOneAsync(int id);

		Task UpdateAsync(ProductoDTO dto);

		Task DeleteAsync(int id);
	}
}
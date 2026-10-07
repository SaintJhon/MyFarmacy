using SistemaFarmacia.DTOs.Sucursal;

namespace SistemaFarmacia.Services.Abstractions
{
	public interface ISucursalesService
	{
		Task<IEnumerable<SucursalDTO>> GetAllAsync();

		Task<CreateSucursalDTO> CreateAsync(CreateSucursalDTO dto);

		Task<SucursalDTO?> GetOneAsync(int id);

		Task UpdateAsync(SucursalDTO dto);

		Task DeleteAsync(int id);
	}
}
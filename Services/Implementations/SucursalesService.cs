using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.Data;
using SistemaFarmacia.Data.Entities;
using SistemaFarmacia.DTOs.Sucursal;
using SistemaFarmacia.Services.Abstractions;

namespace SistemaFarmacia.Services.Implementations
{
	public class SucursalesService : ISucursalesService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public SucursalesService(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SucursalDTO>> GetAllAsync()
		{
			var sucursales = await _context.Sucursales.ToListAsync();

			return _mapper.Map<IEnumerable<SucursalDTO>>(sucursales);
		}

		public async Task<CreateSucursalDTO> CreateAsync(CreateSucursalDTO dto)
		{
			var sucursal = _mapper.Map<Sucursal>(dto);

			_context.Sucursales.Add(sucursal);

			await _context.SaveChangesAsync();

			return dto;
		}

		public async Task<SucursalDTO?> GetOneAsync(int id)
		{
			var sucursal = await _context.Sucursales
				.FirstOrDefaultAsync(s => s.Id == id);

			return _mapper.Map<SucursalDTO?>(sucursal);
		}

		public async Task UpdateAsync(SucursalDTO dto)
		{
			var sucursal = await _context.Sucursales
				.FirstOrDefaultAsync(s => s.Id == dto.Id);

			if (sucursal is null)
				return;

			_mapper.Map(dto, sucursal);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var sucursal = await _context.Sucursales
				.FirstOrDefaultAsync(s => s.Id == id);

			if (sucursal is null)
				return;

			_context.Sucursales.Remove(sucursal);

			await _context.SaveChangesAsync();
		}
	}
}
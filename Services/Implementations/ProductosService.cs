using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.Data;
using SistemaFarmacia.Data.Entities;
using SistemaFarmacia.DTOs.Producto;
using SistemaFarmacia.Services.Abstractions;

namespace SistemaFarmacia.Services.Implementations
{
	public class ProductosService : IProductosService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ProductosService(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
		{
			var productos = await _context.Productos.ToListAsync();

			return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
		}

		public async Task<IEnumerable<ProductoDTO>> SearchAsync(string? search)
		{
			var productos = _context.Productos.AsQueryable();

			if (!string.IsNullOrWhiteSpace(search))
			{
				productos = productos.Where(p =>
					p.Nombre.Contains(search) ||
					p.CodigoBarras.Contains(search));
			}

			var resultado = await productos.ToListAsync();

			return _mapper.Map<IEnumerable<ProductoDTO>>(resultado);
		}

		public async Task<CreateProductoDTO> CreateAsync(CreateProductoDTO dto)
		{
			var producto = _mapper.Map<Producto>(dto);

			_context.Productos.Add(producto);

			await _context.SaveChangesAsync();

			return dto;
		}

		public async Task<ProductoDTO?> GetOneAsync(int id)
		{
			var producto = await _context.Productos
				.FirstOrDefaultAsync(p => p.Id == id);

			return _mapper.Map<ProductoDTO?>(producto);
		}

		public async Task UpdateAsync(ProductoDTO dto)
		{
			var producto = await _context.Productos
				.FirstOrDefaultAsync(p => p.Id == dto.Id);

			if (producto is null)
				return;

			_mapper.Map(dto, producto);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var producto = await _context.Productos
				.FirstOrDefaultAsync(p => p.Id == id);

			if (producto is null)
				return;

			_context.Productos.Remove(producto);

			await _context.SaveChangesAsync();
		}
	}
}
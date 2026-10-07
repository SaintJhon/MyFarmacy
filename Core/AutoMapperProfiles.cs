using AutoMapper;
using SistemaFarmacia.Data.Entities;
using SistemaFarmacia.DTOs.Producto;
using SistemaFarmacia.DTOs.Sucursal;

namespace SistemaFarmacia.Core
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Producto, ProductoDTO>().ReverseMap();
			CreateMap<Producto, CreateProductoDTO>().ReverseMap();

			CreateMap<Sucursal, SucursalDTO>().ReverseMap();
			CreateMap<Sucursal, CreateSucursalDTO>().ReverseMap();
		}
	}
}
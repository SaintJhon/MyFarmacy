using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.Data.Entities;

namespace SistemaFarmacia.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		public DbSet<Producto> Productos { get; set; }

		public DbSet<Sucursal> Sucursales { get; set; }
	}
}
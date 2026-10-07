using SistemaFarmacia.Models;

namespace SistemaFarmacia.Services.Abstractions
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();

        Supplier? GetById(int id);

        bool Create(Supplier supplier);

        bool Update(Supplier supplier);

        bool Delete(int id);
    }
}
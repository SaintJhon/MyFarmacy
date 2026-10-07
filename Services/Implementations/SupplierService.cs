using SistemaFarmacia.Models;
using SistemaFarmacia.Services.Abstractions;

namespace SistemaFarmacia.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly List<Supplier> _suppliers = new();
        private int _nextId = 1;

        public IEnumerable<Supplier> GetAll()
        {
            return _suppliers;
        }

        public Supplier? GetById(int id)
        {
            return _suppliers.FirstOrDefault(s => s.Id == id);
        }

        public bool Create(Supplier supplier)
        {
            if (_suppliers.Any(s => s.Nit == supplier.Nit))
            {
                return false;
            }

            supplier.Id = _nextId++;
            _suppliers.Add(supplier);

            return true;
        }

        public bool Update(Supplier supplier)
        {
            var existingSupplier = GetById(supplier.Id);

            if (existingSupplier == null)
            {
                return false;
            }

            if (_suppliers.Any(s =>
                s.Nit == supplier.Nit &&
                s.Id != supplier.Id))
            {
                return false;
            }

            existingSupplier.Nit = supplier.Nit;
            existingSupplier.CompanyName = supplier.CompanyName;
            existingSupplier.Contact = supplier.Contact;
            existingSupplier.Phone = supplier.Phone;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Address = supplier.Address;

            return true;
        }

        public bool Delete(int id)
        {
            var supplier = GetById(id);

            if (supplier == null)
            {
                return false;
            }

            _suppliers.Remove(supplier);

            return true;
        }
    }
}
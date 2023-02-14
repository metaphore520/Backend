using Backend.Models;

namespace Backend.Contracts
{
    public interface ICustomerAddressRepository : IRepositoryBase<CustomerAddress>
    {
        int GetNextId();
    }
}

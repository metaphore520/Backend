using Backend.Models;

namespace Backend.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        int GetNextId();
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);

    }
}

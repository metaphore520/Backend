using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>,ICustomerRepository
    {
        private readonly CustomerDBContext _dbcontext;
        public CustomerRepository(CustomerDBContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;

        }
        public int GetNextId()
        {
            return this._dbcontext.Customer.Max(x => x.Id);
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
           return await this._dbcontext.Customer.ToListAsync();
        }


        public async Task<Customer> GetCustomerById(int id)
        {
            return await this._dbcontext.Customer.Where(x => x.Id == id).Include(x => x.CustomerAddresses).SingleOrDefaultAsync();
        }





    }
}

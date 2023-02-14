using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Models;

namespace Backend.Repositories
{
    public class CustomerAddressRepository : RepositoryBase<CustomerAddress>, ICustomerAddressRepository
    {
        private readonly CustomerDBContext _dbcontext;
        public CustomerAddressRepository(CustomerDBContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;

        }
        public int GetNextId()
        {
            return this._dbcontext.CustomerAddress.Max(x => x.Id);
        }



    }
}

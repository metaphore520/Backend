using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Models;

namespace Backend.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        private readonly CustomerDBContext _dbcontext;
        public CountryRepository(CustomerDBContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;

        }

        public int GetNextId()
        {
            return this._dbcontext.Customer.Max(x => x.Id);
        }


    }
}

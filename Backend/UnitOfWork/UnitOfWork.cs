using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Repositories;

namespace Backend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly ICustomerAddressRepository _CustomerAddressRepository;
        private readonly CustomerDBContext _dbcontext;
        public UnitOfWork(CustomerDBContext dbcontext,ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository,
            ICountryRepository countryRepository)
        {
            this._CountryRepository = countryRepository;
            this._CustomerRepository = customerRepository;
            this._CustomerAddressRepository = customerAddressRepository;
            this._dbcontext = dbcontext;
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (_CountryRepository == null)
                {
                    return new CountryRepository(_dbcontext);
                }

                return _CountryRepository;
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_CustomerRepository == null)
                {
                    return new CustomerRepository(_dbcontext);
                }

                return _CustomerRepository;
            }
        }
        public ICustomerAddressRepository CustomerAddressRepository
        {
            get
            {
                if (_CustomerAddressRepository == null)
                {
                    return new CustomerAddressRepository(_dbcontext);
                }
                return _CustomerAddressRepository;
            }
        }
    }
}

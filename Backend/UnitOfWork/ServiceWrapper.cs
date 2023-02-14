using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Services;

namespace Backend.UnitOfWork
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly ICountryService _CountryService;
        private readonly ICustomerAddressService _CustomerAddressService;
        private readonly ICustomerService _CustomerService;
        private readonly IUnitOfWork _unitOfWork;
  

        public ServiceWrapper(
        IUnitOfWork unitOfWork, 
            ICountryService countryService, 
            ICustomerAddressService customerAddressService, ICustomerService customerService)
        {

            _CountryService = countryService;
            _CustomerAddressService = customerAddressService;
            _CustomerService = customerService;
            _unitOfWork = unitOfWork;
        }
        public ICountryService CountryService
        {
            get
            {

                if (_CountryService == null)
                {
                    new CountryService(_unitOfWork);
                }
                return _CountryService;

            }


        }
        public ICustomerAddressService CustomerAddressService
        {
            get
            {
                if (_CustomerAddressService == null)
                {
                    new CustomerAddressService(_unitOfWork);
                }
                return _CustomerAddressService;

            }
        }

        public ICustomerService CustomerService
        {

            get
            {
                if (_CustomerService == null)
                {
                    new CustomerService(_unitOfWork);
                }
                return _CustomerService;


            }
        }


    }
}

using Backend.Contracts;

namespace Backend.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}

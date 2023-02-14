using Backend.Contracts;

namespace Backend.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork  _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

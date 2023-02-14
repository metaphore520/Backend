using Backend.Models;

namespace Backend.Contracts
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {

        int GetNextId();

    }
}

namespace Backend.Contracts
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get;  }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        ICustomerRepository CustomerRepository { get; }
    }
}

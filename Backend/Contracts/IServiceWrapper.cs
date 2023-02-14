namespace Backend.Contracts
{
    public interface IServiceWrapper
    {
        ICountryService CountryService { get; }
        ICustomerAddressService CustomerAddressService { get; }
        ICustomerService CustomerService { get; }

    }
}

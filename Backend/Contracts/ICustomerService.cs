using Backend.ApiModels;

namespace Backend.Contracts
{
    public interface ICustomerService
    {
        Task AddCustomer(PostCustomerApiModelNew model);
        Task<GetCustomerApiModel> GetAllCustomer();
        Task<GetCustomerByIdApiModel> GetCustomerById(int id);
        Task EditCustomer(PostCustomerApiModelNew model);
        Task DeleteCustomerById(int id);

    }
}

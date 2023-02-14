using Backend.ApiModels;
using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceWrapper _services;
        private readonly IConfiguration _configuration;
        
        public CustomerController(IConfiguration configuration,CustomerDBContext context, IUnitOfWork unitOfWork, IServiceWrapper serviceWrapper)
        {
            _configuration = configuration;
            _context = context;
            _unitOfWork = unitOfWork;
            _services = serviceWrapper;
        }
        [HttpGet(Name = "GetAllCountry")]
        [Route("getAllCountry")]
        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            return await this._unitOfWork.CountryRepository.GetAll();
        }

        [HttpPost(Name = "AddCustomer")]
        [Route("addCustomer")]
        public async Task AddCustomer(PostCustomerApiModelNew posted_customer)
        {
            await _services.CustomerService.AddCustomer(posted_customer); 
        }

        [HttpGet(Name = "GetAllCustomer")]
        [Route("getAllCustomer")]
        public async Task<GetCustomerApiModel> GetAllCustomer()
        {
            return await this._services.CustomerService.GetAllCustomer();
        }

        [HttpGet(Name = "GetCustomerById")]
        [Route("getCustomerById")]
        public async Task<GetCustomerByIdApiModel> GetCustomerById(int id)
        {
            return await this._services.CustomerService.GetCustomerById(id);
        }

        [HttpPost(Name = "EditCustomer")]
        [Route("editCustomer")]
        public async Task EditCustomer(PostCustomerApiModelNew posted_customer)
        {
            await _services.CustomerService.EditCustomer(posted_customer);
        }


        [HttpGet(Name = "DeleteCustomerById")]
        [Route("deleteCustomerById")]
        public async Task DeleteCustomerById(int id)
        {
            await this._services.CustomerService.DeleteCustomerById(id);
        }
    }
}

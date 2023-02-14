using Backend.ApiModels;
using Backend.Contracts;
using Backend.Models;

namespace Backend.Services
{
    public static class HelperService
    {

        public static void MapCustomer(CustomerTemp customerTemp, Customer customer)
        {
            customer.FatherName = customerTemp.FatherName;
            customer.CustomerName = customerTemp.CustomerName;
            customer.MotherName = customerTemp.MotherName;
            customer.CustomerPhoto = customerTemp.CustomerPhoto;
            customer.MaritalStatus = customerTemp.MaritalStatus;
            customer.CountryId = customerTemp.CountryId;
            customer.Id = customerTemp.Id;

        }



    }
}

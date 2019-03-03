using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDPJCustomerInfo.Data
{
    public class CustomerInfoManager
    {
        private readonly IRestService restService;

        public CustomerInfoManager(IRestService service)
        {
            restService = service;
        }

        public Task AddCustomerInfo(CustomerInfo customer)
        {
            return restService.AddCustomerInfoAsync(customer);
        }

        public Task DeleteCustomerInfo(long id)
        {
            return restService.DeleteCustomerInfoAsync(id);
        }

        public Task<List<CustomerInfo>> GetCustomerInfosAsync(string param)
        {
            return restService.GetCustomerInfosAsync(param);
        }

        public Task UpdateCustomerInfo(CustomerInfo customer)
        {
            return restService.UpdateCustomerInfoAsync(customer);
        }
    }
}

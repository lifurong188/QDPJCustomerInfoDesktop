using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDPJCustomerInfo.Data
{
    public interface IRestService
    {
        Task<List<CustomerInfo>> GetCustomerInfosAsync(string param);

        Task AddCustomerInfoAsync(CustomerInfo customer);

        Task UpdateCustomerInfoAsync(CustomerInfo customer);

        Task DeleteCustomerInfoAsync(long id);

        Task<List<Address>> GetAddressesAsync();
    }
}

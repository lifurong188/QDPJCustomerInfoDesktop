using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDPJCustomerInfo.Data
{
    public class AddressManager
    {
        private readonly IRestService restService;

        public AddressManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Address>> GetAddressesAsync()
        {
            return restService.GetAddressesAsync();
        }
    }
}

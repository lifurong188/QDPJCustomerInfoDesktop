using Newtonsoft.Json;
using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QDPJCustomerInfo.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        List<CustomerInfo> customers;

        List<Address> addresses;

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task AddCustomerInfoAsync(CustomerInfo customer)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"             TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteCustomerInfoAsync(long id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"             TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
        }

        public async Task<List<CustomerInfo>> GetCustomerInfosAsync(string param)
        {
            customers = new List<CustomerInfo>();

            var uri = new Uri(string.Format(Constants.RestUrl, HttpUtility.UrlEncode(param)));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<List<CustomerInfo>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }

            return customers;
        }

        public async Task UpdateCustomerInfoAsync(CustomerInfo customer)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, customer.Id));

            try
            {
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"CustomerInfo saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        public async Task<List<Address>> GetAddressesAsync()
        {
            addresses = new List<Address>();

            var uri = new Uri(string.Format(Constants.AddressesUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    addresses = JsonConvert.DeserializeObject<List<Address>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }

            return addresses;
        }
    }
}

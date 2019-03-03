using QDPJCustomerInfo.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QDPJCustomerInfo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static CustomerInfoManager customerInfoManager { get; private set; }
        public static AddressManager addressManager { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var restService = new RestService();
            customerInfoManager = new CustomerInfoManager(restService);
            addressManager = new AddressManager(restService);
        }
    }
}

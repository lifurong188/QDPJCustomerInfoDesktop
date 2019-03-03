using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QDPJCustomerInfo
{
    /// <summary>
    /// EditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditWindow : Window
    {
        CustomerInfo cloned = new CustomerInfo();
        public EditWindow(string editOrNew, CustomerInfo cust)
        {
            string title = "";
            
            if (editOrNew == "edit")
            {
                title = "编辑客户信息";
                //复制信息
                cloned.CustCode = cust.CustCode;
                cloned.CustName = cust.CustName;
                cloned.CustLevel = cust.CustLevel;
                cloned.Area = cust.Area;
                cloned.Address = cust.Address;
                cloned.Linkman = cust.Linkman;
                cloned.PhoneNum = cust.PhoneNum;
                cloned.Id = cust.Id;
            }
            else if (editOrNew == "new")
            {
                title = "新增客户信息";
                cloned = cust;
            }

            InitializeComponent();
            
            this.DataContext = cloned;
            this.lblTitle.Content = title;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Address> addresses = await App.addressManager.GetAddressesAsync();
            this.cboAddress.ItemsSource = addresses;
            this.cboAddress.SelectedItem = addresses.SingleOrDefault(a=>a.Id == (this.DataContext as CustomerInfo).Address.Id);
        }

        #region 窗口拖动及关闭按钮的样式和事件
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Point position = e.GetPosition(lblTitle);

            // 如果鼠标位置在标题栏内，允许拖动  
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (position.X >= 0 && position.X < lblTitle.ActualWidth && position.Y >= 0 && position.Y < lblTitle.ActualHeight)
                {
                    this.DragMove();
                }
            }
        }

        #endregion

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            cloned.Address = this.cboAddress.SelectedItem as Address;
            if (this.Title.StartsWith("新增"))
            {
                await App.customerInfoManager.AddCustomerInfo(cloned);
            }
            else
            {
                await App.customerInfoManager.UpdateCustomerInfo(cloned);
            }
            
            MessageBox.Show("保存成功!","提示",MessageBoxButton.OK,MessageBoxImage.Information);
            this.Close();
        }
    }
}

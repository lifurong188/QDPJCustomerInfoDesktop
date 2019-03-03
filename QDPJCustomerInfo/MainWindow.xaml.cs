using QDPJCustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QDPJCustomerInfo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string connString = "Data Source=192.168.1.10;Initial Catalog=QDPJCustomerInfo;User Id=sa;Password=";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Query();
            }
            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            Query();
        }

        private async void Query()
        {
            if(string.IsNullOrEmpty(this.txtKeyWord.Text))
            {
                MessageBox.Show("请填写关键字","提示",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            var param = this.txtKeyWord.Text.Trim();
            var customers = await App.customerInfoManager.GetCustomerInfosAsync(param);

            this.dgvCustomers.ItemsSource = customers;
            this.tbRowCount.Text = "共" + customers.Count + "条数据";
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new EditWindow("new",new CustomerInfo() { Address = new Address() { Id = 1 } }).ShowDialog();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo cust = dgvCustomers.Items[dgvCustomers.SelectedIndex] as CustomerInfo;
            new EditWindow("edit", cust).ShowDialog();
            Query();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfo cust = dgvCustomers.Items[dgvCustomers.SelectedIndex] as CustomerInfo;
            if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel) { return; }
            await App.customerInfoManager.DeleteCustomerInfo(cust.Id);
            Query();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDPJCustomerInfo.Models
{
    public class CustomerInfo : INotifyPropertyChanged
    {
        public long Id { get; set; }
        private string custCode;
        /// <summary>
        /// 终端编码
        /// </summary>
        /// <value>The cust code.</value>
        public string CustCode
        {
            get { return custCode; }
            set
            {
                custCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustCode"));
            }
        }
        private string area = "晋中市";
        /// <summary>
        /// 地区
        /// </summary>
        /// <value>The area.</value>
        public string Area
        {
            get { return area; }
            set
            {
                area = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            }
        }
        private string custName;
        /// <summary>
        /// 终端名称
        /// </summary>
        /// <value>The name of the cust.</value>
        public string CustName
        {
            get { return custName; }
            set
            {
                custName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustName"));
            }
        }
        private int custLevel = 4;
        /// <summary>
        /// 客户级别
        /// </summary>
        /// <value>The cust level.</value>
        public int CustLevel
        {
            get { return custLevel; }
            set
            {
                custLevel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustLevel"));
            }
        }
        private string linkman;
        /// <summary>
        /// 联系人
        /// </summary>
        /// <value>The linkman.</value>
        public string Linkman
        {
            get { return linkman; }
            set
            {
                linkman = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Linkman"));
            }
        }
        private string phoneNum;
        /// <summary>
        /// 电话号码
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNum
        {
            get { return phoneNum; }
            set
            {
                phoneNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNum"));
            }
        }
        private Address address;
        /// <summary>
        /// 地址
        /// </summary>
        /// <value>The address.</value>
        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Address"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

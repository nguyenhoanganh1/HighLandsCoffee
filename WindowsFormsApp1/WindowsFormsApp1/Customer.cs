using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Customer
    {
        string id;
        string fullName;
        string address;
        string phoneNumber;
        public Customer()
        {

        }

        public Customer(string id , string fullName, string address, string phoneNumber)
        {
            this.id = id;
            this.fullName = fullName;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Id { get => id; set => id = value; }
    }
}

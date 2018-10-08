using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderDetails
    {
        public string name;
        public string customer;
        public int count;
        public int price;

        public void ChangeName(string s)
        {
            name = s;
        }
        public void ChangeCustomer(string s)
        {
            customer = s;
        }
        public void ChangeCount(int n)
        {
            count = n;
        }
        public void ChangePrice(int n)
        {
            price = n;
        }

        public OrderDetails(string name, string customer, int count, int price)
        {
            this.name = name;
            this.customer = customer;
            this.count = count;
            this.price = price;
        }
        
    }
}

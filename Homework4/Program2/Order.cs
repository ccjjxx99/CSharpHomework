using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Order
    {
        public string ID;
        public List<OrderDetails> DetailList = new List<OrderDetails>();
        public Order(string id)
        {
            ID = id;
        }

        public void AddDetails(OrderDetails orderDetails)
        {
            DetailList.Add(orderDetails);
        }
        
        public void ChangeDetails(OrderDetails orderDetails, string s)
        {
            
        }

    }
}

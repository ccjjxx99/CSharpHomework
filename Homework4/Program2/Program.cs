using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            Order order1 = new Order("A1");
            OrderDetails details1 = new OrderDetails("b1", "aaa", 1, 20);
            OrderDetails details2 = new OrderDetails("b2", "bbb", 2, 25);
            order1.AddDetails(details1);
            order1.AddDetails(details2);
            Order order2 = new Order("A2");
            OrderDetails details3 = new OrderDetails("c1", "ccc", 5, 50);
            OrderDetails details4 = new OrderDetails("c2", "ddd", 8, 8);
            order2.AddDetails(details3);
            order2.AddDetails(details4);
            os.orders.Add(order1);
            os.orders.Add(order2);
            order1.DetailList[0].ChangeCustomer("eee");
            os.FindOrderWithID("A2");
            os.FindOrderWithCustomer("eee");
            os.FindOrderWithName("c2");
            os.DeleteOrder(order2);
            os.FindOrderWithName("c1");
        }
    }
}

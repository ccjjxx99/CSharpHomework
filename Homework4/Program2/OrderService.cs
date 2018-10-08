using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderService
    {
        public List<Order> orders = new List<Order>();
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public Order FindOrderWithID(string s)
        {
            int index = -1;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].ID == s) index = i;
            }
            try
            {
                Order order = orders[index];
                Console.WriteLine("This is the order with ID:" + s);
                for (int i = 0; i < order.DetailList.Count; i++)
                {
                    Console.WriteLine(order.DetailList[i].name + "\t" + order.DetailList[i].customer +
                        "\t" + order.DetailList[i].count + "\t" + order.DetailList[i].price);
                }
                return order;
            }
            catch
            {
                Console.WriteLine("There is no order with ID " + s);
            }
            return null;
        }

        public Order FindOrderWithName(string s)
        {
            int index = -1;
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < orders[i].DetailList.Count; j++)
                if (orders[i].DetailList[j].name == s) index = i;
            }
            try
            {
                Order order = orders[index];
                Console.WriteLine("This is the order with name " + s + " ID:" + order.ID);
                for (int i = 0; i < order.DetailList.Count; i++)
                {
                    Console.WriteLine(order.DetailList[i].name + "\t" + order.DetailList[i].customer +
                        "\t" + order.DetailList[i].count + "\t" + order.DetailList[i].price);
                }
                return order;
            }
            catch
            {
                Console.WriteLine("There is no order with name " + s);
            }
            return null;
        }

        public Order FindOrderWithCustomer(string s)
        {
            int index = -1;
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < orders[i].DetailList.Count; j++)
                    if (orders[i].DetailList[j].customer == s) index = i;
            }
            try
            {
                Order order = orders[index];
                Console.WriteLine("This is the order with customer " + s + " ID:" + order.ID);
                for (int i = 0; i < order.DetailList.Count; i++)
                {
                    Console.WriteLine(order.DetailList[i].name + "\t" + order.DetailList[i].customer +
                        "\t" + order.DetailList[i].count + "\t" + order.DetailList[i].price);
                }
                return order;
            }
            catch
            {
                Console.WriteLine("There is no order with customer " + s);
            }
            return null;
        }

        public void DeleteOrder(Order order)
        {
            orders.Remove(order);
        }

    }
}

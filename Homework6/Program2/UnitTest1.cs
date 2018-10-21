using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Program2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOrderTest1()
        {
            //正确输入
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            //正确结果
            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            result[1] = order1;
            CollectionAssert.AreEqual(os.Dic, result);
        }

        /// <summary>
        /// 检测非法输入，添加订单
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void AddOrderTest2()
        {
            //非法输入
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order1);//重复添加
        }

        /// <summary>
        /// 检测正确输入，删除订单
        /// </summary>
        [TestMethod]
        public void RemoveOrderTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer1);
            order1.AddDetail(orderDetails1);
            order2.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.RemoveOrder(1);

            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            result[2] = order2;
            CollectionAssert.AreEqual(os.Dic, result);
        }


        /// <summary>
        /// 检测错误输入，删除订单
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveOrderTest2()
        {
            OrderService os = new OrderService();
            os.RemoveOrder(1);
        }


        /// <summary>
        /// 正确输入，通过id获得order
        /// </summary>
        [TestMethod]
        public void GetOrderByIdTest1()
        {
            //正确输入
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Order order = os.GetOrderById(1);
            //正确结果
            Assert.AreEqual(order1, order);
        }

        /// <summary>
        /// 错误输入，通过id获得order
        /// </summary>        
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void GetOrderByIdTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Order order = os.GetOrderById(2);
        }

        /// <summary>
        /// 正确输入，通过商品名获得order
        /// </summary>
        [TestMethod]
        public void GetOrderByNameTest1()
        {
            //正确输入
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.GetOrderByName("Milk");
            //正确结果
            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(result, list);
        }

        /// <summary>
        ///  错误输入，通过商品名获得order
        /// </summary>
        [TestMethod]
        public void GetOrderByNameTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.GetOrderByName("Milkkkk");
            int result = 0;
            Assert.AreEqual(list.Count, result);
        }

        /// <summary>
        /// 正确输入，通过客户名获得order,错误输入同上
        /// </summary>
        [TestMethod]
        public void GetOrderByCustomerTest()
        {
            //正确输入
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 20);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.GetOrderByCustomer("Customer1");
            //正确结果
            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(result, list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Program1
{
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService
    {

        public Dictionary<string, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<string, Order>();
        }


        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(string orderId)
        {
            orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(string orderId)
        {
            return orderDict[orderId];
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var que = from o in orderDict.Values
                      from d in o.details
                      where d.Goods.Name == goodsName
                      select o;
            return que.ToList();
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(string orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        public List<Order> GetBigger()
        {
            var query = orderDict.Values
                .Where(order => order.Money() > 70);
            return query.ToList();
        }


        /// <summary>
        /// 序列化类到xml文档
        /// </summary>
        /// <param name="order">要序列化的对象</param>
        /// <param name="filePath">xml文档路径（包含文件名）</param>
        /// <returns>成功：true，失败：false</returns>
        public bool Export(Order order, string filePath)
        {
            XmlWriter writer = null;    //声明一个xml编写器
            XmlWriterSettings writerSetting = new XmlWriterSettings //声明编写器设置
            {
                Indent = true,//定义xml格式，自动创建新的行
                Encoding = UTF8Encoding.UTF8,//编码格式
            };

            try
            {
                //创建一个保存数据到xml文档的流
                writer = XmlWriter.Create(filePath, writerSetting);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建xml文档失败：{0}", ex.Message);
                return false;
            }

            XmlSerializer xser = new XmlSerializer(typeof(Order));  //实例化序列化对象

            try
            {
                xser.Serialize(writer, order);  //序列化对象到xml文档
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建xml文档失败：{0}", ex.Message);
                return false;
            }
            finally
            {
                writer.Close();
            }
            return true;

        }

        /// <summary>
        /// 从 XML 文档中反序列化为对象
        /// </summary>
        /// <param name="filePath">文档路径（包含文档名）</param>
        /// <param name="type">对象的类型</param>
        /// <returns>返回object类型</returns>
        public static object Import(string filePath, Type type)
        {
            string xmlString = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(xmlString))
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                try
                {
                    return serializer.Deserialize(stream);
                }
                catch
                {
                    return null;
                }
            }

        }
        /*other edit function with write in the future.*/
    }
}

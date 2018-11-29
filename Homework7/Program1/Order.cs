using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    /// <summary>
    /// Order class : all orderDetails
    /// to record each goods and its quantity in this ordering
    /// </summary>
    public class Order
    {

        [Key]
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> details { get; set; }
        
        public Order()
        {
            details = new List<OrderDetail>();
        }
        
        public Order(string orderId, Customer customer)
        {
            details = new List<OrderDetail>();
            Id = orderId;
            Customer = customer;
        }

        
        public void AddDetails(OrderDetail orderDetail)
        {
            if (details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }
        
        public void RemoveDetails(string orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }
        
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }

        public double Money()
        {
            double sum = 0;
            foreach (OrderDetail orderDetail in details)
            {
                sum += (orderDetail.Goods.Price * orderDetail.Quantity);
            }
            return sum;
        }
    }
}

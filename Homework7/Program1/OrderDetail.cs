using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public uint Quantity { get; set; }
        public Goods Goods { get; set; }
        
        public OrderDetail(string id, Goods goods, uint quantity)
        {
            Id = id;
            Goods = goods;
            Quantity = quantity;
        }

        public OrderDetail() { }
        

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Id == detail.Goods.Id &&
                Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the OrderDetail object</returns>
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }


    }
}

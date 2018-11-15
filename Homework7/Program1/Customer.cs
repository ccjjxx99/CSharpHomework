using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    /// <summary>
    /// Customer the man who orders goods.
    /// </summary>
    public class Customer
    {

        /// <summary>
        /// customer's identifier
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// customer's name
        /// </summary>
        public string Name { get; set; }
        public string Phone { get; set; }


        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="id">customer id</param>
        /// <param name="name">customer name </param>
        public Customer(uint id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public Customer() { }
        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Customer object</returns>
        public override string ToString()
        {
            return $"customerId:{Id}, Name:{Name}, Phone:{Phone}";
        }


    }
}


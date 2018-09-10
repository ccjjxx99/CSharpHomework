using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Please input two numbers:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("The product of " + a + " and " + b + " is " + (a * b));
        }
    }
}

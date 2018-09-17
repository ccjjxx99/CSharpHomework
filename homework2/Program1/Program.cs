using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.Write("Please input the range from:");
            a = int.Parse(Console.ReadLine());
            Console.Write("to:");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("The prime numbers from " + a + " to " + b + " are: ");
            for (int i = a; i < b; i++)
            {
                if (i <= 1) i = 2;
                bool flag = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) flag = false;
                }

            
                if (flag)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}

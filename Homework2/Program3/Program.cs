using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The prime numbers from 2 to 100 are:");
            int[] a = new int[99];

            for (int i = 0; i < 99; i++)
            {
                a[i] = i + 2;
            }
            for (int i = 2; i < 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    if (j == i) continue;
                    if (j % i == 0) a[j - 2] = 0;
                }
            }
            for (int i = 0; i < 99; i++)
            {
                if (a[i] != 0) Console.Write(a[i] + " ");
            }
        }
    }
}

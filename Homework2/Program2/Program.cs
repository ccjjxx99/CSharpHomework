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
            Console.WriteLine("Please input a set of numbers (separate by spaces and end by enter):");
            String s = Console.ReadLine();
            String[] sA = s.Split(' ');
            int[] a = new int[sA.Length];
            for (int i = 0; i < sA.Length; i++)
            {
                a[i] = int.Parse(sA[i]);
            }
            int min = a[0];
            int max = a[0];
            int sum = 0;
            double avr;
            for (int i = 0; i < sA.Length; i++)
            {
                if (a[i] < min) min = a[i];
                if (a[i] > max) max = a[i];
                sum += a[i];
            }
            avr = (double)sum / a.Length;
            Console.WriteLine("The minimum is " + min);
            Console.WriteLine("The maximum is " + max);
            Console.WriteLine("The sum is " + sum);
            Console.WriteLine("The average is " + avr);
        }
    }
}

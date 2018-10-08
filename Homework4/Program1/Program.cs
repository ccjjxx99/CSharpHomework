using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program1
{
    class Clock
    {
        public delegate void ClockEventHandler();
        public event ClockEventHandler ClockEvent;
        public void TimeOut()
        {
            ClockEvent?.Invoke(); //调用委托
        }
    }
    class Ringer
    {
        public void Ring()
        {
            Console.WriteLine("Ding ding ding~~~");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int h, m;
            Console.WriteLine("Please set hour:");
            while (true)
            {
                string sh = Console.ReadLine();
                try
                {
                    h = int.Parse(sh);
                    if (h < 0 || h > 23)
                    {
                        Console.WriteLine("Format wrong, please reset:");
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Format wrong, please reset:");
                }
            }

            Console.WriteLine("Please set minute:");
            
            while (true)
            {
                string sm = Console.ReadLine();
                try
                {
                    m = int.Parse(sm);
                    if (m < 0 || m > 59)
                    {
                        Console.WriteLine("Format wrong, please reset:");
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Format wrong, please reset:");
                }
            }
            Clock clock = new Clock();
            while(h != DateTime.Now.Hour || m != DateTime.Now.Minute)
            {
                Thread.Sleep(100);

            }
            Ringer ringer = new Ringer();
            clock.ClockEvent += ringer.Ring;
            clock.TimeOut();
        }
    }
}

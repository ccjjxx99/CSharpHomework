using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    public interface IGraph
    {
        void SetParameter(int a, int b);
        void ShowArea();
    }

    public class Triangle : IGraph
    {
        int a;
        int b;
        public void SetParameter(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void ShowArea()
        {
            Console.WriteLine("The area of the triangle is " + (0.5 * a * b));
        }
    }

    public class Circle : IGraph
    {
        int a;
        public void SetParameter(int a, int b = 0)
        {
            this.a = a;
        }
        public void ShowArea()
        {
            Console.WriteLine("The area of the circle is " + (3.14 * a * a));
        }
    }

    public class Square : IGraph
    {
        int a;
        public void SetParameter(int a, int b = 0)
        {
            this.a = a;
        }
        public void ShowArea()
        {
            Console.WriteLine("The area of the Square is " + (a * a));
        }
    }

    public class Rectangle : IGraph
    {
        int a;
        int b;
        public void SetParameter(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void ShowArea()
        {
            Console.WriteLine("The area of the rectangle is " + (a * b));
        }
    }

    public class GraphFactory
    {
        public static IGraph GetGraph(String type)
        {
            IGraph graph = null;
            if (type == "triangle")
            {
                graph = new Triangle();
            }
            else if (type == "circle")
            {
                graph = new Circle();
            }
            else if (type == "Square")
            {
                graph = new Square();
            }
            else if (type == "rectangle")
            {
                graph = new Rectangle();
            }
            return graph;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph;
            graph = GraphFactory.GetGraph("triangle");
            graph.SetParameter(5,2);
            graph.ShowArea();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Puzzlers.Wagner.Dynamic
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        // Your own method fixes this:
        //public void DisplayPrice()
        //{
        //    Console.WriteLine("The price of one {0} is {1}", Name, Cost);
        //}
    }

    class Program
    {
        static void Main3(string[] args)
        {
            // use var
            var thing1 = new Product { Name = "guitar", Cost = 1200 };
            thing1.DisplayPrice();
            // use static:
            dynamic thing2 = thing1;
            MyExtensions.DisplayPrice(thing2);

            // use var
            dynamic thing3 = new Product { Name = "guitar", Cost = 1200 };
            thing3.DisplayPrice();
        }
    }

    public static class MyExtensions
    {
        public static void DisplayPrice(this Product item)
        {
            Console.WriteLine("The price of one {0} is {1}", item.Name, item.Cost);
        }
    }
}

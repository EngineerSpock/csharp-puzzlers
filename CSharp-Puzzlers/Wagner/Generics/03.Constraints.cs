using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Puzzlers.Wagner.Generics
{
    public interface IFoo
    {
        void FooThings();
    }
    public interface IBar
    {
        void BarThings();
    }

    public class Foo : IFoo, IBar
    {
        public void FooThings()
        {
            Console.WriteLine("Doing Foo things");
        }

        public void BarThings()
        {
            Console.WriteLine("Doing Bar things");
        }
    }

    public static class ExtensionMethods
    {
        public static void Extend<T>(this T item) where T : IBar
        {
            item.BarThings();
        }
        public static void Extend(this IFoo item)
        {
            item.FooThings();
        }
    }

    class Program2
    {
        static void Main2(string[] args)
        {
            var f1 = new Foo();
            f1.Extend();

			((IFoo)f1).Extend();

			//

            IFoo f2 = new Foo();
            f2.Extend();

            IBar b = new Foo();
            b.Extend();
        }
    }
}

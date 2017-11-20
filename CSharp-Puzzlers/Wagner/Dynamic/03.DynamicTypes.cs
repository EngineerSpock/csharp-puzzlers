using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Puzzlers.Wagner.Dynamic
{
    class MyDynamicObject : DynamicObject
    {
        public override bool TryBinaryOperation(BinaryOperationBinder binder,
            object arg, out object result)
        {
            Console.WriteLine("TryBinaryOperation for {0}", binder.Operation);
            result = "dynamically returned result";
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type.Name.Contains("IEnumerable"))
            {
                result = new string[] { "dynamically", "returned", "result" };
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }


    class Program2
    {
        static void Main(string[] args)
        {
            dynamic d = new MyDynamicObject();
            Console.WriteLine(d == null);
            var sequence = (IEnumerable)d;
            //IEnumerable sequence = d;

            Console.WriteLine(sequence == null);
            foreach (var item in sequence)
                Console.WriteLine(item);

            foreach (var item in d)
                Console.WriteLine(item);


        }
    }
}

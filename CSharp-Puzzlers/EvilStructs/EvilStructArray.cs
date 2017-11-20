using System;
using System.Collections.Generic;

namespace CSharp_Puzzlers.EvilStructs.Array
{
    struct Customer
    {
        public int Age { get; private set; }

        public Customer(int age) : this()
        {
            Age = age;
        }

        public int IncrementAge()
        {
            Age++;
            return Age;
        }
    }

    public class CustomerClient
    {
        public void Test()
        {
            var list = new List<Customer> {new Customer(age: 5)};

            Console.WriteLine((string) "Initial Age: {0}", (object) list[0].Age);
            list[0].IncrementAge(); // Change of tmp variable
            Console.WriteLine((string) "Modified Age: {0}", (object) list[0].Age);

            //----------

            var array = new [] { new Customer(age: 5) };
            Console.WriteLine((string) "Initial Age: {0}", (object) array[0].Age);            
            array[0].IncrementAge();
            Console.WriteLine((string) "Modified Age: {0}", (object) array[0].Age);
        }
    }
}

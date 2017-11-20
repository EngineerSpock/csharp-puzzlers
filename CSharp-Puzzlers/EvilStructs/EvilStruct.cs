using System;

namespace CSharp_Puzzlers.EvilStructs {
    struct Customer {
        public int Age { get; private set; }

        public Customer(int age) : this() {
            Age = age;
        }

        public int IncrementAge() {
            Age++;
            return Age;
        }
    }

    class CustomerClient {
        public Customer PropertyCustomer { get; }

        public readonly Customer ReadonlyCustomer;

        public Customer FieldCustomer;


        public CustomerClient() {
            PropertyCustomer = new Customer(1);
            ReadonlyCustomer = new Customer(1);
            FieldCustomer = new Customer(1);
        }

        public void Test() {
            Console.WriteLine("Property case");
            Console.WriteLine((int) PropertyCustomer.IncrementAge());
            Console.WriteLine((int) PropertyCustomer.IncrementAge());

            Console.WriteLine("Readonly case");
            Console.WriteLine((int) ReadonlyCustomer.IncrementAge());
            Console.WriteLine((int) ReadonlyCustomer.IncrementAge());

            #region Readonly case

            Customer c1 = ReadonlyCustomer;
            c1.IncrementAge();
            Customer c2 = ReadonlyCustomer;
            c2.IncrementAge();

            #endregion

            Console.WriteLine("Field case");
            Console.WriteLine((int) FieldCustomer.IncrementAge());
            Console.WriteLine((int) FieldCustomer.IncrementAge());
        }
    }

    internal struct Point {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) : this() {
            X = x;
            Y = y;
        }

        public Point Increment(int x, int y) {
            return new Point(x, y);
        }
    }
}
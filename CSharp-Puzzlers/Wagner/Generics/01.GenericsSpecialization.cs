using System;

namespace CSharp_Puzzlers.Wagner.Generics
{
    public class A {
        public override string ToString() {
            return "In class A";
        }
    }

    public class B : A {
        public override string ToString() {
            return "In class B";
        }
    }

    public class Engine {
        public string Run<T>(T param) {
            return $"Generic: {param}";
        }
        public string Run(A param) {
            return $"Specialization: {param}";
        }
    }

    public class GenericsSpecialization
    {
        public static void Test() {            
            var engine = new Engine();

            //whine one is a better match?

            var result = engine.Run(new A());
            Console.WriteLine(result);

            //T takes a derived class - better match!
            result = engine.Run(new B());
            Console.WriteLine(result);

            /////
            // dynamic
            /////

            dynamic dynamicResult1 = engine.Run(new A());
            Console.WriteLine(result);

            //T takes a derived class - better match!
            dynamic dynamicResult2 = engine.Run(new B());
            Console.WriteLine(result);

            //specialization is better from performance perspectives
            //spec and generic versions should do the same from the API perspectives
        }
    }
}

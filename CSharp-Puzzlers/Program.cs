using System;
using CSharp_Puzzlers.EvilStructs;
using CSharp_Puzzlers.Wagner;
using CSharp_Puzzlers.Wagner.Generics;

namespace CSharp_Puzzlers
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericsSpecialization.Test();

            MyHandleClient client = new MyHandleClient();
           
            //Ctors order. Fields before ctors. 
            //Unfinished init of a derived class.
            var phone = new Phone();
            phone.Initialize();

            Console.Read();
        }
    }
}

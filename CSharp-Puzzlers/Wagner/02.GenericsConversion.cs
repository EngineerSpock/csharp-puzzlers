using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Puzzlers.Wagner
{
    class GenericsConversion
    {
        void RunPuzzle()
        {
            var ints = new List<int>() {1,2,3,4,5,6,7,8,9,0};

            //works!
            var doubles = ints.Convert<double>().Select(x => x);
            //throws var doubles = from double c in ints select c;
            //throws ints.Cast<double>().Select(x => x);
            //fine   var doubles = from double c in ints select (double)c;

            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }
        }
    }

    public static class Extensions {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                //works!
                dynamic runtimeItem = item;
                yield return (TResult) runtimeItem;
            }
        }
    }
}

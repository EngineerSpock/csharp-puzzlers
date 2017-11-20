using System;
using System.Collections;
using System.Dynamic;
using System.Linq.Expressions;

namespace CSharp_Puzzlers.Wagner.Dynamic.Two
{
    public class MyDynamicObject : IDynamicMetaObjectProvider
    {
        private class DynamicProvider : DynamicMetaObject
        {
            private MyDynamicObject myDynamicObjectMeta;

            public DynamicProvider(MyDynamicObject myDynamicObjectMeta, Expression parameter)
                : base(parameter, BindingRestrictions.Empty, myDynamicObjectMeta)
            {
                this.myDynamicObjectMeta = myDynamicObjectMeta;
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                if (binder.ReturnType == typeof(IEnumerable))
                {
                    // Setup the 'this' reference
                    Expression self = Expression.Convert(Expression, LimitType);
                    var expr = Expression.Call(self, typeof(MyDynamicObject).GetMethod("GetSequence"));
                    var ret = new DynamicMetaObject(expr, BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                    return ret;
                }
                else
                    return base.BindConvert(binder);
            }
        }

        public DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)
        {
            return new DynamicProvider(this, parameter);
        }

        public IEnumerable GetSequence()
        {
            return new string[] { "dynamically", "returned", "result" };
        }
    }


    class Program3
    {
        static void Main2(string[] args)
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

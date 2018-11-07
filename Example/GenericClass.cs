using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{

    public class GenericClass<T1,T2>
    {
        public T1 genericType1;
        private T2 genericType2;

        public T2 GenericType2 { get => genericType2; set => genericType2 = value; }
        public IEnumerable<TM1> NestedGenericMethod<TM1, TM2>(IEnumerable<TM1> data1, IDictionary<String, TM2> data2)
        {
            return data1;
        }
    }
}

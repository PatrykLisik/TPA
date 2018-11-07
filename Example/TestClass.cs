using System;
using System.Collections.Generic;

namespace Example
{

    public class TestClass1
    {
        private int int_1;
        private int int_2;
        private string PrivateString;

        public int Int_2 { get => int_2; set => int_2 = value; }

        public TestClass1(int int_1, int int_2)
        {
            this.int_1 = int_1;
            Int_2 = int_2;
        }

        public void Add<T>(ICollection<T> coll)
        {
            int a = 10;
            a++;

        }
        protected int Sum()
        {
            return int_1 + int_2;
        }

    }
}

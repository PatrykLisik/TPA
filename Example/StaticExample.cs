using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public static class StaticExample
    {
        static List<int> someList;

        public static List<int> SomeList { get => someList; set => someList = value; }

        public static void DoNothing()
        {
            return;
        }
    }
}

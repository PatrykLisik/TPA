using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    public class Main<R>
    {
        int n = 30;
        public int m { set; get; }
        public void fun1() { }
        public int fun2() { return 2; }
        public static int PI() { return 3; }
        public ObservableCollection<int> observableCollection { get; set; }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public R generic;

    }
}

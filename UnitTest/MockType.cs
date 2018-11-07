using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class MockType
    {
        private int int1;
        private int int2;
        private string name;

        public MockType(int int1, int int2, string name)
        {
            this.int1 = int1;
            this.int2 = int2;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public int get42()
        {
            return 42;
        }
    }
}

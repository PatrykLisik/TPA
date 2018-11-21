using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConsolePathGeter : IDLLPathGeter
    {
        public string GetDLLPatch()
        {
            return Console.ReadLine();
        }
    }
}

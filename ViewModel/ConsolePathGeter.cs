using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConsolePathGeter : IFilePathGeter
    {
        public string GetPath(string extension = ".dll")
        {
            return Console.ReadLine();
        }
    }
}

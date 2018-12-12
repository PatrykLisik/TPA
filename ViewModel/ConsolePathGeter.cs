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
            Console.WriteLine("Enter path to file *" + extension);
            return Console.ReadLine();
        }
    }
}

using System;
using System.ComponentModel.Composition;

namespace ViewModel
{
    [Export(typeof(IFilePathGeter))]
    public class ConsolePathGeter : IFilePathGeter
    {
        public string GetPath(string extension = ".dll")
        {
            Console.WriteLine("Enter path to file *" + extension);
            return Console.ReadLine();
        }
    }
}

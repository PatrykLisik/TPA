using Logic.ReflectionMetadata;
using System;
using System.Linq;
using System.Reflection;

namespace TUI2
{
    public class MainClass
    {
        static readonly string pathToDll = @"..\..\..\Logic\bin\Debug\Logic.dll";
        static TuiViewItem rootItem;

        static void Main(string[] args)
        {
            LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                showOptions();
                int Choice = GetIntFromUser();
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
        }

        private static void LoadRootItem()
        {
            Assembly assembly = Assembly.LoadFrom(pathToDll);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            rootItem = new TuiViewItem { Name = assemblyMetadata.m_Name, rest = assemblyMetadata.GetInternals() };
        }

        private static int GetIntFromUser()
        {
            while (true)
            {
                Console.WriteLine("Enter choice: ");
                string input = Console.ReadLine();
                int number=0;
                int.TryParse(input, out number);
                if (!(number == 0) && number -1 < rootItem.Children.Count())
                    return number - 1;
            }
        }

        private static void showOptions()
        {
            int start = 1;
            foreach (TuiViewItem tiv in rootItem.Children)
            {
                Console.WriteLine(start.ToString() + "." + tiv.Name);
                start++;
            }
        }
    }
}

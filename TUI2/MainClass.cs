using Logic.ReflectionMetadata;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Tracer;
using ViewModel.TreeViewItems;

namespace TUI2
{
    public class MainClass
    {
        private static TracerFile tracer = new TracerFile();
        static readonly string pathToDll = @"..\..\..\Logic\bin\Debug\Logic.dll";
        static TreeViewItem rootItem;
        private static int indentLevel = 0;

        static void Main(string[] args)
        {
            tracer.Tracer(TraceEventType.Information, "Program started");
            LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                ShowOptions();
                int Choice = GetIntFromUser();
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
        }

        private static void LoadRootItem()
        {
            Assembly assembly = Assembly.LoadFrom(pathToDll);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            rootItem = new AssemblyMetadataTreeViewItem(assemblyMetadata);
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
                tracer.Tracer(TraceEventType.Warning, "Wrong number input from user!");
            }
        }

        private static void ShowOptions()
        {
            int start = 1;
            tracer.Tracer(TraceEventType.Start, "listing start");
            foreach (TreeViewItem tiv in rootItem.Children)
            {
                Console.WriteLine(new string(' ', indentLevel*4) + start + "." + tiv.Name);
                start++;
            }
            tracer.Tracer(TraceEventType.Stop, "listing stop");
            indentLevel++;
        }
    }
}

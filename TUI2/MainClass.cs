using Logic.ReflectionMetadata;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Tracer;
using Logic;

namespace TUI2
{
    public class MainClass
    {
        private static TracerFile tracer = new TracerFile();
        static readonly string pathToDll = @"..\..\..\Logic\bin\Debug\Logic.dll";
        static TuiViewItem rootItem;
        private static int indentLevel = 0;

        static void Main(string[] args)
        {
            using (var db = new ReflectionDbContext2())
            {
                Assembly assembly = Assembly.LoadFrom(pathToDll);
                AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
                db.all.Add(assemblyMetadata);
                db.SaveChanges();

                var query = from a in db.all
                            select a;
                Console.WriteLine("All things in db: ");
                foreach(var item in query)
                {
                    Console.WriteLine(item.m_Name);
                }
            }
            Console.ReadKey();
            /*
            tracer.Tracer(TraceEventType.Information, "Program started");
            LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                ShowOptions();
                int Choice = GetIntFromUser();
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
            */
        }

        private static void LoadRootItem()
        {
            Assembly assembly = Assembly.LoadFrom(pathToDll);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            rootItem = new TuiViewItem { Name = assemblyMetadata.m_Name, rest = assemblyMetadata.GetInternals() }; //all namespaces
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
            foreach (TuiViewItem tiv in rootItem.Children)
            {
                Console.WriteLine(new string(' ', indentLevel*4) + start + "." + tiv.Name);
                start++;
            }
            tracer.Tracer(TraceEventType.Stop, "listing stop");
            indentLevel++;
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using Tracer;
using ViewModel;
using ViewModel.TreeViewItems;

namespace TUI2
{
    public class TextView
    {
        private static TracerFile tracer = new TracerFile();
        private string pathToDll;
        static TreeViewItem rootItem;
        private static int indentLevel = 0;
        private IDLLPathGeter pathGeter;


        public TextView(IDLLPathGeter pathGeter)
        {
            this.pathGeter = pathGeter;
        }


        public void Run()
        {
            tracer.Tracer(TraceEventType.Information, "Program started");
            pathToDll = pathGeter.GetDLLPatch();
            LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                ShowOptions();
                int Choice = GetIntFromUser();
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
        }

        private void LoadRootItem()
        {
            rootItem = RootItemBuilder.LoadRootItem(pathToDll);
        }

        private static int GetIntFromUser()
        {
            while (true)
            {
                Console.WriteLine("Enter choice: ");
                string input = Console.ReadLine();
                int number = 0;
                int.TryParse(input, out number);
                if (!(number == 0) && number - 1 < rootItem.Children.Count())
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
                Console.WriteLine(new string(' ', indentLevel * 4) + start + "." + tiv.Name);
                start++;
            }
            tracer.Tracer(TraceEventType.Stop, "listing stop");
            indentLevel++;
        }
    }
}

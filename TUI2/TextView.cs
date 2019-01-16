using MEF;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using Tracer;
using ViewModel;
using ViewModel.TreeViewItems;

namespace TUI2
{
    public class TextView
    {
        [ImportMany]
        private static Importer<ITracer> tracer;
        private string pathToDll;
        static TreeViewItem rootItem;
        private static int indentLevel = 0;
        private IFilePathGeter pathGeter;

        public TextView(IFilePathGeter pathGeter)
        {
            this.pathGeter = pathGeter;
            new Bootstrapper().ComposeApplication(this);
        }


        public void Run()
        {
            tracer.GetImport().Trace(TraceEventType.Information, "Program started");
            pathToDll = pathGeter.GetPath();
            LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                ShowOptions();
                int Choice = GetIntFromUser();
                if (Choice == -1)
                {
                    SaveAsync();
                    continue;
                }
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
        }

        private async void LoadRootItem()
        {
            rootItem = await ViewModelSaverLoader.LoadRootItemFromDLLAsync(pathToDll);
        }

        private static int GetIntFromUser()
        {
            while (true)
            {
                Console.WriteLine("Enter choice: (or -1 to Save)");
                string input = Console.ReadLine();
                int number = 0;
                int.TryParse(input, out number);
                if (number == -1) return -1;
                if (!(number == 0) && number - 1 < rootItem.Children.Count())
                    return number - 1;
                tracer.GetImport().Trace(TraceEventType.Warning, "Wrong number input from user!");
            }
        }

        private static void ShowOptions()
        {
            int start = 1;
            tracer.GetImport().Trace(TraceEventType.Start, "listing start");
            foreach (TreeViewItem tiv in rootItem.Children)
            {
                Console.WriteLine(new string(' ', indentLevel * 4) + start + "." + tiv.Name);
                start++;
            }
            tracer.GetImport().Trace(TraceEventType.Stop, "listing stop");
            indentLevel++;
        }

        private async void SaveAsync()
        {
            Console.WriteLine("\nEnter file name:");
            string line = pathGeter.GetPath(".xml");
            if(line != "")
            {
                await ViewModelSaverLoader.SaveDLLToRepositoryAsync(line, pathToDll);
            }
            else
            {
                Console.WriteLine("Empty selection");
            }
        }
    }
}

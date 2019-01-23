using MEF;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracer;
using ViewModel;
using ViewModel.TreeViewItems;

namespace TUI2
{
    public class TextView
    {
        [ImportMany]
        private Importer<ITracer> tracer;
        private string pathToDll;
        static TreeViewItem rootItem;
        private static int indentLevel = 0;
        [ImportMany]
        private Importer<IFilePathGeter> pathGeter;

        public TextView()
        {
            new Bootstrapper().ComposeApplication(this);
        }


        public async Task RunAsync()
        {
            tracer.GetImport().Trace(TraceEventType.Information, "Program started");
            pathToDll = pathGeter.GetImport().GetPath(".dll");
            await LoadRootItem();
            while (true)
            {
                rootItem.IsExpanded = true;
                ShowOptions();
                int Choice = GetIntFromUser();
                if (Choice == -1)
                {
                    await SaveAsync();
                    continue;
                }
                rootItem = rootItem.Children.ToList().ElementAt(Choice);
            }
        }

        private async Task LoadRootItem()
        {
            rootItem = await ViewModelSaverLoader.LoadRootItemFromDLLAsync(pathToDll);
        }

        private int GetIntFromUser()
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

        private void ShowOptions()
        {
            int start = 1;
            //tracer.GetImport().Trace(TraceEventType.Start, "listing start");
            foreach (TreeViewItem tiv in rootItem.Children)
            {
                Console.WriteLine(new string(' ', indentLevel * 4) + start + "." + tiv.Name);
                start++;
            }
            //tracer.GetImport().Trace(TraceEventType.Stop, "listing stop");
            indentLevel++;
        }

        private async Task SaveAsync()
        {
            Console.WriteLine("\nEnter file name:");
            string line = pathGeter.GetImport().GetPath();
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

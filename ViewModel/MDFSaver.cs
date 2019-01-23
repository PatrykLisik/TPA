using Microsoft.Win32;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel
{
    [Export(typeof(RepositorySaver))]
    public class MDFSaver : RepositorySaver
    {
        public async Task SaveFileAsync(string dllPath)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "MDF Files|*.mdf",
                Title = "Save an MDF File"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                await ViewModelSaverLoader.SaveDLLToRepositoryAsync(saveFileDialog1.FileName, dllPath);
            }
            else
            {
                MessageBox.Show("No files selected");
            }
        }
    }
}

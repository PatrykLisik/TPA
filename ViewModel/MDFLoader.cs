using Microsoft.Win32;
using System.ComponentModel.Composition;
using System.Windows;

namespace ViewModel
{
    [Export(typeof(IFilePathGeter))]
    public class MDFLoader : IFilePathGeter
    {

        public string GetPath(string extension = ".mdf")
        {
            OpenFileDialog window = new OpenFileDialog()
            {
                Filter = string.Format("Database mdf file (*{0})| *{0}", extension)
            };
            window.ShowDialog();
            if (window.FileName.Length == 0)
            {
                MessageBox.Show("No files selected");
                return "";
            }

            else
                return window.FileName;
        }
    }
}

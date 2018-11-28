using Microsoft.Win32;
using System.Windows;

namespace ViewModel
{
    public class WindowPathGeter : IFilePathGeter
    {

        public string GetPath(string extension = ".dll")
        {
            OpenFileDialog window = new OpenFileDialog()
            {
                Filter = string.Format("Dynamic Library File(*{0})| *{0}",extension)
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

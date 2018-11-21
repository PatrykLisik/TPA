using Microsoft.Win32;
using System.Windows;

namespace ViewModel
{
    internal class WindowPatchGeter : IDLLPathGeter
    {
        public string GetDLLPatch()
        {
            OpenFileDialog window = new OpenFileDialog()
            {
                Filter = "Dynamic Library File(*.dll)| *.dll"
            };
            window.ShowDialog();
            if (window.FileName.Length == 0)
            {
                MessageBox.Show("No files selected");
                return "";
            }

            else
                return window.FileName
        }
    }
}

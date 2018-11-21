﻿using Microsoft.Win32;
using System.Windows;

namespace ViewModel
{
    public class WindowPathGeter : IFilePathGeter
    {
        public string GetPath()
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
                return window.FileName;
        }
    }
}

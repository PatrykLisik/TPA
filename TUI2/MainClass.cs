using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TUI2
{
    public class MainClass
    {
        static string pathToDll = @"..\..\..\Logic\bin\Debug\Logic.dll";
        static TuiViewItem rootItem;

        static void Main(string[] args)
        {
            LoadRootItem();


        }

        private static void LoadRootItem()
        {
            Assembly assembly = Assembly.LoadFrom(pathToDll);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            rootItem = new TuiViewItem { Name = assemblyMetadata.m_Name, rest = assemblyMetadata.GetInternals() };
        }

    }
}

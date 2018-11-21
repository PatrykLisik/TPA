using Logic.ReflectionMetadata;
using System.Reflection;
using ViewModel.TreeViewItems;

namespace ViewModel
{
    public static class RootItemBuilder
    {
        public static AssemblyMetadataTreeViewItem LoadRootItem(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);
        }
    }
}

using Logic.ReflectionMetadata;
using Logic.Serialization;
using System.Reflection;
using ViewModel.TreeViewItems;

namespace ViewModel
{
    public static class RootItemBuilder
    {
        public static AssemblyMetadataTreeViewItem LoadRootItemFromDLL(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);
        }

        public static AssemblyMetadataTreeViewItem LoadRootItemFromRepository(string path, IRepositoryActions<AssemblyMetadata> repository)
        {
            AssemblyMetadata assemblyMetadata = repository.LoadFromRepository(path);
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);

        }
    }
}

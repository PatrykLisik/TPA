using Logic.ReflectionMetadata;
using Logic.Serialization;
using System.Reflection;
using System.Threading.Tasks;
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

        public static async Task<AssemblyMetadataTreeViewItem> LoadRootItemFromRepositoryAsync(string path, IRepositoryActions<AssemblyMetadata> repository)
        {
            AssemblyMetadata assemblyMetadata = await Task.Run(() => repository.LoadFromRepository(path));
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);

        }
    }
}

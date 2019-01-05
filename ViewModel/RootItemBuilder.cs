using Logic;
using Logic.ReflectionMetadata;
using Repository;
using System.Reflection;
using System.Threading.Tasks;
using ViewModel.TreeViewItems;

namespace ViewModel
{
    public static class ViewModelSaverLoader
    {
        public static async Task<AssemblyMetadataTreeViewItem> LoadRootItemFromDLLAsync(string path)
        {
            AssemblyMetadata assemblyMetadata =  await Task.Run(() =>  GetAssembly(path));
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);
        }

        public static AssemblyMetadata GetAssembly(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            return assemblyMetadata;
        }

        public static async Task<AssemblyMetadataTreeViewItem> LoadRootItemFromRepositoryAsync(string path)
        {
            AssemblyMetadata assemblyMetadata = await Task.Run(() => new AssemblyMetadataRepositoryActions().LoadFromRepository(path));
            return new AssemblyMetadataTreeViewItem(assemblyMetadata);

        }

        public static async Task SaveDLLToRepositoryAsync(string repository, string dllPath)
        {
            await Task.Run(() =>new AssemblyMetadataRepositoryActions().SaveToRepository(GetAssembly(dllPath), repository));
        }
    }
}

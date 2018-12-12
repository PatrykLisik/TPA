using Logic.ReflectionMetadata;
using Serialization;

namespace Logic
{
    public static class AssemblyMetadataRepositoryActions
    {
        private static IRepositoryActions<AssemblyMetadata> repository = new XMLSerializer<AssemblyMetadata>();

        public static AssemblyMetadata LoadFromRepository(string file)
        {
            return repository.LoadFromRepository(file);
        }

        public static void SaveToRepository(AssemblyMetadata assemblyMetsdata, string file)
        {
            repository.SaveToRepository(assemblyMetsdata, file);
        }
    }
}

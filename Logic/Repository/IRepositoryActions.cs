using Logic.ReflectionMetadata;

namespace Repository
{
    public interface IRepositoryActions
    {
        void SaveToRepository(AssemblyMetadata data, string fileName);
        AssemblyMetadata LoadFromRepository(string fileName);
    }
}

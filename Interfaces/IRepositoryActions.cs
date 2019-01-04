using Logic.ReflectionMetadata;

namespace Interfaces
{
    public interface IRepositoryActions
    {
        void SaveToRepository(AssemblyMetadata data, string fileName);
        AssemblyMetadata LoadFromRepository(string fileName);
    }
}

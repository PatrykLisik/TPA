using Logic.ReflectionMetadata;
using SerializationModel.DTO;

namespace Repository
{
    public interface IRepositoryActions
    {
        void SaveToRepository(Assembly_DTO data, string fileName);
        Assembly_DTO LoadFromRepository(string fileName);
    }
}

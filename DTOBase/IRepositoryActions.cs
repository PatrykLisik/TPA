using Model.DTO;

namespace Repository
{
    public interface IRepositoryActions
    {
        void SaveToRepository(AssemblyBaseDTO data, string fileName);
        AssemblyBaseDTO LoadFromRepository(string fileName);
    }
}

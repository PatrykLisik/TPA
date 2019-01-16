using Logic.ReflectionMetadata;
using MEF;
using Logic.Mappers;
using System.ComponentModel.Composition;

namespace Repository
{
    public class AssemblyMetadataRepositoryActions
    {
        [Import]
        private IRepositoryActions repository;


        public AssemblyMetadataRepositoryActions()
        {
            new Bootstrapper().ComposeApplication(this);
        }


        public AssemblyMetadata LoadFromRepository(string file)
        {
            return repository.LoadFromRepository(file).MapToObject();
        }

        public void SaveToRepository(AssemblyMetadata assemblyMetadata, string file)
        {
            repository.SaveToRepository(assemblyMetadata.ToBaseDTO(), file);
        }
    }
}

using Logic.ReflectionMetadata;
using MEF;
using SerializationModel.DTO;
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


        public Assembly_DTO LoadFromRepository(string file)
        {
            return repository.LoadFromRepository(file);
        }

        public void SaveToRepository(Assembly_DTO assemblyMetsdata, string file)
        {
            repository.SaveToRepository(assemblyMetsdata, file);
        }
    }
}

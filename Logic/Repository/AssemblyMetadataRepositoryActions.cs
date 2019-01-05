using Logic.ReflectionMetadata;
using MEF;
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
            return repository.LoadFromRepository(file);
        }

        public void SaveToRepository(AssemblyMetadata assemblyMetsdata, string file)
        {
            repository.SaveToRepository(assemblyMetsdata, file);
        }
    }
}

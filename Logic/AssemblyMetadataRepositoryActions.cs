using Logic.ReflectionMetadata;
using MEF;
using Serialization;
using System.ComponentModel.Composition;

namespace Logic
{
    public class AssemblyMetadataRepositoryActions
    {
        [Import]
        private  IRepositoryActions<AssemblyMetadata> repository;


        public  AssemblyMetadataRepositoryActions()
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

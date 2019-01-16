using Logic.ReflectionMetadata;
using MEF;
using Logic.Mappers;
using System.ComponentModel.Composition;

namespace Repository
{
    public class AssemblyMetadataRepositoryActions
    {
        [ImportMany]
        private Importer<IRepositoryActions> repository;


        public AssemblyMetadataRepositoryActions()
        {
            new Bootstrapper().ComposeApplication(this);
        }


        public AssemblyMetadata LoadFromRepository(string file)
        {
            return repository.GetImport().LoadFromRepository(file).MapToObject();
        }

        public void SaveToRepository(AssemblyMetadata assemblyMetadata, string file)
        {
            repository.GetImport().SaveToRepository(assemblyMetadata.ToBaseDTO(), file);
        }
    }
}

using Database.Mapper;
using Model.DTO;
using Repository;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;

namespace Database
{
    [Export(typeof(IRepositoryActions))]
    public class DatabaseSerializer : IRepositoryActions
    {
        public AssemblyBaseDTO LoadFromRepository(string fileName)
        {
            AssemblyBaseDTO assembly;
            using(MainContext mainContext = new MainContext(fileName))
            {
                mainContext.assemblies.Load();
                assembly = mainContext.assemblies.FirstOrDefault().ToBaseDTO();
            }
            return assembly;
        }

        public void SaveToRepository(AssemblyBaseDTO data, string fileName)
        {
            using (MainContext db = new MainContext(fileName))
            {
                db.assemblies.Add(data.MapToDatabaseModel());
                db.SaveChanges();
            }
        }
    }
}


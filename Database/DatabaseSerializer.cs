using Database.Mapper;
using Model.DTO;
using Repository;
using System.ComponentModel.Composition;

namespace Database
{
    [Export(typeof(IRepositoryActions))]
    public class DatabaseSerializer : IRepositoryActions
    {
        public AssemblyBaseDTO LoadFromRepository(string fileName)
        {
            return new DBService(new MainContext()).GetAllAssemblies()[0].ToBaseDTO();
        }

        public void SaveToRepository(AssemblyBaseDTO data, string fileName)
        {
            using (MainContext db = new MainContext())
            {
                db.assemblies.Add(data.MapToDatabaseModel());
                db.SaveChanges();
            }
        }
    }
}


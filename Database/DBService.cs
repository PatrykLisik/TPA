using Model.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class DBService
    {
        private MainContext _context;

        public DBService(MainContext context)
        {
            _context = context;
        }

        public AssemblyDataBaseDTO AddAssemblies(string name, string url)
        {
            var assembly = _context.assemblies.Add(new AssemblyDataBaseDTO { Name = name });
            _context.SaveChanges();

            return assembly;
        }

        public List<AssemblyDataBaseDTO> GetAllAssemblies()
        {
            var query = from b in _context.assemblies
                        orderby b.Name
                        select b;

            return query.ToList();
        }
    }
}

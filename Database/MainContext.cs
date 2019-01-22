using Model.DTO;
using System.Data.Entity;

namespace Database
{
    public class MainContext : DbContext
    {
        public MainContext() : base("Data Source =.; Initial Catalog = tpa; Integrated Security = True;")
        {

        }
        public virtual DbSet<AssemblyDataBaseDTO> assemblies { get; set; }
    }
}

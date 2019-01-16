using Model.DTO;
using System.Data.Entity;

namespace Database
{
    public class MainContext : DbContext
    {
        public DbSet<AssemblyDataBaseDTO> assemblies { get; set; }
    }
}

using Model.DTO;
using System.Data.Entity;

namespace Database
{
    public class MainContext : DbContext
    {
        public MainContext(string file)
            : base(string.Format(@"Data Source = (localdb)\MSSQLLocalDB; AttachDbFilename={0};Integrated Security = True", file))
        { }
        public virtual DbSet<AssemblyDataBaseDTO> assemblies { get; set; }
    }
}

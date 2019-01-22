using Model.DTO;
using System.Data.Entity;

namespace Database
{
    public class MainContext : DbContext
    {
        public MainContext() : base(@"Data Source = (localdb)\MSSQLLocalDB; AttachDbFilename=C:\zdaneTPA.mdf;Integrated Security = True")
        { }
        public virtual DbSet<AssemblyDataBaseDTO> assemblies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Logic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Logic.ReflectionMetadata;

namespace Logic
{
    public class ReflectionDbContext : DbContext
    {
        public DbSet<AssemblyMetadata> all { get; set; }
    }
}

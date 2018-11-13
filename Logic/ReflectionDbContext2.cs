namespace Logic
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Logic.ReflectionMetadata;

    public partial class ReflectionDbContext2 : DbContext
    {
        public DbSet<AssemblyMetadata> all { get; set; }

        public ReflectionDbContext2()
            : base("name=ReflectionDbContext2")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

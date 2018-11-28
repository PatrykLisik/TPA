using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Logic.ReflectionMetadata;

namespace Logic
{
    class ReflectionContext: DbContext
    {
        public DbSet<AssemblyMetadata> assemblyMetadatas { get; set; }
        public DbSet<MethodMetadata> methodMetadatas { get; set; }
        public DbSet<NamespaceMetadata> namespaceMetadatas { get; set; }
        public DbSet<ParameterMetadata> parameterMetadatas { get; set; }
        public DbSet<PropertyMetadata> propertyMetadatas { get; set; }
        public DbSet<TypeMetadata> typeMetadatas { get; set; }
    }
}

using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using Logic.ReflectionMetadata;
using Logic.Mappers;
using Model.DTO;
using Database.Mapper;
namespace RunDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Program);
            Assembly assemFromType = t.Assembly;
            Console.WriteLine("Assembly that contains Example:");
            Console.WriteLine("   {0}\n", assemFromType.FullName);

            // Get the currently executing assembly.
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            AssemblyMetadata assemblyMeta = new AssemblyMetadata(currentAssem);

            using (var db = new MainContext())
            {
                var blog = assemblyMeta.ToBaseDTO().MapToDatabaseModel(); //ZLE
                db.assemblies.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.assemblies
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

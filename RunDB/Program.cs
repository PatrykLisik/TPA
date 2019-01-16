using Database;
using System;
using System.Linq;
using System.Reflection;
using Logic.ReflectionMetadata;
using Logic.Mappers;
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
            //Assembly currentAssem = Assembly.LoadFrom(@"C:\Users\Bartosz\Dysk Google\Studia\Technologie Programowania Adaptacyjnego\TPA_repo\UnitTest\ExampleDLL.dll");
            Assembly currentAssem = Assembly.LoadFrom(@"..\..\..\..\TPA_repo\UnitTest\ExampleDLL.dll");
            AssemblyMetadata assemblyMeta = new AssemblyMetadata(currentAssem);

            using (MainContext db = new MainContext())
            {
                Model.DTO.AssemblyDataBaseDTO blog = assemblyMeta.ToBaseDTO().MapToDatabaseModel(); //ZLE
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

using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Reader
    {
        int property = 10;

        public int Property { get => property; set => property = value; }

        public class nestedType
        {
            public int a;
        }
        public static void read()
        {
            Assembly assembly = Assembly.LoadFile(@"D:\Technologie progrmaowania\TP\Lecture\P01.Introduction\Introduction\bin\Debug\TP.Introduction.dll");
            Console.WriteLine(assembly.FullName);

            Type[] typ = assembly.GetTypes();
            foreach (Type t in typ)
            {
                Console.WriteLine("Type: " + t.Name + " Base type: " + t.BaseType);
                var props = t.GetProperties();
                foreach (var p in props)
                {
                    Console.WriteLine("\tProperty: " + p.Name + ", Property type: " + p.PropertyType);
                }

                var fields = t.GetFields();
                foreach (var f in fields)
                {
                    Console.WriteLine("\tFields: " + f.Name + ", Field type: " + f.FieldType);
                }

                MethodInfo[] methods = t.GetMethods();
                foreach (var m in methods)
                {
                    Console.WriteLine("\tMethods: " + m.Name + ", Return type: " + m.ReturnType);
                }

                Type[] generic_args = t.GetGenericArguments();
                foreach(Type g in generic_args) { Console.WriteLine("\tGeneric: " + g.Name); }
            }
        }
    }
}

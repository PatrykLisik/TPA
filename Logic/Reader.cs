using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tracer;

namespace Logic
{
    public class Reader 
    {
        //vars
        /*     to do:   
        private string m_typeName;
        private string m_NamespaceName;
        private TypeMetadata m_BaseType;
        private Tuple<AccessLevel, SealedEnum, AbstractENum> m_Modifiers;
        private TypeKind m_TypeKind;
        private TypeMetadata m_DeclaringType;
        
        private IEnumerable<PropertyInfo> m_Properties;
        private IEnumerable<MethodInfo> m_Methods;
        private IEnumerable<ConstructorInfo> m_Constructors;
        private IEnumerable<Type> m_GenericArguments;
        private IEnumerable<Attribute> m_Attributes;
        private IEnumerable<FieldInfo> m_Fields;
        private IEnumerable<Type> m_ImplementedInterfaces;
        private IEnumerable<Type> m_NestedTypes;*/

        private static TracerFile tracer = new TracerFile();
        private static AssemblyMetadata assemblyMetadata;
        private static Dictionary<string, NamespaceMetadata> namespaces = new Dictionary<string, NamespaceMetadata>();
        private static string selectedNamespace;
        private static Dictionary<string, TypeMetadata> expandableTypes = new Dictionary<string, TypeMetadata>();

        public void Read()
        {
            tracer.Tracer(TraceEventType.Information, "Program has started");
            string path = @"C:\Users\Bartosz\Dysk Google\Studia\Technologie Programowania Adaptacyjnego\TPA\GUI\bin\Debug\Caliburn.Micro.dll";
            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine(assembly.FullName);

            assemblyMetadata = new AssemblyMetadata(assembly);

            // add namespaces to Dictionary
            int i = 0;
            Console.WriteLine("Choose namespace:");
            foreach (var @namespace in assemblyMetadata.m_Namespaces)
            {
                namespaces.Add(@namespace.m_NamespaceName, @namespace);
                Console.WriteLine(i + ". " + @namespace.m_NamespaceName);
            }

            string userInput = Console.ReadLine();

            if (userInput == null)
            {
                Console.WriteLine("No input from user!");
                tracer.Tracer(TraceEventType.Warning, "No input from user!");
            }
            else
            {
                selectedNamespace = userInput;
                tracer.Tracer(TraceEventType.Information, "selected namespace" + selectedNamespace);
            }

            // list types from selected dll file from namespace Reflection
            tracer.Tracer(TraceEventType.Start, "default types display");
            ListDefaultTypes(userInput);
            tracer.Tracer(TraceEventType.Stop, "default types displayed");
        }
        private static void ListDefaultTypes(string namespaceName)
        {
            Console.Clear();
            expandableTypes.Clear();

            Console.WriteLine("Stored types: " + TypeMetadata.storedTypes.Count);
            foreach (var storedType in namespaces[namespaceName].m_Types)
            {
                Console.WriteLine(storedType);
                expandableTypes.Add(storedType.TypeName, storedType);
            }
        }
    }
}

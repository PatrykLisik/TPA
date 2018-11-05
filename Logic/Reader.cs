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
        private static TracerFile tracer = new TracerFile();
        private static AssemblyMetadata assemblyMetadata;
        private static string selectedNamespace;

        private static Dictionary<string, NamespaceMetadata> namespaces = new Dictionary<string, NamespaceMetadata>();        
        private static Dictionary<string, TypeMetadata> expandableTypes = new Dictionary<string, TypeMetadata>();
        private static Stack<TypeMetadata> typeHistory = new Stack<TypeMetadata>();
        public void Read()
        {
            tracer.Tracer(TraceEventType.Information, "Program has started");
            string path = @"C:\Users\Bartosz\Dysk Google\Studia\Technologie Programowania Adaptacyjnego\TPA\GUI\bin\Debug\Caliburn.Micro.dll";

            assemblyMetadata = new AssemblyMetadata(Assembly.LoadFile(path));

            // add namespaces to Dictionary
            Console.WriteLine("Choose namespace");
            foreach (var @namespace in assemblyMetadata.m_Namespaces)
            {
                namespaces.Add(@namespace.m_NamespaceName, @namespace);
                Console.WriteLine(@namespace.m_NamespaceName);
            }

            // get namespace name from user

            Console.Write(">>> ");

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

            do
            {
                // print command prompt
                Console.Write(">>> ");

                userInput = Console.ReadLine();

                if (userInput == null)
                {
                    Console.WriteLine("No input from user!");
                    tracer.Tracer(TraceEventType.Warning, "No input from user!");
                    continue;
                }

                string command = userInput.Split(' ')[0];

                switch (command)
                {
                    case "list":
                        tracer.Tracer(TraceEventType.Start, "listing start");
                        if (userInput.Split(' ').Length == 2)
                        {
                            string selectedType = userInput.Split(' ')[1];

                            if (expandableTypes.ContainsKey(selectedType))
                            {
                                ExpandType(selectedType);
                            }
                            else
                            {
                                Console.WriteLine("Invalid type name");
                            }

                            tracer.Tracer(TraceEventType.Start, "expanded type " + selectedType);
                        }
                        else
                        {
                            Console.WriteLine("Write the type that you want to expand!");
                            tracer.Tracer(TraceEventType.Warning, "no type specified");
                        }
                        tracer.Tracer(TraceEventType.Stop, "listing stop");
                        break;
                    case "back":
                        tracer.Tracer(TraceEventType.Information, "go back");
                        GoBack();
                        break;
                    case "exit":
                        tracer.Tracer(TraceEventType.Information, "Program stopped");
                        return;
                    case "help":
                        tracer.Tracer(TraceEventType.Information, "help");
                        Console.WriteLine("Available commands:\n" +
                                          "\tlist [type to expand]\n" +
                                          "\tback\n" +
                                          "\texit");
                        break;
                    default:
                        tracer.Tracer(TraceEventType.Warning, "invalid command");
                        Console.WriteLine("Invalid command");
                        break;
                }
            } while (true);
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

        private static void GoBack()
        {
            if (typeHistory.Count > 0)
            {
                // check if only 1 value is stored in stack
                if (typeHistory.Count == 1)
                {
                    typeHistory.Clear();
                    ListDefaultTypes(selectedNamespace);
                }
                else
                {
                    typeHistory.Pop();
                    ExpandType(typeHistory.Pop().TypeName);
                }
            }
        }

        private static void ExpandType(string typeName)
        {
            TypeMetadata type = TypeMetadata.storedTypes[typeName];
            typeHistory.Push(type);

            Console.Clear();
            expandableTypes.Clear();

            // fields
            foreach (var field in type.m_Fields)
            {
                string fieldTypeName = field.m_TypeMetadata.TypeName;
                if (!expandableTypes.ContainsKey(fieldTypeName))
                {
                    expandableTypes.Add(fieldTypeName, field.m_TypeMetadata);
                }
            }

            // properties
            foreach (var property in type.m_Properties)
            {
                string propertyTypeName = property.m_TypeMetadata.TypeName;
                if (!expandableTypes.ContainsKey(propertyTypeName))
                {
                    expandableTypes.Add(propertyTypeName, property.m_TypeMetadata);
                }
            }

            // methods
            foreach (var method in type.m_Methods)
            {
                // return type
                string returnTypeName = method.m_ReturnType.TypeName;
                if (!expandableTypes.ContainsKey(returnTypeName))
                {
                    expandableTypes.Add(returnTypeName, method.m_ReturnType);
                }

                // parameters
                foreach (var parameter in method.m_Parameters)
                {
                    string parameterTypeName = parameter.m_TypeMetadata.TypeName;
                    if (!expandableTypes.ContainsKey(parameterTypeName))
                    {
                        expandableTypes.Add(parameterTypeName, parameter.m_TypeMetadata);
                    }
                }
            }

            Console.WriteLine("Stored types: " + TypeMetadata.storedTypes.Count);
            Console.WriteLine(type);
        }
    }
}

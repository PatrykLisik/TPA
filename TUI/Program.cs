﻿using Logic;
using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Tracer;

namespace TUI
{
    class Program
    {
        private static TracerFile tracer = new TracerFile();
        private static Stack<TypeMetadata> typeHistory = new Stack<TypeMetadata>();
        private static AssemblyMetadata assemblyMetadata;
        private static Dictionary<string, TypeMetadata> expandableTypes = new Dictionary<string, TypeMetadata>();
        private static Dictionary<string, NamespaceMetadata> namespaces = new Dictionary<string, NamespaceMetadata>();
        private static string selectedNamespace;

        static void Main(string[] args)
        {
            tracer.Tracer(TraceEventType.Information, "Program started");
            string pathToDll = @"..\..\..\Logic\bin\Debug\Logic.dll";
            Assembly dotNetAssembly = Assembly.LoadFrom(pathToDll);

            assemblyMetadata = new AssemblyMetadata(dotNetAssembly);

            // add namespaces to Dictionary
            Console.WriteLine("Choose namespace");
            foreach (NamespaceMetadata @namespace in assemblyMetadata.m_Namespaces)
            {
                namespaces.Add(@namespace.m_NamespaceName, @namespace);
                Console.WriteLine(@namespace.m_NamespaceName);
            }

            // get namespace name from user
            string userInput;

            bool trigger = true;
            do
            {
                Console.Write(">>> ");
                userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("No input from user!");
                    tracer.Tracer(TraceEventType.Warning, "No input from user!");
                }

                if (namespaces.ContainsKey(userInput))
                {
                    trigger = false;
                    selectedNamespace = userInput;
                    tracer.Tracer(TraceEventType.Information, "selected namespace" + selectedNamespace);
                    
                    // list types from selected dll file from namespace Reflection
                    tracer.Tracer(TraceEventType.Start, "default types display");
                    ListDefaultTypes(userInput);
                    tracer.Tracer(TraceEventType.Stop, "default types displayed");

                }
            } while (trigger);

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

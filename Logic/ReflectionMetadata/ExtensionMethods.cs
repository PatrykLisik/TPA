
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata
{
    internal static class ExtensionMethods
    {

        internal static bool GetVisible(this Type type)
        {
            return type.IsPublic || type.IsNestedPublic || type.IsNestedFamily || type.IsNestedFamANDAssem;
        }
        internal static bool GetVisible(this MethodBase method)
        {
            return method != null && (method.IsPublic || method.IsFamily || method.IsFamilyAndAssembly);
        }
        internal static string GetNamespace(this Type type)
        {
            string ns = type.Namespace;
            return ns != null ? ns : string.Empty;
        }

        internal static List<T> AddRangeOrDefault<T>(this List<T> list, IEnumerable<T> range)
        {
            list.AddRange(range ?? Enumerable.Empty<T>());
            return list;
        }
    }
}

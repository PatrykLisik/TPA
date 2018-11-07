
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Logic.ReflectionMetadata
{
    public class MethodMetadata : IInternalGeter
    {

        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase _currentMethod in methods
                   where _currentMethod.GetVisible()
                   select new MethodMetadata(_currentMethod);
        }

        #region private
        //vars
        public string m_Name { get; private set; }
        public IEnumerable<TypeMetadata> m_GenericArguments { get; private set; }
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> m_Modifiers { get; private set; }
        public TypeMetadata m_ReturnType { get; private set; }
        public bool m_Extension { get; private set; }
        public IEnumerable<ParameterMetadata> m_Parameters { get; private set; }
        //constructor
        private MethodMetadata(MethodBase method)
        {
            m_Name = method.Name;
            m_GenericArguments = !method.IsGenericMethodDefinition ? null : TypeMetadata.EmitGenericArguments(method.GetGenericArguments());
            m_ReturnType = EmitReturnType(method) ?? new TypeMetadata(typeof(void));
            m_Parameters = EmitParameters(method.GetParameters());
            m_Modifiers = EmitModifiers(method);
            m_Extension = EmitExtension(method);
        }
        //methods
        private static IEnumerable<ParameterMetadata> EmitParameters(IEnumerable<ParameterInfo> parms)
        {
            return from parm in parms
                   select new ParameterMetadata(parm.Name, TypeMetadata.EmitReference(parm.ParameterType));
        }
        private static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            TypeMetadata.AddToStoredTypes(methodInfo.ReturnType);
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        private static bool EmitExtension(MethodBase method)
        {
            return method.IsDefined(typeof(ExtensionAttribute), true);
        }
        private static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> EmitModifiers(MethodBase method)
        {
            AccessLevel _access = AccessLevel.IsPrivate;
            if (method.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (method.IsFamily)
                _access = AccessLevel.IsProtected;
            else if (method.IsFamilyAndAssembly)
                _access = AccessLevel.IsProtectedInternal;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            if (method.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            StaticEnum _static = StaticEnum.NotStatic;
            if (method.IsStatic)
                _static = StaticEnum.Static;
            VirtualEnum _virtual = VirtualEnum.NotVirtual;
            if (method.IsVirtual)
                _virtual = VirtualEnum.Virtual;
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(_access, _abstract, _static, _virtual);
        }
        #endregion

        public IEnumerable<IInternalGeter> GetInternals()
        {
            return new List<IInternalGeter>();
        }
        public override string ToString()
        {
            return m_Modifiers.Item1.Stringify() +
                   m_Modifiers.Item2.Stringify() +
                   m_Modifiers.Item3.Stringify() +
                   m_Modifiers.Item4.Stringify() +
                   m_ReturnType.TypeName + " " +
                   m_Name +
                   genericArgsString() +
                   "(" + string.Join(" ,", m_Parameters) + ")";
        }

        private string genericArgsString()
        {
            string genericArgs;
            if (m_GenericArguments is null)
            {
                genericArgs = "";
            }
            else
            {
                IEnumerable<String> args = from TypeMetadata _tm in m_GenericArguments
                                           select _tm.TypeName;
                genericArgs = "<" +
                    string.Join(" ,", args) +
                    ">";
            }

            return genericArgs;
        }
    }
}
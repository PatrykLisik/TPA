﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.ReflectionMetadata
{
    public class TypeMetadata : IInternalGeter
    {
        public static Dictionary<string, TypeMetadata> storedTypes = new Dictionary<string, TypeMetadata>();

        #region constructors
        public TypeMetadata(Type type)
        {
            if (!storedTypes.ContainsKey(type.Name))
            {
                storedTypes.Add(type.Name, this);
            }

            m_typeName = type.Name;
            m_DeclaringType = EmitDeclaringType(type.DeclaringType);
            m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
            m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            m_GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            m_Modifiers = EmitModifiers(type);
            m_BaseType = EmitExtends(type.BaseType);
            m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            m_TypeKind = GetTypeKind(type);
            m_Attributes = type.GetCustomAttributes(false).Cast<Attribute>();
        }
        #endregion

        #region API
        public enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        public static TypeMetadata EmitReference(Type type)
        {
            if (!type.IsGenericType)
            {
                if (storedTypes.ContainsKey(type.Name))
                {
                    return storedTypes[type.Name];
                }
                return new TypeMetadata(type.Name, type.GetNamespace());
            }
            return new TypeMetadata(type.Name, type.GetNamespace(),
                EmitGenericArguments(type.GetGenericArguments()));
        }
        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            return from Type _argument in arguments select EmitReference(_argument);
        }


        #endregion

        #region private
        //vars
        public string m_typeName;
        public string m_NamespaceName;
        public TypeMetadata m_BaseType;
        public IEnumerable<TypeMetadata> m_GenericArguments;
        public Tuple<AccessLevel, SealedEnum, AbstractENum> m_Modifiers;
        public TypeKind m_TypeKind;
        public IEnumerable<Attribute> m_Attributes;
        public IEnumerable<TypeMetadata> m_ImplementedInterfaces;
        public IEnumerable<TypeMetadata> m_NestedTypes;
        public IEnumerable<PropertyMetadata> m_Properties;
        public TypeMetadata m_DeclaringType;
        public IEnumerable<MethodMetadata> m_Methods;
        public IEnumerable<MethodMetadata> m_Constructors;
        public IEnumerable<ParameterMetadata> m_Fields;

        public string TypeName => m_typeName;

        //constructors
        private TypeMetadata(string typeName, string namespaceName)
        {
            m_typeName = typeName;
            m_NamespaceName = namespaceName;
        }
        private TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            m_GenericArguments = genericArguments;
        }
        //methods
        private TypeMetadata EmitDeclaringType(Type declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {
            return from _type in nestedTypes
                   where _type.GetVisible()
                   select new TypeMetadata(_type);
        }
        private IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static TypeKind GetTypeKind(Type type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
        {
            return type.IsEnum ? TypeKind.EnumType :
                   type.IsValueType ? TypeKind.StructType :
                   type.IsInterface ? TypeKind.InterfaceType :
                   TypeKind.ClassType;
        }
        static Tuple<AccessLevel, SealedEnum, AbstractENum> EmitModifiers(Type type)
        {
            //set defaults 
            AccessLevel _access = AccessLevel.IsPrivate;
            AbstractENum _abstract = AbstractENum.NotAbstract;
            SealedEnum _sealed = SealedEnum.NotSealed;
            // check if not default 
            if (type.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedFamily)
                _access = AccessLevel.IsProtected;
            else if (type.IsNestedFamANDAssem)
                _access = AccessLevel.IsProtectedInternal;
            if (type.IsSealed)
                _sealed = SealedEnum.Sealed;
            if (type.IsAbstract)
                _abstract = AbstractENum.Abstract;
            return new Tuple<AccessLevel, SealedEnum, AbstractENum>(_access, _sealed, _abstract);
        }
        private static TypeMetadata EmitExtends(Type baseType)
        {
            if (baseType == null || baseType == typeof(object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
                return null;
            return EmitReference(baseType);
        }
        #endregion


        public ICollection<IInternalGeter> GetInternals()
        {
            List<IInternalGeter> ret = new List<IInternalGeter>();
            ret.AddRange(m_Methods ?? Enumerable.Empty<IInternalGeter>());
            ret.AddRange(m_Constructors ?? Enumerable.Empty<IInternalGeter>());
            ret.AddRange(m_Properties ?? Enumerable.Empty<IInternalGeter>());
            ret.AddRange(m_NestedTypes ?? Enumerable.Empty<IInternalGeter>());
            //ret.AddRange(m_ImplementedInterfaces ?? Enumerable.Empty<IInternalGeter>());
            ret.Distinct();
            return ret;
        }

        #region ToString
        private string TypeKindToString(TypeKind typeKind)
        {
            return Enum.GetName(typeof(TypeKind), typeKind).Replace("Type", "");
        }
        public override string ToString()
        {
            return m_Modifiers.Item1.Stringify() +
                   m_Modifiers.Item2.Stringify() +
                   m_Modifiers.Item3.Stringify()+ " " +
                   m_TypeKind.ToString().Replace("Type"," ") + " " +
                   TypeName;
        }
        #endregion
    }
}
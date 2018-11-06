
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            m_Fields = EmitFields(type);
        }


        #endregion

        #region API
        public enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        internal static TypeMetadata EmitReference(Type type)
        {
            if (!type.IsGenericType)
                return new TypeMetadata(type.Name, type.GetNamespace());
            else
                return new TypeMetadata(type.Name, type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
        }
        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            return from Type _argument in arguments select EmitReference(_argument);
        }
        #endregion

        #region private
        //vars
        public string m_typeName { get; private set; }
        public string m_NamespaceName { get; private set; }
        public TypeMetadata m_BaseType { get; private set; }
        public IEnumerable<TypeMetadata> m_GenericArguments { get; private set; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers { get; private set; }
        public TypeKind m_TypeKind { get; private set; }
        public IEnumerable<Attribute> m_Attributes { get; private set; }
        public IEnumerable<TypeMetadata> m_ImplementedInterfaces { get; private set; }
        public IEnumerable<TypeMetadata> m_NestedTypes { get; private set; }
        public IEnumerable<PropertyMetadata> m_Properties { get; private set; }
        public TypeMetadata m_DeclaringType { get; private set; }
        public IEnumerable<MethodMetadata> m_Methods { get; private set; }
        public IEnumerable<MethodMetadata> m_Constructors { get; private set; }
        public IEnumerable<ParameterMetadata> m_Fields { get; private set; }

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
        private IEnumerable<ParameterMetadata> EmitFields(Type type)
        {
            return from _fieldInfo in type
                        .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        //.Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
                   select new ParameterMetadata(_fieldInfo.Name, new TypeMetadata(_fieldInfo.FieldType));
        }
        private static TypeKind GetTypeKind(Type type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
        {
            return type.IsEnum ? TypeKind.EnumType :
                   type.IsValueType ? TypeKind.StructType :
                   type.IsInterface ? TypeKind.InterfaceType :
                   TypeKind.ClassType;
        }
        static Tuple<AccessLevel, SealedEnum, AbstractEnum> EmitModifiers(Type type)
        {
            //set defaults 
            AccessLevel _access = AccessLevel.IsPrivate;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
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
                _abstract = AbstractEnum.Abstract;
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(_access, _sealed, _abstract);
        }
        private static TypeMetadata EmitExtends(Type baseType)
        {
            if (baseType == null || baseType == typeof(object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
                return null;
            return EmitReference(baseType);
        }
        #endregion


        public IEnumerable<IInternalGeter> GetInternals()
        {
            List<IInternalGeter> ret = new List<IInternalGeter>();
            ret = ret.AddRangeOrDefault(m_GenericArguments);
            ret = ret.AddRangeOrDefault(m_GenericArguments);
            ret = ret.AddRangeOrDefault(m_NestedTypes);
            ret = ret.AddRangeOrDefault(m_Properties);
            ret = ret.AddRangeOrDefault(m_Methods);
            ret = ret.AddRangeOrDefault(m_Constructors);
            ret = ret.AddRangeOrDefault(m_Fields);
            //ret.Distinct();
            return ret;

        }

        #region ToString

        private string TypeKindToString(TypeKind typeKind)
        {
            return typeKind.ToString().Replace("Type", "") + " ";
        }
        public override string ToString()
        {

            return modifiersToString() +
                   TypeKindToString(m_TypeKind) +
                   TypeName + genericParamsToString();
        }
        private string modifiersToString()
        {
            if (m_Modifiers is null)
                return "";
            return genericParamsToString();
        }

        private string genericParamsToString()
        {
            if (m_GenericArguments is null)
                return "";
            return "<" + string.Join(",", m_GenericArguments) + ">";
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Logic.ReflectionMetadata
{
    [DataContract(IsReference = true)]
    public class TypeMetadata
    {

        #region constructors
        public TypeMetadata(Type type)
        {
            m_typeName = type.Name;
            m_DeclaringType = EmitDeclaringType(type.DeclaringType);
            m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
            m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            Modifiers = EmitModifiers(type);
            BaseType = EmitExtends(type.BaseType);
            m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            TypeKind1 = GetTypeKind(type);
            m_Attributes = type.GetCustomAttributes(false).Cast<Attribute>();
            m_Fields = EmitFields(type);
        }
        private TypeMetadata(string typeName, string namespaceName)
        {
            m_typeName = typeName;
            NamespaceName = namespaceName;
        }
        private TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            GenericArguments = genericArguments;
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
            {
                return new TypeMetadata(type.Name, type.GetNamespace());
            }
            return new TypeMetadata(type.Name, type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
        }
        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {

            return from Type _argument in arguments select EmitReference(_argument);
        }
        #endregion

        //vars
        [DataMember]
        private string m_typeName;
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private TypeMetadata m_BaseType;
        [DataMember]
        private IEnumerable<TypeMetadata> m_GenericArguments;
        [DataMember]
        private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        [DataMember]
        private TypeKind m_TypeKind;
        //[DataMember]
        private IEnumerable<Attribute> m_Attributes;
        [DataMember]
        private IEnumerable<TypeMetadata> m_ImplementedInterfaces;
        [DataMember]
        private IEnumerable<TypeMetadata> m_NestedTypes;
        [DataMember]
        private IEnumerable<PropertyMetadata> m_Properties;
        [DataMember]
        private TypeMetadata m_DeclaringType;
        [DataMember]
        private IEnumerable<MethodMetadata> m_Methods;
        [DataMember]
        private IEnumerable<MethodMetadata> m_Constructors;
        [DataMember]
        private IEnumerable<ParameterMetadata> m_Fields;

        public string TypeName => m_typeName;

        public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }

        public IEnumerable<MethodMetadata> Methods => m_Methods;

        public IEnumerable<TypeMetadata> NestedTypes => m_NestedTypes;

        public IEnumerable<TypeMetadata> ImplementedInterfaces => m_ImplementedInterfaces;

        public IEnumerable<PropertyMetadata> Properties => m_Properties;

        public IEnumerable<MethodMetadata> Constructors => m_Constructors;

        public IEnumerable<ParameterMetadata> Fields => m_Fields;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public TypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }

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
            IEnumerable<FieldInfo> fieldInfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            List<ParameterMetadata> parameters = new List<ParameterMetadata>();
            foreach (FieldInfo field in fieldInfo)
            {
                parameters.Add(new ParameterMetadata(field.Name, EmitReference(field.FieldType)));
            }

            return parameters;
            //.Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
            //select new ParameterMetadata(_fieldInfo.Name, new TypeMetadata(_fieldInfo.FieldType));
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

    }
}
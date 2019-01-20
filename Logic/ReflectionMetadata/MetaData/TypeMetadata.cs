
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata
{
    public class TypeMetadata
    {

        #region constructors
        public TypeMetadata(Type type)
        {
            TypeName = type.Name;
            DeclaringType = EmitDeclaringType(type.DeclaringType);
            Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            Methods = MethodMetadata.EmitMethods(type.GetMethods());
            NestedTypes = EmitNestedTypes(type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic));
            ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            Modifiers = EmitModifiers(type);
            BaseType = EmitExtends(type.BaseType);
            Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            TypeKind1 = GetTypeKind(type);
            //Attributes = type.GetCustomAttributes(false).Cast<Attribute>();
            Fields = EmitFields(type);
        }
        private TypeMetadata(string typeName, string namespaceName)
        {
            TypeName = typeName;
            NamespaceName = namespaceName;
        }
        private TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            GenericArguments = genericArguments;
        }

        public TypeMetadata()
        {
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
        private string m_typeName;
        private string m_NamespaceName;
        private TypeMetadata m_BaseType;
        private IEnumerable<TypeMetadata> m_GenericArguments;
        private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        private TypeKind m_TypeKind;
        private IEnumerable<Attribute> m_Attributes;
        private IEnumerable<TypeMetadata> m_ImplementedInterfaces;
        private IEnumerable<TypeMetadata> m_NestedTypes;
        private IEnumerable<PropertyMetadata> m_Properties;
        private TypeMetadata m_DeclaringType;
        private IEnumerable<MethodMetadata> m_Methods;
        private IEnumerable<MethodMetadata> m_Constructors;
        private IEnumerable<ParameterMetadata> m_Fields;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public TypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public IEnumerable<Attribute> Attributes { get => m_Attributes; set => m_Attributes = value; }
        public IEnumerable<TypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<TypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<PropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public TypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<MethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<MethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
        public IEnumerable<ParameterMetadata> Fields { get => m_Fields; set => m_Fields = value; }



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
                   //where _type.GetVisible()
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
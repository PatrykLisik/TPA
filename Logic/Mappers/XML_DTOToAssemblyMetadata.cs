using Logic.ReflectionMetadata;
using SerializationModel;
using SerializationModel.DTO;
using System;
using System.Linq;
using static Logic.ReflectionMetadata.TypeMetadata;
using static SerializationModel.DTO.Type_DTO;

namespace Logic.Mappers
{
    public static class XML_DTOToAssemblyMetadata
    {
        public static AssemblyMetadata MapToObject(this Assembly_DTO metadata)
        {
            return new AssemblyMetadata
            {
                Name = metadata.Name,
                Namespaces = metadata.Namespaces.Select(i => i.MapToObject())
            };
        }

        public static MethodMetadata  MapToObject(this Method_DTO metadata)
        {
            return new MethodMetadata
            {
                Name = metadata.Name,
                GenericArguments = metadata.GenericArguments.Select(i => i.MapToObject()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                ReturnType = metadata.ReturnType.MapToObject(),
                Extension = metadata.Extension,
                Parameters = metadata.Parameters.Select(i => i.MapToObject())
            };
        }

        public static  NamespaceMetadata MapToObject(this Namespace_DTO metadata)
        {
            return new NamespaceMetadata
            {
                NamespaceName = metadata.NamespaceName,
                Types = metadata.Types.Select(i => i.MapToObject())
            };
        }

        public static ParameterMetadata  MapToObject(this Parameter_DTO metadata)
        {
            return new ParameterMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static PropertyMetadata  MapToObject(this Property_DTO metadata)
        {
            return new PropertyMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static TypeMetadata  MapToObject(this Type_DTO metadata)
        {
            return new TypeMetadata
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.MapToObject(),
                GenericArguments = metadata.GenericArguments.Select(i => i.MapToObject()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                TypeKind1 = metadata.TypeKind1.ToXMLDTO(),
                ImplementedInterfaces = metadata.ImplementedInterfaces.Select(i => i.MapToObject()),
                NestedTypes = metadata.NestedTypes.Select(i => i.MapToObject()),
                Properties = metadata.Properties.Select(i => i.MapToObject()),
                DeclaringType = metadata.DeclaringType.MapToObject(),
                Methods = metadata.Methods.Select(i => i.MapToObject()),
                Constructors = metadata.Constructors.Select(i => i.MapToObject()),
                Fields = metadata.Fields.Select(i => i.MapToObject())

            };
        }

        #region Enums
        public static AccessLevel  ToXMLDTO(this AccessLevel_DTO enumType)
        {
            switch (enumType)
            {
                case AccessLevel_DTO.IsPrivate :
                    return AccessLevel.IsPrivate;
                case AccessLevel_DTO.IsProtected:
                    return  AccessLevel.IsProtected;
                case AccessLevel_DTO.IsProtectedInternal:
                    return AccessLevel.IsProtectedInternal ;
                case AccessLevel_DTO.IsPublic:
                    return  AccessLevel.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnum  ToXMLDTO(this SealedEnum_DTO enumType)
        {
            switch (enumType)
            {
                case SealedEnum_DTO.NotSealed:
                    return SealedEnum.NotSealed;
                case SealedEnum_DTO.Sealed:
                    return SealedEnum.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnum ToXMLDTO(this  AbstractEnum_DTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnum_DTO.Abstract:
                    return AbstractEnum.Abstract;
                case AbstractEnum_DTO.NotAbstract:
                    return AbstractEnum.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnum ToXMLDTO(this StaticEnum_DTO enumType)
        {
            switch (enumType)
            {
                case StaticEnum_DTO.NotStatic:
                    return StaticEnum.NotStatic;
                case StaticEnum_DTO.Static:
                    return StaticEnum.Static;
            }
            throw new Exception();
        }

        public static VirtualEnum ToXMLDTO(this VirtualEnum_DTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnum_DTO.NotVirtual:
                    return VirtualEnum.NotVirtual;
                case VirtualEnum_DTO.Virtual:
                    return VirtualEnum.Virtual;
            }
            throw new Exception();
        }

        public static TypeKind ToXMLDTO(this TypeKind_DTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKind_DTO.ClassType:
                    return TypeKind.ClassType;
                case TypeKind_DTO.EnumType:
                    return TypeKind.EnumType;
                case TypeKind_DTO.InterfaceType:
                    return TypeKind.InterfaceType;
                case TypeKind_DTO.StructType:
                    return TypeKind.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevel, SealedEnum, AbstractEnum> ToXMLDTO(this Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO> tuple)
        {
            AccessLevel accessLevel_ = tuple.Item1.ToXMLDTO();
            SealedEnum sealedEnum_ = tuple.Item2.ToXMLDTO();
            AbstractEnum abstractEnum_ = tuple.Item3.ToXMLDTO();
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(accessLevel_, sealedEnum_, abstractEnum_);
        }

        public static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>   ToXMLDTO(this Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> tuple)
        {
            AccessLevel accessLevel_ = tuple.Item1.ToXMLDTO();
            AbstractEnum abstractEnum_ = tuple.Item2.ToXMLDTO();
            StaticEnum staticEnum_ = tuple.Item3.ToXMLDTO();
            VirtualEnum virtualEnum_ = tuple.Item4.ToXMLDTO();
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(accessLevel_, abstractEnum_, staticEnum_, virtualEnum_);
        }
        #endregion

    }
}

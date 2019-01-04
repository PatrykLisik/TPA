using Logic.ReflectionMetadata;
using SerializationModel;
using SerializationModel.DTO;
using System;
using System.Linq;
using static Logic.ReflectionMetadata.TypeMetadata;
using static SerializationModel.DTO.Type_DTO;

namespace Logic.Mappers
{
    public static class AssemblyMetadataToXML_DTOMapper
    {
        public static Assembly_DTO ToXML_DTO(this  AssemblyMetadata metadata)
        {
            return new Assembly_DTO
            {
                Name = metadata.Name,
                Namespaces = metadata.Namespaces.Select(i => i.ToXML_DTO())
            };
        }

        public static Method_DTO ToXML_DTO(this MethodMetadata metadata)
        {
            return new Method_DTO
            {
                Name = metadata.Name,
                GenericArguments = metadata.GenericArguments.Select(i => i.ToXML_DTO()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                ReturnType = metadata.ReturnType.ToXML_DTO(),
                Extension = metadata.Extension,
                Parameters = metadata.Parameters.Select(i => i.ToXML_DTO())
            };
        }

        public static Namespace_DTO ToXML_DTO(this NamespaceMetadata metadata)
        {
            return new Namespace_DTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = metadata.Types.Select(i => i.ToXML_DTO())
            };
        }

        public static Parameter_DTO ToXML_DTO(this ParameterMetadata metadata)
        {
            return new Parameter_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToXML_DTO()
            };
        }

        public static Property_DTO ToXML_DTO(this PropertyMetadata metadata)
        {
            return new Property_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToXML_DTO()
            };
        }

        public static Type_DTO ToXML_DTO(this TypeMetadata metadata)
        {
            return new Type_DTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.ToXML_DTO(),
                GenericArguments = metadata.GenericArguments.Select(i => i.ToXML_DTO()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                TypeKind1 = metadata.TypeKind1.ToXMLDTO(),
                ImplementedInterfaces = metadata.ImplementedInterfaces.Select(i => i.ToXML_DTO()),
                NestedTypes = metadata.NestedTypes.Select(i => i.ToXML_DTO()),
                Properties = metadata.Properties.Select(i => i.ToXML_DTO()),
                DeclaringType = metadata.DeclaringType.ToXML_DTO(),
                Methods = metadata.Methods.Select(i => i.ToXML_DTO()),
                Constructors = metadata.Constructors.Select(i => i.ToXML_DTO()),
                Fields = metadata.Fields.Select(i => i.ToXML_DTO())

            };
        }

        #region Enums
        public static AccessLevel_DTO ToXMLDTO(this AccessLevel enumType)
        {
            switch (enumType)
            {
                case AccessLevel.IsPrivate:
                    return AccessLevel_DTO.IsPrivate;
                case AccessLevel.IsProtected:
                    return AccessLevel_DTO.IsProtected;
                case AccessLevel.IsProtectedInternal:
                    return AccessLevel_DTO.IsProtectedInternal;
                case AccessLevel.IsPublic:
                    return AccessLevel_DTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnum_DTO ToXMLDTO(this SealedEnum enumType)
        {
            switch (enumType)
            {
                case SealedEnum.NotSealed:
                    return SealedEnum_DTO.NotSealed;
                case SealedEnum.Sealed:
                    return SealedEnum_DTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnum_DTO ToXMLDTO(this AbstractEnum enumType)
        {
            switch (enumType)
            {
                case AbstractEnum.Abstract:
                    return AbstractEnum_DTO.Abstract;
                case AbstractEnum.NotAbstract:
                    return AbstractEnum_DTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnum_DTO ToXMLDTO(this StaticEnum enumType)
        {
            switch (enumType)
            {
                case StaticEnum.NotStatic:
                    return StaticEnum_DTO.NotStatic;
                case StaticEnum.Static:
                    return StaticEnum_DTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnum_DTO ToXMLDTO(this VirtualEnum enumType)
        {
            switch (enumType)
            {
                case VirtualEnum.NotVirtual:
                    return VirtualEnum_DTO.NotVirtual;
                case VirtualEnum.Virtual:
                    return VirtualEnum_DTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKind_DTO ToXMLDTO(this TypeKind typeKind)
        {
            switch (typeKind)
            {
                case TypeKind.ClassType:
                    return TypeKind_DTO.ClassType;
                case TypeKind.EnumType:
                    return TypeKind_DTO.EnumType;
                case TypeKind.InterfaceType:
                    return TypeKind_DTO.InterfaceType;
                case TypeKind.StructType:
                    return TypeKind_DTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO> ToXMLDTO(this Tuple<AccessLevel, SealedEnum, AbstractEnum> tuple)
        {
            AccessLevel_DTO accessLevel_ = tuple.Item1.ToXMLDTO();
            SealedEnum_DTO sealedEnum_ = tuple.Item2.ToXMLDTO();
            AbstractEnum_DTO abstractEnum_ = tuple.Item3.ToXMLDTO();
            return new Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO>(accessLevel_, sealedEnum_, abstractEnum_);
        }

        public static Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> ToXMLDTO(this Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> tuple)
        {
            AccessLevel_DTO accessLevel_ = tuple.Item1.ToXMLDTO();
            AbstractEnum_DTO abstractEnum_ = tuple.Item2.ToXMLDTO();
            StaticEnum_DTO staticEnum_ = tuple.Item3.ToXMLDTO();
            VirtualEnum_DTO virtualEnum_ = tuple.Item4.ToXMLDTO();
            return new Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO>(accessLevel_, abstractEnum_, staticEnum_, virtualEnum_);
        }
        #endregion
    }
}

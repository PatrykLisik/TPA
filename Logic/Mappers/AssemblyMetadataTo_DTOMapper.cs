using Logic.ReflectionMetadata;
using SerializationModel;
using SerializationModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static Logic.ReflectionMetadata.TypeMetadata;
using static SerializationModel.DTO.Type_DTO;

namespace Logic.Mappers
{
    public static class AssemblyMetadataTo_DTOMapper
    {
        public static Assembly_DTO ToXML_DTO(this AssemblyMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Assembly_DTO
            {
                Name = metadata.Name,
                Namespaces = CollectionToXMLDTO(metadata.Namespaces, i => i.ToXML_DTO())
            };
        }

        public static Method_DTO ToXML_DTO(this MethodMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Method_DTO
            {
                Name = metadata.Name,
                GenericArguments = CollectionToXMLDTO(metadata.GenericArguments, i => i.ToXML_DTO()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                ReturnType = metadata.ReturnType.ToXML_DTO(),
                Extension = metadata.Extension,
                Parameters = CollectionToXMLDTO(metadata.Parameters, i => i.ToXML_DTO())
            };
        }

        public static Namespace_DTO ToXML_DTO(this NamespaceMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Namespace_DTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionToXMLDTO(metadata.Types, i => i.ToXML_DTO())
            };
        }

        public static Parameter_DTO ToXML_DTO(this ParameterMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Parameter_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToXML_DTO()
            };
        }

        public static Property_DTO ToXML_DTO(this PropertyMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Property_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToXML_DTO()
            };
        }

        public static Type_DTO ToXML_DTO(this TypeMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new Type_DTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.ToXML_DTO(),
                GenericArguments = CollectionToXMLDTO(metadata.GenericArguments, i => i.ToXML_DTO()),
                Modifiers = metadata.Modifiers.ToXMLDTO(),
                TypeKind1 = metadata.TypeKind1.ToXMLDTO(),
                ImplementedInterfaces = CollectionToXMLDTO(metadata.ImplementedInterfaces, i => i.ToXML_DTO()),
                NestedTypes = CollectionToXMLDTO(metadata.NestedTypes, i => i.ToXML_DTO()),
                Properties = CollectionToXMLDTO(metadata.Properties, i => i.ToXML_DTO()),
                DeclaringType = metadata.DeclaringType.ToXML_DTO(),
                Methods = CollectionToXMLDTO(metadata.Methods, i => i.ToXML_DTO()),
                Constructors = CollectionToXMLDTO(metadata.Constructors, i => i.ToXML_DTO()),
                Fields = CollectionToXMLDTO(metadata.Fields, i => i.ToXML_DTO())

            };
        }

        public static IEnumerable<DTO> CollectionToXMLDTO<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func);
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
            if (tuple == null)
                return null;
            AccessLevel_DTO accessLevel_ = tuple.Item1.ToXMLDTO();
            SealedEnum_DTO sealedEnum_ = tuple.Item2.ToXMLDTO();
            AbstractEnum_DTO abstractEnum_ = tuple.Item3.ToXMLDTO();
            return new Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO>(accessLevel_, sealedEnum_, abstractEnum_);
        }

        public static Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> ToXMLDTO(this Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel_DTO accessLevel_ = tuple.Item1.ToXMLDTO();
            AbstractEnum_DTO abstractEnum_ = tuple.Item2.ToXMLDTO();
            StaticEnum_DTO staticEnum_ = tuple.Item3.ToXMLDTO();
            VirtualEnum_DTO virtualEnum_ = tuple.Item4.ToXMLDTO();
            return new Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO>(accessLevel_, abstractEnum_, staticEnum_, virtualEnum_);
        }
        #endregion
    }
}

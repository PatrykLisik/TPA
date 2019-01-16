using Model;
using Model.DTO;
using SerializationModel;
using SerializationModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static Model.DTO.TypeBaseDTO;
using static SerializationModel.DTO.Type_DTO;

namespace Serialization.Mapper
{
    public static class XMLSerlializationToBase
    {
        public static AssemblyBaseDTO ToBaseDTO(this Assembly_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new AssemblyBaseDTO
            {
                Name = metadata.Name,
                Namespaces = CollectionToBaseDTO(metadata.Namespaces, i => i.ToBaseDTO())
            };
        }

        public static MethodBaseDTO ToBaseDTO(this Method_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new MethodBaseDTO
            {
                Name = metadata.Name,
                GenericArguments = CollectionToBaseDTO(metadata.GenericArguments, i => i.ToBaseDTO()),
                Modifiers = metadata.Modifiers.ToBaseDTO(),
                ReturnType = metadata.ReturnType.ToBaseDTO(),
                Extension = metadata.Extension,
                Parameters = CollectionToBaseDTO(metadata.Parameters, i => i.ToBaseDTO())
            };
        }

        public static NamespaceBaseDTO ToBaseDTO(this Namespace_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new NamespaceBaseDTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionToBaseDTO(metadata.Types, i => i.ToBaseDTO())
            };
        }

        public static ParameterBaseDTO ToBaseDTO(this Parameter_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new ParameterBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static PropertyBaseDTO ToBaseDTO(this Property_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new PropertyBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static TypeBaseDTO ToBaseDTO(this Type_DTO metadata)
        {
            if (metadata == null)
                return null;
            return new TypeBaseDTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.ToBaseDTO(),
                GenericArguments = CollectionToBaseDTO(metadata.GenericArguments, i => i.ToBaseDTO()),
                Modifiers = metadata.Modifiers.ToBaseDTO(),
                TypeKind1 = metadata.TypeKind1.ToBaseDTO(),
                ImplementedInterfaces = CollectionToBaseDTO(metadata.ImplementedInterfaces, i => i.ToBaseDTO()),
                NestedTypes = CollectionToBaseDTO(metadata.NestedTypes, i => i.ToBaseDTO()),
                Properties = CollectionToBaseDTO(metadata.Properties, i => i.ToBaseDTO()),
                DeclaringType = metadata.DeclaringType.ToBaseDTO(),
                Methods = CollectionToBaseDTO(metadata.Methods, i => i.ToBaseDTO()),
                Constructors = CollectionToBaseDTO(metadata.Constructors, i => i.ToBaseDTO()),
                Fields = CollectionToBaseDTO(metadata.Fields, i => i.ToBaseDTO())

            };
        }

        public static IEnumerable<DTO> CollectionToBaseDTO<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func);
        }

        #region Enums
        public static AccessLevelBaseDTO ToBaseDTO(this AccessLevel_DTO enumType)
        {
            switch (enumType)
            {
                case AccessLevel_DTO.IsPrivate:
                    return AccessLevelBaseDTO.IsPrivate;
                case AccessLevel_DTO.IsProtected:
                    return AccessLevelBaseDTO.IsProtected;
                case AccessLevel_DTO.IsProtectedInternal:
                    return AccessLevelBaseDTO.IsProtectedInternal;
                case AccessLevel_DTO.IsPublic:
                    return AccessLevelBaseDTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnumBaseDTO ToBaseDTO(this SealedEnum_DTO enumType)
        {
            switch (enumType)
            {
                case SealedEnum_DTO.NotSealed:
                    return SealedEnumBaseDTO.NotSealed;
                case SealedEnum_DTO.Sealed:
                    return SealedEnumBaseDTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnumBaseDTO ToBaseDTO(this AbstractEnum_DTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnum_DTO.Abstract:
                    return AbstractEnumBaseDTO.Abstract;
                case AbstractEnum_DTO.NotAbstract:
                    return AbstractEnumBaseDTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnumBaseDTO ToBaseDTO(this StaticEnum_DTO enumType)
        {
            switch (enumType)
            {
                case StaticEnum_DTO.NotStatic:
                    return StaticEnumBaseDTO.NotStatic;
                case StaticEnum_DTO.Static:
                    return StaticEnumBaseDTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnumBaseDTO ToBaseDTO(this VirtualEnum_DTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnum_DTO.NotVirtual:
                    return VirtualEnumBaseDTO.NotVirtual;
                case VirtualEnum_DTO.Virtual:
                    return VirtualEnumBaseDTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKindBaseDTO ToBaseDTO(this TypeKind_DTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKind_DTO.ClassType:
                    return TypeKindBaseDTO.ClassType;
                case TypeKind_DTO.EnumType:
                    return TypeKindBaseDTO.EnumType;
                case TypeKind_DTO.InterfaceType:
                    return TypeKindBaseDTO.InterfaceType;
                case TypeKind_DTO.StructType:
                    return TypeKindBaseDTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelBaseDTO accessLevelBase = tuple.Item1.ToBaseDTO();
            SealedEnumBaseDTO sealedEnumBase = tuple.Item2.ToBaseDTO();
            AbstractEnumBaseDTO abstractEnumBase = tuple.Item3.ToBaseDTO();
            return new Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelBaseDTO accessLevelBase = tuple.Item1.ToBaseDTO();
            AbstractEnumBaseDTO abstractEnumBase = tuple.Item2.ToBaseDTO();
            StaticEnumBaseDTO staticEnumBase = tuple.Item3.ToBaseDTO();
            VirtualEnumBaseDTO virtualEnumBase = tuple.Item4.ToBaseDTO();
            return new Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO>(accessLevelBase, abstractEnumBase, staticEnumBase, virtualEnumBase);
        }
        #endregion
    }
}

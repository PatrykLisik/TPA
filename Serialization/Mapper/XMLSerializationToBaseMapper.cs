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
    public static class XMLSerializationToBaseMapper
    {
        public static Assembly_DTO MapToSerializationModel(this AssemblyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Assembly_DTO
            {
                Name = metadata.Name,
                Namespaces = CollectionMapToObject(metadata.Namespaces, i => i.MapToSerializationModel())
            };
        }

        public static Method_DTO MapToSerializationModel(this MethodBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Method_DTO
            {
                Name = metadata.Name,
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToSerializationModel()),
                Modifiers = metadata.Modifiers.MapToSerializationModel(),
                ReturnType = metadata.ReturnType.MapToSerializationModel(),
                Extension = metadata.Extension,
                Parameters = CollectionMapToObject(metadata.Parameters, i => i.MapToSerializationModel())
            };
        }

        public static Namespace_DTO MapToSerializationModel(this NamespaceBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Namespace_DTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionMapToObject(metadata.Types, i => i.MapToSerializationModel())
            };
        }

        public static Parameter_DTO MapToSerializationModel(this ParameterBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Parameter_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToSerializationModel()
            };
        }

        public static Property_DTO MapToSerializationModel(this PropertyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Property_DTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToSerializationModel()
            };
        }

        public static Type_DTO MapToSerializationModel(this TypeBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new Type_DTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.MapToSerializationModel(),
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToSerializationModel()),
                Modifiers = metadata.Modifiers.MapToSerializationModel(),
                TypeKind1 = metadata.TypeKind1.MapToSerializationModel(),
                ImplementedInterfaces = CollectionMapToObject(metadata.ImplementedInterfaces, i => i.MapToSerializationModel()),
                NestedTypes = CollectionMapToObject(metadata.NestedTypes, i => i.MapToSerializationModel()),
                Properties = CollectionMapToObject(metadata.Properties, i => i.MapToSerializationModel()),
                DeclaringType = metadata.DeclaringType.MapToSerializationModel(),
                Methods = CollectionMapToObject(metadata.Methods, i => i.MapToSerializationModel()),
                Constructors = CollectionMapToObject(metadata.Constructors, i => i.MapToSerializationModel()),
                Fields = CollectionMapToObject(metadata.Fields, i => i.MapToSerializationModel())

            };
        }
        public static IEnumerable<DTO> CollectionMapToObject<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func);
        }
        #region Enums
        public static AccessLevel_DTO MapToSerializationModel(this AccessLevelBaseDTO enumType)
        {
            switch (enumType)
            {
                case AccessLevelBaseDTO.IsPrivate:
                    return AccessLevel_DTO.IsPrivate;
                case AccessLevelBaseDTO.IsProtected:
                    return AccessLevel_DTO.IsProtected;
                case AccessLevelBaseDTO.IsProtectedInternal:
                    return AccessLevel_DTO.IsProtectedInternal;
                case AccessLevelBaseDTO.IsPublic:
                    return AccessLevel_DTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnum_DTO MapToSerializationModel(this SealedEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case SealedEnumBaseDTO.NotSealed:
                    return SealedEnum_DTO.NotSealed;
                case SealedEnumBaseDTO.Sealed:
                    return SealedEnum_DTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnum_DTO MapToSerializationModel(this AbstractEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnumBaseDTO.Abstract:
                    return AbstractEnum_DTO.Abstract;
                case AbstractEnumBaseDTO.NotAbstract:
                    return AbstractEnum_DTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnum_DTO MapToSerializationModel(this StaticEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case StaticEnumBaseDTO.NotStatic:
                    return StaticEnum_DTO.NotStatic;
                case StaticEnumBaseDTO.Static:
                    return StaticEnum_DTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnum_DTO MapToSerializationModel(this VirtualEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnumBaseDTO.NotVirtual:
                    return VirtualEnum_DTO.NotVirtual;
                case VirtualEnumBaseDTO.Virtual:
                    return VirtualEnum_DTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKind_DTO MapToSerializationModel(this TypeKindBaseDTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKindBaseDTO.ClassType:
                    return TypeKind_DTO.ClassType;
                case TypeKindBaseDTO.EnumType:
                    return TypeKind_DTO.EnumType;
                case TypeKindBaseDTO.InterfaceType:
                    return TypeKind_DTO.InterfaceType;
                case TypeKindBaseDTO.StructType:
                    return TypeKind_DTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO> MapToSerializationModel(this Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel_DTO accessLevelBase = tuple.Item1.MapToSerializationModel();
            SealedEnum_DTO sealedEnumBase = tuple.Item2.MapToSerializationModel();
            AbstractEnum_DTO abstractEnumBase = tuple.Item3.MapToSerializationModel();
            return new Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> MapToSerializationModel(this Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel_DTO accessLevelBase = tuple.Item1.MapToSerializationModel();
            AbstractEnum_DTO abstractEnumBase = tuple.Item2.MapToSerializationModel();
            StaticEnum_DTO staticEnumBase = tuple.Item3.MapToSerializationModel();
            VirtualEnum_DTO virtualEnumBase = tuple.Item4.MapToSerializationModel();
            return new Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO>(accessLevelBase, abstractEnumBase, staticEnumBase, virtualEnumBase);
        }
        #endregion
    }
}

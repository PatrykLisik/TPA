using Logic.ReflectionMetadata;
using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static Logic.ReflectionMetadata.TypeMetadata;
using static Model.DTO.TypeBaseDTO;

namespace Logic.Mappers
{
    public static class DTOToAssemblyMetadata
    {
        public static AssemblyMetadata MapToObject(this AssemblyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new AssemblyMetadata
            {
                Name = metadata.Name,
                Namespaces = CollectionMapToObject(metadata.Namespaces, i => i.MapToObject())
            };
        }

        public static MethodMetadata MapToObject(this MethodBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new MethodMetadata
            {
                Name = metadata.Name,
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToObject()),
                Modifiers = metadata.Modifiers.MapToObject(),
                ReturnType = metadata.ReturnType.MapToObject(),
                Extension = metadata.Extension,
                Parameters = CollectionMapToObject(metadata.Parameters, i => i.MapToObject())
            };
        }

        public static NamespaceMetadata MapToObject(this NamespaceBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new NamespaceMetadata
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionMapToObject(metadata.Types, i => i.MapToObject())
            };
        }

        public static ParameterMetadata MapToObject(this ParameterBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new ParameterMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static PropertyMetadata MapToObject(this PropertyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new PropertyMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static TypeMetadata MapToObject(this TypeBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new TypeMetadata
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.MapToObject(),
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToObject()),
                Modifiers = metadata.Modifiers.MapToObject(),
                TypeKind1 = metadata.TypeKind1.MapToObject(),
                ImplementedInterfaces = CollectionMapToObject(metadata.ImplementedInterfaces, i => i.MapToObject()),
                NestedTypes = CollectionMapToObject(metadata.NestedTypes, i => i.MapToObject()),
                Properties = CollectionMapToObject(metadata.Properties, i => i.MapToObject()),
                DeclaringType = metadata.DeclaringType.MapToObject(),
                Methods = CollectionMapToObject(metadata.Methods, i => i.MapToObject()),
                Constructors = CollectionMapToObject(metadata.Constructors, i => i.MapToObject()),
                Fields = CollectionMapToObject(metadata.Fields, i => i.MapToObject())

            };
        }
        public static IEnumerable<DTO> CollectionMapToObject<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func);
        }
        #region Enums
        public static AccessLevel MapToObject(this AccessLevelBaseDTO enumType)
        {
            switch (enumType)
            {
                case AccessLevelBaseDTO.IsPrivate:
                    return AccessLevel.IsPrivate;
                case AccessLevelBaseDTO.IsProtected:
                    return AccessLevel.IsProtected;
                case AccessLevelBaseDTO.IsProtectedInternal:
                    return AccessLevel.IsProtectedInternal;
                case AccessLevelBaseDTO.IsPublic:
                    return AccessLevel.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnum MapToObject(this SealedEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case SealedEnumBaseDTO.NotSealed:
                    return SealedEnum.NotSealed;
                case SealedEnumBaseDTO.Sealed:
                    return SealedEnum.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnum MapToObject(this AbstractEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnumBaseDTO.Abstract:
                    return AbstractEnum.Abstract;
                case AbstractEnumBaseDTO.NotAbstract:
                    return AbstractEnum.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnum MapToObject(this StaticEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case StaticEnumBaseDTO.NotStatic:
                    return StaticEnum.NotStatic;
                case StaticEnumBaseDTO.Static:
                    return StaticEnum.Static;
            }
            throw new Exception();
        }

        public static VirtualEnum MapToObject(this VirtualEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnumBaseDTO.NotVirtual:
                    return VirtualEnum.NotVirtual;
                case VirtualEnumBaseDTO.Virtual:
                    return VirtualEnum.Virtual;
            }
            throw new Exception();
        }

        public static TypeKind MapToObject(this TypeKindBaseDTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKindBaseDTO.ClassType:
                    return TypeKind.ClassType;
                case TypeKindBaseDTO.EnumType:
                    return TypeKind.EnumType;
                case TypeKindBaseDTO.InterfaceType:
                    return TypeKind.InterfaceType;
                case TypeKindBaseDTO.StructType:
                    return TypeKind.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevel, SealedEnum, AbstractEnum> MapToObject(this Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel accessLevelBase = tuple.Item1.MapToObject();
            SealedEnum sealedEnumBase = tuple.Item2.MapToObject();
            AbstractEnum abstractEnumBase = tuple.Item3.MapToObject();
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> MapToObject(this Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel accessLevelBase = tuple.Item1.MapToObject();
            AbstractEnum abstractEnumBase = tuple.Item2.MapToObject();
            StaticEnum staticEnumBase = tuple.Item3.MapToObject();
            VirtualEnum virtualEnumBase = tuple.Item4.MapToObject();
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(accessLevelBase, abstractEnumBase, staticEnumBase, virtualEnumBase);
        }
        #endregion

    }
}

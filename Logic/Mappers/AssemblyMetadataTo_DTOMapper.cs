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
    public static class AssemblyMetadataToBaseDTOMapper
    {
        static Dictionary<string, TypeBaseDTO> types = new Dictionary<string, TypeBaseDTO>();
        public static AssemblyBaseDTO ToBaseDTO(this AssemblyMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new AssemblyBaseDTO
            {
                Name = metadata.Name,
                Namespaces = CollectionToBaseDTO(metadata.Namespaces, i => i.ToBaseDTO())
            };
        }

        public static MethodBaseDTO ToBaseDTO(this MethodMetadata metadata)
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

        public static NamespaceBaseDTO ToBaseDTO(this NamespaceMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new NamespaceBaseDTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionToBaseDTO(metadata.Types, i => i.ToBaseDTO())
            };
        }

        public static ParameterBaseDTO ToBaseDTO(this ParameterMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new ParameterBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static PropertyBaseDTO ToBaseDTO(this PropertyMetadata metadata)
        {
            if (metadata == null)
                return null;
            return new PropertyBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static TypeBaseDTO ToBaseDTO(this TypeMetadata metadata)
        {
            if (metadata == null)
                return null;
            if (types.ContainsKey(metadata.TypeName))
            {
                return types[metadata.TypeName];
            }
            var t= new TypeBaseDTO ////NAPRAWIC REKURENCJE DLA KAZDEGO POLA
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

            if (types.ContainsKey(metadata.TypeName))
            {
                return types[metadata.TypeName];
            }
            if (!types.ContainsKey(metadata.TypeName))
            {
                types.Add(metadata.TypeName, t);
            }
            return t;

        }

        public static IEnumerable<DTO> CollectionToBaseDTO<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func);
        }

        #region Enums
        public static AccessLevelBaseDTO ToBaseDTO(this AccessLevel enumType)
        {
            switch (enumType)
            {
                case AccessLevel.IsPrivate:
                    return AccessLevelBaseDTO.IsPrivate;
                case AccessLevel.IsProtected:
                    return AccessLevelBaseDTO.IsProtected;
                case AccessLevel.IsProtectedInternal:
                    return AccessLevelBaseDTO.IsProtectedInternal;
                case AccessLevel.IsPublic:
                    return AccessLevelBaseDTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnumBaseDTO ToBaseDTO(this SealedEnum enumType)
        {
            switch (enumType)
            {
                case SealedEnum.NotSealed:
                    return SealedEnumBaseDTO.NotSealed;
                case SealedEnum.Sealed:
                    return SealedEnumBaseDTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnumBaseDTO ToBaseDTO(this AbstractEnum enumType)
        {
            switch (enumType)
            {
                case AbstractEnum.Abstract:
                    return AbstractEnumBaseDTO.Abstract;
                case AbstractEnum.NotAbstract:
                    return AbstractEnumBaseDTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnumBaseDTO ToBaseDTO(this StaticEnum enumType)
        {
            switch (enumType)
            {
                case StaticEnum.NotStatic:
                    return StaticEnumBaseDTO.NotStatic;
                case StaticEnum.Static:
                    return StaticEnumBaseDTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnumBaseDTO ToBaseDTO(this VirtualEnum enumType)
        {
            switch (enumType)
            {
                case VirtualEnum.NotVirtual:
                    return VirtualEnumBaseDTO.NotVirtual;
                case VirtualEnum.Virtual:
                    return VirtualEnumBaseDTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKindBaseDTO ToBaseDTO(this TypeKind typeKind)
        {
            switch (typeKind)
            {
                case TypeKind.ClassType:
                    return TypeKindBaseDTO.ClassType;
                case TypeKind.EnumType:
                    return TypeKindBaseDTO.EnumType;
                case TypeKind.InterfaceType:
                    return TypeKindBaseDTO.InterfaceType;
                case TypeKind.StructType:
                    return TypeKindBaseDTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevel, SealedEnum, AbstractEnum> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelBaseDTO accessLevelBase = tuple.Item1.ToBaseDTO();
            SealedEnumBaseDTO sealedEnumBase = tuple.Item2.ToBaseDTO();
            AbstractEnumBaseDTO abstractEnumBase = tuple.Item3.ToBaseDTO();
            return new Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> tuple)
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

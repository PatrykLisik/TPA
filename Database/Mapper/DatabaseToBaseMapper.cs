using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.DTO.TypeBaseDTO;
using static Model.DTO.TypeDataBaseDTO;

namespace Database.Mapper
{
    public static class DatabaseToBaseMapper
    {
        public static AssemblyBaseDTO ToBaseDTO(this AssemblyDataBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new AssemblyBaseDTO
            {
                Name = metadata.Name,
                Namespaces = CollectionToBaseDTO(metadata.Namespaces, i => i.ToBaseDTO())
            };
        }

        public static MethodBaseDTO ToBaseDTO(this MethodDataBaseDTO metadata)
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

        public static NamespaceBaseDTO ToBaseDTO(this NamespaceDataBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new NamespaceBaseDTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionToBaseDTO(metadata.Types, i => i.ToBaseDTO())
            };
        }

        public static ParameterBaseDTO ToBaseDTO(this ParameterDataBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new ParameterBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static PropertyBaseDTO ToBaseDTO(this PropertyDataBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new PropertyBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.ToBaseDTO()
            };
        }

        public static TypeBaseDTO ToBaseDTO(this TypeDataBaseDTO metadata)
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
        public static AccessLevelBaseDTO ToBaseDTO(this AccessLevelDataBaseDTO enumType)
        {
            switch (enumType)
            {
                case AccessLevelDataBaseDTO.IsPrivate:
                    return AccessLevelBaseDTO.IsPrivate;
                case AccessLevelDataBaseDTO.IsProtected:
                    return AccessLevelBaseDTO.IsProtected;
                case AccessLevelDataBaseDTO.IsProtectedInternal:
                    return AccessLevelBaseDTO.IsProtectedInternal;
                case AccessLevelDataBaseDTO.IsPublic:
                    return AccessLevelBaseDTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnumBaseDTO ToBaseDTO(this SealedEnumDataBaseDTO enumType)
        {
            switch (enumType)
            {
                case SealedEnumDataBaseDTO.NotSealed:
                    return SealedEnumBaseDTO.NotSealed;
                case SealedEnumDataBaseDTO.Sealed:
                    return SealedEnumBaseDTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnumBaseDTO ToBaseDTO(this AbstractEnumDataBaseDTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnumDataBaseDTO.Abstract:
                    return AbstractEnumBaseDTO.Abstract;
                case AbstractEnumDataBaseDTO.NotAbstract:
                    return AbstractEnumBaseDTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnumBaseDTO ToBaseDTO(this StaticEnumDataBaseDTO enumType)
        {
            switch (enumType)
            {
                case StaticEnumDataBaseDTO.NotStatic:
                    return StaticEnumBaseDTO.NotStatic;
                case StaticEnumDataBaseDTO.Static:
                    return StaticEnumBaseDTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnumBaseDTO ToBaseDTO(this VirtualEnumDataBaseDTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnumDataBaseDTO.NotVirtual:
                    return VirtualEnumBaseDTO.NotVirtual;
                case VirtualEnumDataBaseDTO.Virtual:
                    return VirtualEnumBaseDTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKindBaseDTO ToBaseDTO(this TypeKindDataBaseDTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKindDataBaseDTO.ClassType:
                    return TypeKindBaseDTO.ClassType;
                case TypeKindDataBaseDTO.EnumType:
                    return TypeKindBaseDTO.EnumType;
                case TypeKindDataBaseDTO.InterfaceType:
                    return TypeKindBaseDTO.InterfaceType;
                case TypeKindDataBaseDTO.StructType:
                    return TypeKindBaseDTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelBaseDTO accessLevelBase = tuple.Item1.ToBaseDTO();
            SealedEnumBaseDTO sealedEnumBase = tuple.Item2.ToBaseDTO();
            AbstractEnumBaseDTO abstractEnumBase = tuple.Item3.ToBaseDTO();
            return new Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> ToBaseDTO(this Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO> tuple)
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

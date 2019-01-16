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
    public static class BaseToDatabaseMapper
    {
        public static AssemblyDataBaseDTO MapToDatabaseModel(this AssemblyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new AssemblyDataBaseDTO
            {
                Name = metadata.Name,
                Namespaces = CollectionMapToObject(metadata.Namespaces, i => i.MapToDatabaseModel())
            };
        }

        public static MethodDataBaseDTO MapToDatabaseModel(this MethodBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new MethodDataBaseDTO
            {
                Name = metadata.Name,
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToDatabaseModel()),
                Modifiers = metadata.Modifiers.MapToDatabaseModel(),
                ReturnType = metadata.ReturnType.MapToDatabaseModel(),
                Extension = metadata.Extension,
                Parameters = CollectionMapToObject(metadata.Parameters, i => i.MapToDatabaseModel())
            };
        }

        public static NamespaceDataBaseDTO MapToDatabaseModel(this NamespaceBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new NamespaceDataBaseDTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionMapToObject(metadata.Types, i => i.MapToDatabaseModel())
            };
        }

        public static ParameterDataBaseDTO MapToDatabaseModel(this ParameterBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new ParameterDataBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToDatabaseModel()
            };
        }

        public static PropertyDataBaseDTO MapToDatabaseModel(this PropertyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new PropertyDataBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToDatabaseModel()
            };
        }

        public static TypeDataBaseDTO MapToDatabaseModel(this TypeBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new TypeDataBaseDTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.MapToDatabaseModel(),
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToDatabaseModel()),
                Modifiers = metadata.Modifiers.MapToDatabaseModel(),
                TypeKind1 = metadata.TypeKind1.MapToDatabaseModel(),
                ImplementedInterfaces = CollectionMapToObject(metadata.ImplementedInterfaces, i => i.MapToDatabaseModel()),
                NestedTypes = CollectionMapToObject(metadata.NestedTypes, i => i.MapToDatabaseModel()),
                Properties = CollectionMapToObject(metadata.Properties, i => i.MapToDatabaseModel()),
                DeclaringType = metadata.DeclaringType.MapToDatabaseModel(),
                Methods = CollectionMapToObject(metadata.Methods, i => i.MapToDatabaseModel()),
                Constructors = CollectionMapToObject(metadata.Constructors, i => i.MapToDatabaseModel()),
                Fields = CollectionMapToObject(metadata.Fields, i => i.MapToDatabaseModel())

            };
        }
        public static ICollection<DTO> CollectionMapToObject<Metada, DTO>(IEnumerable<Metada> metadata, Func<Metada, DTO> func)
        {
            if (metadata == null)
                return null;

            return metadata.Select(func).ToArray();
        }
        #region Enums
        public static AccessLevelDataBaseDTO MapToDatabaseModel(this AccessLevelBaseDTO enumType)
        {
            switch (enumType)
            {
                case AccessLevelBaseDTO.IsPrivate:
                    return AccessLevelDataBaseDTO.IsPrivate;
                case AccessLevelBaseDTO.IsProtected:
                    return AccessLevelDataBaseDTO.IsProtected;
                case AccessLevelBaseDTO.IsProtectedInternal:
                    return AccessLevelDataBaseDTO.IsProtectedInternal;
                case AccessLevelBaseDTO.IsPublic:
                    return AccessLevelDataBaseDTO.IsPublic;
            }
            throw new Exception();
        }

        public static SealedEnumDataBaseDTO MapToDatabaseModel(this SealedEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case SealedEnumBaseDTO.NotSealed:
                    return SealedEnumDataBaseDTO.NotSealed;
                case SealedEnumBaseDTO.Sealed:
                    return SealedEnumDataBaseDTO.Sealed;
            }
            throw new Exception();
        }

        public static AbstractEnumDataBaseDTO MapToDatabaseModel(this AbstractEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case AbstractEnumBaseDTO.Abstract:
                    return AbstractEnumDataBaseDTO.Abstract;
                case AbstractEnumBaseDTO.NotAbstract:
                    return AbstractEnumDataBaseDTO.NotAbstract;
            }
            throw new Exception();
        }

        public static StaticEnumDataBaseDTO MapToDatabaseModel(this StaticEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case StaticEnumBaseDTO.NotStatic:
                    return StaticEnumDataBaseDTO.NotStatic;
                case StaticEnumBaseDTO.Static:
                    return StaticEnumDataBaseDTO.Static;
            }
            throw new Exception();
        }

        public static VirtualEnumDataBaseDTO MapToDatabaseModel(this VirtualEnumBaseDTO enumType)
        {
            switch (enumType)
            {
                case VirtualEnumBaseDTO.NotVirtual:
                    return VirtualEnumDataBaseDTO.NotVirtual;
                case VirtualEnumBaseDTO.Virtual:
                    return VirtualEnumDataBaseDTO.Virtual;
            }
            throw new Exception();
        }

        public static TypeKindDataBaseDTO MapToDatabaseModel(this TypeKindBaseDTO typeKind)
        {
            switch (typeKind)
            {
                case TypeKindBaseDTO.ClassType:
                    return TypeKindDataBaseDTO.ClassType;
                case TypeKindBaseDTO.EnumType:
                    return TypeKindDataBaseDTO.EnumType;
                case TypeKindBaseDTO.InterfaceType:
                    return TypeKindDataBaseDTO.InterfaceType;
                case TypeKindBaseDTO.StructType:
                    return TypeKindDataBaseDTO.StructType;
            }
            throw new Exception();
        }

        public static Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> MapToDatabaseModel(this Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelDataBaseDTO accessLevelBase = tuple.Item1.MapToDatabaseModel();
            SealedEnumDataBaseDTO sealedEnumBase = tuple.Item2.MapToDatabaseModel();
            AbstractEnumDataBaseDTO abstractEnumBase = tuple.Item3.MapToDatabaseModel();
            return new Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO> MapToDatabaseModel(this Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelDataBaseDTO accessLevelBase = tuple.Item1.MapToDatabaseModel();
            AbstractEnumDataBaseDTO abstractEnumBase = tuple.Item2.MapToDatabaseModel();
            StaticEnumDataBaseDTO staticEnumBase = tuple.Item3.MapToDatabaseModel();
            VirtualEnumDataBaseDTO virtualEnumBase = tuple.Item4.MapToDatabaseModel();
            return new Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO>(accessLevelBase, abstractEnumBase, staticEnumBase, virtualEnumBase);
        }
        #endregion
    }
}

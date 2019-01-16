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
        public static AssemblyDataBaseDTO MapToSerializationModel(this AssemblyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new AssemblyDataBaseDTO
            {
                Name = metadata.Name,
                Namespaces = CollectionMapToObject(metadata.Namespaces, i => i.MapToSerializationModel())
            };
        }

        public static MethodDataBaseDTO MapToSerializationModel(this MethodBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new MethodDataBaseDTO
            {
                Name = metadata.Name,
                GenericArguments = CollectionMapToObject(metadata.GenericArguments, i => i.MapToSerializationModel()),
                Modifiers = metadata.Modifiers.MapToSerializationModel(),
                ReturnType = metadata.ReturnType.MapToSerializationModel(),
                Extension = metadata.Extension,
                Parameters = CollectionMapToObject(metadata.Parameters, i => i.MapToSerializationModel())
            };
        }

        public static NamespaceDataBaseDTO MapToSerializationModel(this NamespaceBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new NamespaceDataBaseDTO
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionMapToObject(metadata.Types, i => i.MapToSerializationModel())
            };
        }

        public static ParameterDataBaseDTO MapToSerializationModel(this ParameterBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new ParameterDataBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToSerializationModel()
            };
        }

        public static PropertyDataBaseDTO MapToSerializationModel(this PropertyBaseDTO metadata)
        {
            if (metadata == null)
                return null;

            return new PropertyDataBaseDTO
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToSerializationModel()
            };
        }

        public static TypeDataBaseDTO MapToSerializationModel(this TypeBaseDTO metadata)
        {
            if (metadata == null)
                return null;
            return new TypeDataBaseDTO
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
        public static AccessLevelDataBaseDTO MapToSerializationModel(this AccessLevelBaseDTO enumType)
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

        public static SealedEnumDataBaseDTO MapToSerializationModel(this SealedEnumBaseDTO enumType)
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

        public static AbstractEnumDataBaseDTO MapToSerializationModel(this AbstractEnumBaseDTO enumType)
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

        public static StaticEnumDataBaseDTO MapToSerializationModel(this StaticEnumBaseDTO enumType)
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

        public static VirtualEnumDataBaseDTO MapToSerializationModel(this VirtualEnumBaseDTO enumType)
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

        public static TypeKindDataBaseDTO MapToSerializationModel(this TypeKindBaseDTO typeKind)
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

        public static Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> MapToSerializationModel(this Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelDataBaseDTO accessLevelBase = tuple.Item1.MapToSerializationModel();
            SealedEnumDataBaseDTO sealedEnumBase = tuple.Item2.MapToSerializationModel();
            AbstractEnumDataBaseDTO abstractEnumBase = tuple.Item3.MapToSerializationModel();
            return new Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO>(accessLevelBase, sealedEnumBase, abstractEnumBase);
        }

        public static Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO> MapToSerializationModel(this Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevelDataBaseDTO accessLevelBase = tuple.Item1.MapToSerializationModel();
            AbstractEnumDataBaseDTO abstractEnumBase = tuple.Item2.MapToSerializationModel();
            StaticEnumDataBaseDTO staticEnumBase = tuple.Item3.MapToSerializationModel();
            VirtualEnumDataBaseDTO virtualEnumBase = tuple.Item4.MapToSerializationModel();
            return new Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO>(accessLevelBase, abstractEnumBase, staticEnumBase, virtualEnumBase);
        }
        #endregion
    }
}

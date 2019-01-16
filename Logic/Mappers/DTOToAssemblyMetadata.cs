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
    public static class DTOToAssemblyMetadata
    {
        public static AssemblyMetadata MapToObject(this Assembly_DTO metadata)
        {
            if (metadata == null)
                return null;

            return new AssemblyMetadata
            {
                Name = metadata.Name,
                Namespaces = CollectionMapToObject(metadata.Namespaces, i => i.MapToObject())
            };
        }

        public static MethodMetadata  MapToObject(this Method_DTO metadata)
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

        public static  NamespaceMetadata MapToObject(this Namespace_DTO metadata)
        {
            if (metadata == null)
                return null;

            return new NamespaceMetadata
            {
                NamespaceName = metadata.NamespaceName,
                Types = CollectionMapToObject(metadata.Types, i => i.MapToObject())
            };
        }

        public static ParameterMetadata  MapToObject(this Parameter_DTO metadata)
        {
            if (metadata == null)
                return null;

            return new ParameterMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static PropertyMetadata  MapToObject(this Property_DTO metadata)
        {
            if (metadata == null)
                return null;

            return new PropertyMetadata
            {
                Name = metadata.Name,
                TypeMetadata = metadata.TypeMetadata.MapToObject()
            };
        }

        public static TypeMetadata  MapToObject(this Type_DTO metadata)
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
        public static AccessLevel  MapToObject(this AccessLevel_DTO enumType)
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

        public static SealedEnum  MapToObject(this SealedEnum_DTO enumType)
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

        public static AbstractEnum MapToObject(this  AbstractEnum_DTO enumType)
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

        public static StaticEnum MapToObject(this StaticEnum_DTO enumType)
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

        public static VirtualEnum MapToObject(this VirtualEnum_DTO enumType)
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

        public static TypeKind MapToObject(this TypeKind_DTO typeKind)
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

        public static Tuple<AccessLevel, SealedEnum, AbstractEnum> MapToObject(this Tuple<AccessLevel_DTO, SealedEnum_DTO, AbstractEnum_DTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel accessLevel_ = tuple.Item1.MapToObject();
            SealedEnum sealedEnum_ = tuple.Item2.MapToObject();
            AbstractEnum abstractEnum_ = tuple.Item3.MapToObject();
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(accessLevel_, sealedEnum_, abstractEnum_);
        }

        public static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> MapToObject(this Tuple<AccessLevel_DTO, AbstractEnum_DTO, StaticEnum_DTO, VirtualEnum_DTO> tuple)
        {
            if (tuple == null)
                return null;
            AccessLevel accessLevel_ = tuple.Item1.MapToObject();
            AbstractEnum abstractEnum_ = tuple.Item2.MapToObject();
            StaticEnum staticEnum_ = tuple.Item3.MapToObject();
            VirtualEnum virtualEnum_ = tuple.Item4.MapToObject();
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(accessLevel_, abstractEnum_, staticEnum_, virtualEnum_);
        }
        #endregion

    }
}

using Logic.ReflectionMetadata;
using SerializationModel;
using SerializationModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappers
{
    public static class XML_DTO_Mapper
    {
        public static Assembly_DTO ToXML_DTO(this AssemblyMetadata metadata)
        {
            return null;
        }

        public static Method_DTO ToXML_DTO(this MethodMetadata metadata)
        {
            return null;
        }

        public static Namespace_DTO ToXML_DTO(this NamespaceMetadata metadata)
        {
            return null;
        }

        public static Parameter_DTO ToXML_DTO(this ParameterMetadata metadata)
        {
            return null;
        }

        public static Property_DTO ToXML_DTO(this PropertyMetadata metadata)
        {
            return null;
        }

        public static Type_DTO ToXML_DTO(this TypeMetadata metadata)
        {
            return new Type_DTO
            {
                TypeName = metadata.TypeName,
                NamespaceName = metadata.NamespaceName,
                BaseType = metadata.BaseType.ToXML_DTO(),
                GenericArguments = metadata.GenericArguments.Select(i => i.ToXML_DTO())

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

        #endregion
    }
}

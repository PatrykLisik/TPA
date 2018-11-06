using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReflectionMetadata
{
    public static class EnumsStringify{

        internal static string Stringify(this VirtualEnum virtualEnum)
        {
            if (virtualEnum == VirtualEnum.Virtual)
                return "Virtual ";
            return "";
        }

        internal static string Stringify(this AccessLevel accesLevel)
        {
            return Enum.GetName(typeof(AccessLevel), accesLevel).Replace("Is", "");
        }

        internal static string Stringify(this SealedEnum sealedEnum)
        {
            if (sealedEnum == SealedEnum.Sealed)
                return "Seald ";
            return "";
        }

        internal static string Stringify(this AbstractEnum sealedEnum)
        {
            if (sealedEnum == AbstractEnum.Abstract)
                return "Abstract ";
            return "";
        }

        internal static string Stringify(this StaticEnum staticEnum)
        {
            if (staticEnum == StaticEnum.Static)
                return "Static ";
            return "";
        }
    }

}

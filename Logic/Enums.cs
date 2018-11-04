using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public enum AbstractEnum
    {
        NotAbstract, Abstract
    }
    public enum AccessLevel
    {
        IsPublic, IsProtected, IsProtectedInternal, IsPrivate
    }
    public enum StaticEnum
    {
        NotStatic, Static
    }
    public enum VirtualEnum
    {
        NotVirtual, Virtual
    }
}

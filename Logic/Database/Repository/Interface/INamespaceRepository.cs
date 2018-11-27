using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repository.Interface
{
    public interface INamespaceRepository
    {
        void AddNamespace(Namespace property);
        void Save();
    }
}

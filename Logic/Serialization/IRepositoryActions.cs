using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Serialization
{
    public interface IRepositoryActions<T>
    {
        void SaveToRepository(T data, string fileName);
        T LoadFromRepository(string fileName);
    }
}

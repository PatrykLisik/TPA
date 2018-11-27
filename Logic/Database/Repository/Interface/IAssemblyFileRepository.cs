using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repository.Interface
{
    public interface IAssemblyFileRepository
    {
        void AddAssemblyFile(AssemblyFile assemblyFile);
        void Save();
        object GetAssemblyFile();
    }
}

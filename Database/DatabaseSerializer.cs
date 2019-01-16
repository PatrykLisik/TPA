using Model.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseSerializer : IRepositoryActions
    {
        public AssemblyBaseDTO LoadFromRepository(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveToRepository(AssemblyBaseDTO data, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}

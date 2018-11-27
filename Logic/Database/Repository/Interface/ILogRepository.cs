using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repository.Interface
{
    interface ILogRepository
    {
        void AddNewLog(string message, DateTime date, string classType);
    }
}

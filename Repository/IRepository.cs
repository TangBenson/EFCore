using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IRepository
    {
        Task<String> InsertData(object data);
        String SelectData(int id);
    }
}
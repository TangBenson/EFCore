using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Service
{
    public interface ICrudService
    {
        Task<string> CreateData(object data);
        string GetData(int id);
    }
}
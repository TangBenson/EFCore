using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Service
{
    public interface ICreateDataService<T> where T : class
    {
        Task<string> CreateData(T data);
    }
}
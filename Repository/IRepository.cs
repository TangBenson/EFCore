using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<String> InsertOther(T data);
    }
}
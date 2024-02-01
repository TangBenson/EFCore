using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using EFCore.Repository;

namespace EFCore.Service
{
    public class CrudService<T> : ICrudService<T> where T : class
    {

        private readonly IRepository<T> _repository;
        public CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateData(T data)
        {
            string result = await _repository.InsertOther(data);
            return result;
        }
        public async Task<string> GetData()
        {
            string result = await _repository.SelectData();
            return "GetData";
        }
    }
}
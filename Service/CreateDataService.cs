using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using EFCore.Repository;

namespace EFCore.Service
{
    public class CreateDataService<T> : ICreateDataService<T> where T : class
    {

        private readonly IRepository<T> _repository;
        public CreateDataService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateData(T data)
        {
            string result = await _repository.InsertOther(data);
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using EFCore.Repository;

namespace EFCore.Service
{
    public class CrudService : ICrudService
    {

        private readonly IRepository _repository;
        public CrudService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateData(object data)
        {
            string result = await _repository.InsertData(data);
            return result;
        }
        public string GetData(int id)
        {
            _ = _repository.SelectData(id);
            return "GetData";
        }
    }
}
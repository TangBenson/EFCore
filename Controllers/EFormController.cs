using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EFCore.Entities;
using EFCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EFormController : ControllerBase
    {
        private readonly ICrudService _crudData;
        public EFormController(ICrudService crudService)
        {
            _crudData = crudService;
        }

        [HttpGet("{id}")]
        public IActionResult SelectData(int id)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            _ = _crudData.GetData(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] JsonElement data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            switch (data.GetProperty("type").GetString())
            {
                case "Order":
                    var a = new Order();
                    await _crudData.CreateData(a);
                    break;
                case "Customer":
                    var b = new Customer();
                    await _crudData.CreateData(b);
                    break;
                case "Product":
                    var c = new Product();
                    await _crudData.CreateData(c);
                    break;
                default:
                    return BadRequest();
            }
            return Ok();
        }

        // [HttpPut]
        // public IActionResult UpdateData([FromBody] T data)
        // {
        //     //驗證HTTP請求
        //     //驗證HTTP資料
        //     //呼叫商業邏輯
        //     return Ok();
        // }

        // [HttpDelete]
        // public IActionResult DeleteData([FromBody] T data)
        // {
        //     //驗證HTTP請求
        //     //驗證HTTP資料
        //     //呼叫商業邏輯
        //     return Ok();
        // }
    }
}
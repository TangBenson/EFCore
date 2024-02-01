using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using EFCore.Models;
using EFCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OderController<T> : ControllerBase where T : class
    {
        private readonly CrudService<T> _createData;
        public OderController(CrudService<T> createDataService)
        {
            _createData = createDataService;
        }

        [HttpGet]
        public IActionResult SelectData()
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] T data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            await _createData.CreateData(data);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Input_OrderData data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateOrder([FromBody] Input_OrderData data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOrder([FromBody] Input_OrderData data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            return Ok();
        }
    }
}
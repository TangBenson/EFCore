using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OderController : ControllerBase
    {
        public OderController()
        {
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
        
        [HttpGet]
        public IActionResult SelectOrder([FromBody] Input_OrderData data)
        {
            //驗證HTTP請求
            //驗證HTTP資料
            //呼叫商業邏輯
            return Ok();
        }
    }
}
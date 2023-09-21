using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // api/Calculator/Add?x=2&y=10
        [HttpGet("Calculator/add")]
        public int Add(int x, int y)
        { 
            return x+y; 
        } 
        [HttpGet("Calculator/sum")]
        public int Sum(int x, int y)
        { 
            return x+y+1000; 
        }
        //api/calculator/Subtract? x = 20 & y = 10
       [HttpPost]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        // api/calculator/Multiply?x=250&y=10
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/calculator/Divide?x=200&y=10
        [HttpDelete]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}

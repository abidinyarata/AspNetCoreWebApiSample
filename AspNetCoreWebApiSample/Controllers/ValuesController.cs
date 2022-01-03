using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreWebApiSample.Controllers
{
    // convention-based routing
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> list = new List<string>() { "istanbul", "izmir", "ankara", "antalya"};

        [HttpGet]
        public List<string> Get()
        {
            return list;
        }

        // <domain>/values/GetOne/1
        // [HttpGet("GetOne/{index}")]

        // <domain>/values/1
        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            return list[index];
        }

        [HttpPost]
        public List<string> Post(string value)
        {
            list.Add(value);
            return list;
        }

        // [HttpPut()]
        // <domain>/values?index=1&value=ankara

        // [HttpPut("{index}")]
        // <domain>/values/1?value=ankara

        // <domain>/values/1/ankara
        [HttpPut("{index}/{value}")]
        public List<string> Put(int index, string value)
        {
            list[index] = value;
            return list;
        }

        [HttpDelete("{index}")]
        public List<string> Delete(int index)
        {
            list.RemoveAt(index);
            return list;
        }
    }
}

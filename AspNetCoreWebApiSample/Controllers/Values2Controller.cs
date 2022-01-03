using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApiSample.Controllers
{
    // attribute-based routing

    [Route("api/[controller]")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        private static List<string> list = new List<string>() { "mardin", "kayseri", "zonguldak", "denizli" };

        // <domain>/values2/list
        [HttpGet("list")]
        public List<string> Get()
        {
            return list;
        }

        // <domain>/values2/get/1
        [HttpGet("get/{index:int}")]
        public string GetByIndex(int index)
        {
            return list[index];
        }

        // <domain>/values2/get/ankara
        [HttpGet("get/{value:alpha}")]
        public string GetByValue(string value)
        {
            return list.Find(x => x.ToLower() == value.ToLower());
        }

        // <domain>/values2/create?value=ankara
        [HttpPost("create")]
        public List<string> Post([FromBody] string value)
        {
            list.Add(value);
            return list;
        }

        // <domain>/values2/update/1/ankara
        [HttpPut("update/{index}")]
        public List<string> Put([FromRoute] int index, [FromBody] string value)
        {
            list[index] = value;
            return list;
        }

        // <domain>/values2/update/ankara
        [HttpPut("update")]
        public List<string> Put([FromBody] string value)
        {
            for (int i = 0; i < list.Count; ++i)
                list[i] = value;

            return list;
        }

        // <domain>/values2/remove/1
        [HttpDelete("remove/{index}")]
        public List<string> Delete(int index)
        {
            list.RemoveAt(index);
            return list;
        }

        // <domain>/values2/remove
        [HttpDelete("remove")]
        public List<string> Delete()
        {
            list.Clear();
            return list;
        }
    }
}

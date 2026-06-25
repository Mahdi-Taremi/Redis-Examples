using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
using System.Text;

namespace Redis_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        [HttpPost("{Key},{Value}")]
        public ActionResult PostRedis(string Key, string Value)
        {
            using (var connection = new RedisClient())
            {
                connection.Set(Key, Value);
            }
            return Ok();
        }

        [HttpGet("{Key}")]
        public ActionResult GetRedis(string Key)
        {
            using (var connection = new RedisClient())
            {
                var result = ASCIIEncoding.ASCII.GetString(connection.Get(Key));
                return Ok(result);
            }
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

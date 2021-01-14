using Debug.Read.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Debug.Read.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        HttpClient client = new HttpClient();

        public ReadController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dbResponse = await client.GetAsync("http://debug.database/database/db");
            var dbResponseAsString = await dbResponse.Content.ReadAsStringAsync();
            List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(dbResponseAsString);
            if (dbResponse.IsSuccessStatusCode)
            {
                return Ok(messages);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

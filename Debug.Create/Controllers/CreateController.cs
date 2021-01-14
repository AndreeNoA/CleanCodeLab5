using Debug.Create.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Debug.Create.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CreateController : ControllerBase
    {    
        public RestClient RestClient = new RestClient("http://debug.database/database/db");
        public CreateController()
        {
           
        }
    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Message newMessage)
        {
            var restRequest = new RestRequest("/create", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(newMessage);
            var executeResponse = RestClient.Execute(restRequest);
            if (executeResponse.IsSuccessful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

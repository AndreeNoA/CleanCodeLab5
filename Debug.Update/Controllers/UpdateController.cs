using Debug.Update.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Debug.Update.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateController : ControllerBase
    {
        public RestClient RestClient = new RestClient("http://debug.database/database/db");
        public UpdateController()
        {

        }

        [HttpPut]
        public async Task<IActionResult> GetAll([FromBody]Message message)
        {
            var restRequest = new RestRequest("/update", Method.PUT);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(message);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromBody]Guid id)
        {
            var restRequest = new RestRequest("/delete", Method.DELETE);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddQueryParameter("id", id.ToString());
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

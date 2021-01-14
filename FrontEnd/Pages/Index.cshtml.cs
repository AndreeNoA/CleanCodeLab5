using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Message> Messages { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://debug.read/Read");
                var response = await client.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<Message>>(responseAsString);
            }
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            RestClient restClient = new RestClient("http://debug.update/update");
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(id);
            var response = restClient.Execute(restRequest);
            if (response.IsSuccessful)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

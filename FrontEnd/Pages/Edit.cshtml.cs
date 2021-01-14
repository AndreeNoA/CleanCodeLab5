using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace FrontEnd.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Message Message { get; set; }
        [BindProperty]
        public Guid PickedId { get; set; }
        public RestClient RestClient = new RestClient("http://debug.update/update");

        public async Task<IActionResult> OnPostAsync()
        {
            var message = new Message()
            {
                Id = PickedId,
                Text = Message.Text
            };
            var restRequest = new RestRequest(Method.PUT);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(message);
            var executeResponse = RestClient.Execute(restRequest);
            if (executeResponse.IsSuccessful)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return BadRequest();
            }
        }
        public void OnGet(Guid id)
        {
            this.PickedId = id;
        }
    }
}

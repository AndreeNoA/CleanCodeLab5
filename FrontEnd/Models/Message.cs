using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Pages
{
    public partial class Message
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
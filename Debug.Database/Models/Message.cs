using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debug.Database.Models
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

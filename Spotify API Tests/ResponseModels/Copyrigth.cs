using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class Copyrigth
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

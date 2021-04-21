using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class ExternalId
    {
        [JsonProperty("ean")]
        public string Ean { get; set; }
        [JsonProperty("isrc")]
        public string Isrc { get; set; }
        [JsonProperty("upc")]
        public string Upc { get; set; }
    }
}

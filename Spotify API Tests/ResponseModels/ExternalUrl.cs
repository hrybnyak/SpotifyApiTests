using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class ExternalUrl
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}

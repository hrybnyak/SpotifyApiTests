using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class AlbumRestrictions
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

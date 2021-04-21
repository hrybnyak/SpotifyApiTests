using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class ReletedArtistsResponse
    {
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
    }
}

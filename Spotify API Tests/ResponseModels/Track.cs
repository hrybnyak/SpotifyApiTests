using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class Track
    {
        [JsonProperty("album")]
        public Album Album { get; set; }
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }
        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }
        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }
        [JsonProperty("explicit")]
        public bool Explicit { get; set; }
        [JsonProperty("external_ids")]
        public ExternalId ExternalIds { get; set; }
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }
        [JsonProperty("is_playable")]
        public bool IsPlayable { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }
        [JsonProperty("restrictions")]
        public TrackRestriction Restrictions { get; set; }
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}

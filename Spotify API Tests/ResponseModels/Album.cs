using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify_API_Tests.ResponseModels
{
    public class Album
    {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }
        [JsonProperty("copyrights")]
        public List<Copyrigth> Copyrigths { get; set; }
        [JsonProperty("external_ids")]
        public ExternalId ExternalIds { get; set; }
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }
        [JsonProperty("restrictions")]
        public AlbumRestrictions Restrictions { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("tracks")]
        public List<Track> Tracks { get; set; }

    }
}

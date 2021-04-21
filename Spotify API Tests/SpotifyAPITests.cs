using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using Spotify_API_Tests.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_API_Tests
{
    public class SpotifyAPITests
    {
        private readonly RestClient _client = new RestClient("https://api.spotify.com/v1");
        private const string AuthCredentials = "Basic ZTRhMGNlYmViZDZlNGRlODkzZTNkOTk1ZTgxYzMxYzc6MzY3ZWE0MjI2Yzk3NGMyYjg2NjQ1MzVmMWMzNjNjNzc=";
        private string AuthToken = string.Empty;
        private DateTime ExpiresOn;

        public SpotifyAPITests()
        {
            Authorize();
        }
        private async Task Authorize()
        {
            var url = "https://accounts.spotify.com/api/token";
            var data = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials"}
            };
            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(data))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    httpClient.DefaultRequestHeaders.Add("Authorization", AuthCredentials);

                    var current = DateTime.Now;
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    var result = await response.Content.ReadAsStringAsync();
                    var auth = JsonConvert.DeserializeObject<AuthorizationResponse>(result);
                    AuthToken = auth.TokenType + " " + auth.AccessToken;
                    ExpiresOn = current.AddSeconds(auth.ExpiresIn);
                }
            }

        }

        [SetUp]
        public void SetUp()
        {
            if (ExpiresOn <= DateTime.Now)
            {
                Authorize().GetAwaiter().GetResult();
            }
        }

        [Test]
        public void GetTrack_TrackIdExists_ReturnsSuccessfulStatusCode()
        {
            //Arrange
            var request = new RestRequest("/tracks/2Fxmhks0bxGSBdJ92vM42m", Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", AuthToken);

            //Act
            var result = _client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<Track>(result.Content);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(deserialized.Name, Is.EqualTo("bad guy"));
            Assert.That(deserialized.Artists[0].Name, Is.EqualTo("Billie Eilish"));
        }

        [Test]
        public void GetTrack_TrackIdDoesntExists_Returns404StatusCode()
        {
            //Arrange
            var request = new RestRequest("/tracks/2Fxm9ks0bxGSB5J92vM42m", Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", AuthToken);

            //Act
            var result = _client.Execute(request);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void GetArtist_ArtistIdExists_ReturnsSuccessfulStatusCode()
        {
            //Arrange
            var request = new RestRequest("/artists/6qqNVTkY8uBg9cP3Jd7DAH", Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", AuthToken);

            //Act
            var result = _client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<Artist>(result.Content);

            //Assert
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.AreEqual(deserialized.Name, "Billie Eilish");
            Assert.AreEqual(2, deserialized.Genres.Count);
            Assert.Contains("pop", deserialized.Genres);
        }

        [Test]
        public void GetArtistRelatedArtists_ArtistIdExists_ReturnsSuccessfulStatusCode()
        {
            //Arrange
            var request = new RestRequest("/artists/6qqNVTkY8uBg9cP3Jd7DAH/related-artists", Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", AuthToken);

            //Act
            var result = _client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<ReletedArtistsResponse>(result.Content);

            //Assert
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.AreEqual(20, deserialized.Artists.Count);
        }

    }
}
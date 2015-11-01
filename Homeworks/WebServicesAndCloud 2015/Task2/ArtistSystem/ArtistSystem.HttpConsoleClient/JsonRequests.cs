namespace ArtistSystem.HttpConsoleClient
{
    using WebApi.Models;
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    public class JsonRequests
    {

        internal async static void ExecuteDeleteRequests(HttpClient client)
        {
            ResponseSongModel deleteSong = new ResponseSongModel
            {
                Id = 32
            };

            string songToDelete = JsonConvert.SerializeObject(deleteSong);

            var requeset = new HttpRequestMessage(HttpMethod.Delete, "api/songs");
            requeset.Content = new StringContent(songToDelete, Encoding.Unicode, "application/json");

            var response = await client.SendAsync(requeset, HttpCompletionOption.ResponseContentRead);

            Console.WriteLine(response.ReasonPhrase);
            //// DO i need to make same operation for other objects. It's same;
        }

        internal static void ExecutePutRequests(HttpClient client)
        {
            ResponseAlbumModel updateAlbum = new ResponseAlbumModel
            {
                Id = 15,
                Title = "Updated object",
                ProducerName = "Assert.AreEqual(this.StatusCode, StatusCode.Updated)",
                Year = 2009
            };

            ResponseSongModel updateSong = new ResponseSongModel
            {
                Id = 32,
                Title = "Updateed song",
                Genre = "Genre updated",
                Year = 2000,
                AlbumId = 4,
                ArtistId = 25
            };

            ResponseArtistModel updateArtist = new ResponseArtistModel
            {
                Id = 27,
                Name = "Updated artist name",
                Country = "Country Updated",
                DataOfBirth = new DateTime(1999, 2, 4)
            };

            var messages = new List<HttpResponseMessage>
            {
                client.PutAsJsonAsync("api/albums", updateAlbum).Result,
                client.PutAsJsonAsync("api/songs", updateSong).Result,
                client.PutAsJsonAsync("api/artists", updateArtist).Result
            };

            foreach (var msg in messages)
            {
                Console.WriteLine(msg.ReasonPhrase.ToString());
            }
        }

        internal async static void ExecutePostRequests(HttpClient client)
        {
            ResponseAlbumModel testAlbum = new ResponseAlbumModel
            {
                Title = "Za posleden put fo smeniqm",
                ProducerName = "Common Productions",
                Year = 2009
            };

            ResponseSongModel song = new ResponseSongModel
            {
                Title = "EE chovek omruzna mi",
                Genre = "Bate i na mene spoko",
                Year = 2015,
                AlbumId = 4,
                ArtistId = 24
            };

            ResponseArtistModel artist = new ResponseArtistModel
            {
                Name = "Kaenko Ukolovich",
                Country = "Ukraine",
                DataOfBirth = new DateTime(1999, 2, 4)
            };

            var httpResponseAlbum = await client.PostAsJsonAsync("api/albums", testAlbum);
            var httpResponseSong = await client.PostAsJsonAsync("api/songs", song);
            var httpResponseArtist = await client.PostAsJsonAsync("api/artists", artist);

            Console.WriteLine(httpResponseAlbum.ReasonPhrase.ToString() + " from albums");
            Console.WriteLine(httpResponseSong.ReasonPhrase.ToString() + " from songs");
            Console.WriteLine(httpResponseArtist.ReasonPhrase.ToString() + " from artists");
        }

        internal static void PrintResults(IEnumerable<BaseResponseModel> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(new string('*', 20));
            }
        }

        internal static void ExecuteGetRequests(HttpClient client)
        {
            //// This is not good. Beacuse must check status of response it can be some error. other: possible Liskov Of Sbstitution violance
            var responses = new List<IEnumerable<BaseResponseModel>>
            {
                client.GetAsync("api/songs").Result.Content.ReadAsAsync<IEnumerable<ResponseSongModel>>().Result,
                client.GetAsync("api/artists").Result.Content.ReadAsAsync<IEnumerable<ResponseArtistModel>>().Result,
                client.GetAsync("api/albums").Result.Content.ReadAsAsync<IEnumerable<ResponseAlbumModel>>().Result
            };

            responses.ToList().ForEach(x => PrintResults(x));
        }
    }
}

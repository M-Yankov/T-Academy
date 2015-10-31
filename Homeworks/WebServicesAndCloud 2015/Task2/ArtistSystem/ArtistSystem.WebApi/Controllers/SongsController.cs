namespace ArtistSystem.WebApi.Controllers
{
    using ArtistSystem.Data;
    using ArtistSystem.WebApi.Models;
    using System.Web.Http;
    using System.Linq;
    using ArtistsSystem.Models;
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text;

    public class SongsController : ApiController
    {
        private IArtistSystemData data;

        public SongsController(IArtistSystemData data)
        {
            this.data = data;
        }

        public SongsController()
            :this(new ArtistSystemData(new ArtistSystemContext()))
        {
        }

        public IHttpActionResult Get()
        {
            var songs = this.data.Songs.All()
                .Select(song => new ResponseSongModel
                {
                    Id = song.Id,
                    Genre = song.Genre,
                    Title = song.Title,
                    Year = song.Year,
                    AlbumId = song.AlbumId,
                    ArtistId = song.ArtistId
                })
                .ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Post(ResponseSongModel song)
        {
            if (this.ModelState.IsValid)
            {
                var artitst = data.Artists.GetById(song.ArtistId);
                var album = data.Albums.GetById(song.AlbumId);

                if (album != null && artitst != null)
                {
                    this.data.Songs.Add(
                        new Song
                        {
                            Title = song.Title,
                            Year = song.Year,
                            Genre = song.Genre,
                            AlbumId = album.Id,
                            ArtistId = artitst.Id
                        });

                    int rowsChanged = this.data.SaveChanges();

                    return this.Ok($"Rows affected ({rowsChanged})");
                }
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(ResponseSongModel song)
        {
            if (this.ModelState.IsValid)
            {
                var theSong = data.Songs.GetById(song.Id);
                if (theSong == null)
                {
                    return this.BadRequest("Id not found!");
                }

                theSong.Title = song.Title;
                theSong.Year = song.Year;
                theSong.Genre = song.Genre;
                theSong.ArtistId = song.ArtistId;
                theSong.AlbumId = song.AlbumId;

                data.Songs.Update(theSong);

                int rowsChanged = this.data.SaveChanges();
                return this.Ok($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest(this.ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]ResponseSongModel song)
        {
            if (this.data.Songs.All().Any(s => s.Id == s.Id))
            {
                this.data.Songs.Delete(song.Id);

                int rowsChanged = this.data.SaveChanges();
                return this.Ok($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest("Id does'not exits!");
        }
    }
}
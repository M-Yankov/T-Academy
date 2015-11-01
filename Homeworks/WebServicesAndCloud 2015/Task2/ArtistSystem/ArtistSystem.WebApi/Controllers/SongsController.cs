namespace ArtistSystem.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using ArtistSystem.Data;
    using ArtistSystem.WebApi.Models;
    using ArtistsSystem.Models;
    using AutoMapper;

    public class SongsController : ApiController
    {
        private readonly IArtistSystemData data;

        public SongsController(IArtistSystemData data)
        {
            this.data = data;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            List<ResponseSongModel> songs = this.data
                .Songs
                .All()
                .ProjectTo<ResponseSongModel>()
                .ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Post(ResponseSongModel song)
        {
            if (this.ModelState.IsValid)
            {
                Artist artitst = data.Artists.GetById(song.ArtistId);
                Album album = data.Albums.GetById(song.AlbumId);

                if (album != null && artitst != null)
                {
                    this.data.Songs.Add(Mapper.Map<Song>(song));
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
                Song theSongToUpdate = data.Songs.GetById(song.Id);
                if (this.data.Songs.GetById(song.Id) == null)
                {
                    return this.BadRequest($"Song with this id not found! Actual: {song.Id}");
                }

                Mapper.DynamicMap(song, theSongToUpdate);
                this.data.Songs.Update(theSongToUpdate);

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

            return this.BadRequest("Id does not exits!");
        }
    }
}
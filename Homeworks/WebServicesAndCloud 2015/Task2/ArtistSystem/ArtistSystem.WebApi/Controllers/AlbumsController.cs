namespace ArtistSystem.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using AutoMapper;

    public class AlbumsController : ApiController
    {
        private readonly IArtistSystemData data;

        public AlbumsController(IArtistSystemData dataContex)
        {
            data = dataContex;
        }

        public IHttpActionResult Get()
        {
            List<ResponseAlbumModel> result = this.data
                .Albums
                .All()
                .ProjectTo<ResponseAlbumModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(ResponseAlbumModel album)
        {
            if (this.ModelState.IsValid)
            {
                //// TODO: Add class model for saving objects. 
                Album albumToAdd = Mapper.Map<Album>(album);
                //// this is ridiculous ↓
                albumToAdd.Producer = album.ProducerName; 

                this.data.Albums.Add(albumToAdd);
                int rowsChanged = this.data.SaveChanges();

                return this.Ok($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(ResponseAlbumModel album)
        {
            if (this.ModelState.IsValid)
            {
                Album albumToUpdate = this.data.Albums.GetById(album.Id);
                if (albumToUpdate == null)
                {
                    return this.BadRequest($"No such album with this id: {album.Id}");
                }

                Mapper.DynamicMap(album, albumToUpdate);
                this.data.Albums.Update(albumToUpdate);

                int rowsChanged = this.data.SaveChanges();
                return this.Ok($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Delete(ResponseAlbumModel album)
        {
            if (this.data.Albums.All().Any(al => al.Id == album.Id))
            {
                this.data.Albums.Delete(album.Id);

                int rowsChanged = this.data.SaveChanges();
                return this.Ok($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest("Album not found!");
        }
    }
}
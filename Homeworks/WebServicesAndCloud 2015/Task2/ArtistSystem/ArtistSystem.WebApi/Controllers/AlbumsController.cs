namespace ArtistSystem.WebApi.Controllers
{
    using Models;
    using Data;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;

    public class AlbumsController : ApiController
    {
        private readonly IArtistSystemData data;

        public AlbumsController(IArtistSystemData dataContex)
        {
            data = dataContex;
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Albums.All().Select(al => new ResponseAlbumModel
            {
                Id = al.Id,
                Title = al.Title,
                Year = al.Year,
                ProducerName = al.Producer
            }).ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(ResponseAlbumModel album)
        {
            if (this.ModelState.IsValid)
            {
                this.data.Albums.Add(
                    new Album
                    {
                        Title = album.Title,
                        Producer = album.ProducerName,
                        Year = album.Year
                        //// AutoMapper!
                    });

                int rowsChanged = this.data.SaveChanges();
                return this.Ok<string>($"Rows affected ({rowsChanged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(ResponseAlbumModel album)
        {
            if (this.ModelState.IsValid)
            {
                var albumToUpdate = this.data.Albums.GetById(album.Id);
                if (albumToUpdate == null)
                {
                    return this.BadRequest($"No such album with this id: {album.Id}");
                }

                albumToUpdate.Producer = album.ProducerName;
                albumToUpdate.Title = album.Title;
                albumToUpdate.Year = album.Year;

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
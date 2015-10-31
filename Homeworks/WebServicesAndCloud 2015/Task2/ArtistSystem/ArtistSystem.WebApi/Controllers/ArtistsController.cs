namespace ArtistSystem.WebApi.Controllers
{
    using Models;
    using Data;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;

    public class ArtistsController : ApiController
    {
        private IArtistSystemData data;

        public ArtistsController(IArtistSystemData dataContext)
        {
            this.data = dataContext;
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Artists.All().Select(a => new ResponseArtistModel
            {
                Id = a.Id,
                Name = a.Name,
                Country = a.Country,
                DateOfBirth = a.DataOfBirth
            }).ToList();

            return this.Ok(artists);
        }

        public IHttpActionResult Post(ResponseArtistModel artist)
        {
            if (this.ModelState.IsValid)
            {
                this.data.Artists.Add(new Artist
                {
                    Country = artist.Country,
                    Name = artist.Name,
                    DataOfBirth = artist.DateOfBirth
                });

                int rowsChnaged = this.data.SaveChanges();
                return this.Ok($"Rows changed ({rowsChnaged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(ResponseArtistModel artist)
        {
            if (this.ModelState.IsValid)
            {
                var artistToUpdate = this.data.Artists.GetById(artist.Id);

                if (artistToUpdate == null)
                {
                    return this.BadRequest("Artist Not found!");
                }

                artistToUpdate.Country = artist.Country;
                artistToUpdate.Name = artist.Name;
                artistToUpdate.DataOfBirth = artist.DateOfBirth;

                this.data.Artists.Update(artistToUpdate);

                int rowsChnaged = this.data.SaveChanges();
                return this.Ok($"Rows changed ({rowsChnaged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Delete(ResponseArtistModel artist)
        {
            if (this.data.Artists.All().Any(x => x.Id == artist.Id))
            {
                this.data.Artists.Delete(artist.Id);

                int rowsChnaged = this.data.SaveChanges();
                return this.Ok($"Rows changed ({rowsChnaged})");
            }

            return this.BadRequest($"Id of artist not found! Actual: {artist.Id}");
        }
    }
}
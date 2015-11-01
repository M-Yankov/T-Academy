namespace ArtistSystem.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class ArtistsController : ApiController
    {
        private readonly IArtistSystemData data;

        public ArtistsController(IArtistSystemData dataContext)
        {
            this.data = dataContext;
        }

        public IHttpActionResult Get()
        {
            List<ResponseArtistModel> artists = this.data
                .Artists
                .All()
                .ProjectTo<ResponseArtistModel>()
                .ToList();

            return this.Ok(artists);
        }

        public IHttpActionResult Post(ResponseArtistModel artist)
        {
            if (this.ModelState.IsValid)
            {
                Artist artistToAdd = Mapper.Map<Artist>(artist);
                this.data.Artists.Add(artistToAdd);

                int rowsChnaged = this.data.SaveChanges();
                return this.Ok($"Rows changed ({rowsChnaged})");
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(ResponseArtistModel artist)
        {
            if (this.ModelState.IsValid)
            {
                Artist artistToUpdate = this.data.Artists.GetById(artist.Id);
                if (artistToUpdate == null)
                {
                    return this.BadRequest("Artist Not found!");
                }

                //// Why need this? Because Mapper.Map<T>(obj) returns a new object with the new properties. I can Update 
                //// this object - it's not from the database. So I use this Method just to transfer values from properties
                Mapper.DynamicMap(artist, artistToUpdate);
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
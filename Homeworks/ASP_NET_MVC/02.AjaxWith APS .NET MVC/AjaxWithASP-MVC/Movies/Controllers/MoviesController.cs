namespace Movies.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Mvc;

    using Movies.Data;
    using Movies.Models;

    public class MoviesController : Controller
    {
        private IDbSet<Movie> dbSet { get; set; }

        private MoviesDbContext data { get; set; }

        public MoviesController()
        {
            this.data = new MoviesDbContext();
            this.dbSet = this.data.Set<Movie>();
        }

        // GET: Movies
        public ActionResult All()
        {
            IList<MovieViewModel> movies = this
                .data
                .Movies
                .Select(MovieViewModel.ToViewModel)
                .ToList();

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView(movies);
            }

            return this.View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movieDetails = this
                .data
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (movieDetails == null)
            {
                return this.PartialView("NotFound");
            }

            MovieViewModel movieDetailsView = MovieViewModel.MapToView(movieDetails);

            return this.PartialView(movieDetailsView);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            if (!this.Request.IsAjaxRequest())
            {
                return this.Content("This route accepts only Ajax requests!");
            }

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(MovieCreateModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }

            Movie saveModel = new Movie();
            movieModel.TransferValuesTo(saveModel);
            this.data.Movies.Add(saveModel);
            this.data.SaveChanges();

            MovieViewModel viewModel = MovieViewModel.MapToView(saveModel);
            return this.PartialView("Details", viewModel);
            //return RedirectToAction("Details", new { id = saveModel.Id });
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            Movie model =
                this
                .data
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return this.PartialView("NotFound");
            }
            
            MovieCreateModel editModel = MovieCreateModel.MapToCreateModel(model);

            return this.PartialView("Edit" ,editModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieCreateModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(movieModel);
            }

            Movie modelToSave = this.data.Movies.Find(id);
            movieModel.TransferValuesTo(modelToSave);

            var entry = this.data.Entry(modelToSave);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(modelToSave);
            }

            entry.State = EntityState.Modified;
            this.data.SaveChanges();
            
            MovieViewModel viewmodel = MovieViewModel.MapToView(modelToSave);
            return this.PartialView("Details", viewmodel);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Movie movieToDelete = this.data.Movies.First(m => m.Id == id);
            if (movieToDelete == null)
            {
                return this.PartialView("NotFound");
            }

            DbEntityEntry<Movie> entry = this.data.Entry(movieToDelete);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.data.Movies.Attach(movieToDelete);
                this.data.Movies.Remove(movieToDelete);
            }

            this.data.SaveChanges();

            return new EmptyResult();
        }
    }
}

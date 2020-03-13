using System.Web.Http;

using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Movie;
using CinemaAPI.Models.Input.Movie;

namespace CinemaAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieRepository movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            this.movieRepo = movieRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(MovieCreationModel model)
        {
            IMovie movie = movieRepo.GetByNameAndDuration(model.Name, model.DurationMinutes);

            if (movie == null)
            {
                movieRepo.Insert(new Movie(model.Name, model.DurationMinutes));

                return Ok();
            }

            return BadRequest("Movie already exists");
        }
    }
}
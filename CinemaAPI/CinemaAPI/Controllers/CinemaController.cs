using System.Web.Http;

using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Cinema;
using CinemaAPI.Models.Input.Cinema;

namespace CinemaAPI.Controllers
{
    public class CinemaController : ApiController
    {
        private readonly ICinemaRepository cinemaRepo;

        public CinemaController(ICinemaRepository cinemaRepo)
        {
            this.cinemaRepo = cinemaRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(CinemaCreationModel model)
        {
            ICinema cinema = cinemaRepo.GetByNameAndAddress(model.Name, model.Address);

            if (cinema == null)
            {
                cinemaRepo.Insert(new Cinema(model.Name, model.Address));

                return Ok();
            }

            return BadRequest("Cinema already exists");
        }
    }
}
using System;
using System.Web.Http;

using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models;
using CinemaAPI.Models.Input.Projection;
using CinemaAPI.Models.Contracts.Projection;
using CinemaAPI.Data;

namespace CinemaAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionRepository projectionsRepo;

        public ProjectionController(INewProjection newProj, IProjectionRepository projectionsRepo)
        {
            this.newProj = newProj;
            this.projectionsRepo = projectionsRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [Route("api/projection/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetAvailableSeatsCount(int id)
        {
            IProjection projection = projectionsRepo.GetById(id);

            if (projection == null)
            {
                return BadRequest("Could not find this projection!");
            }

            if (projection.StartDate <= DateTime.UtcNow)
            {
                return BadRequest("Cannot get seats information for started or finished projections!");
            }

            if (projection.AvailableSeatsCount == 0)
            {
                return BadRequest("Available seats for this projection are exhausted!");
            }

            return Ok($"Available seats count: {projection.AvailableSeatsCount}");
        }
    }
}
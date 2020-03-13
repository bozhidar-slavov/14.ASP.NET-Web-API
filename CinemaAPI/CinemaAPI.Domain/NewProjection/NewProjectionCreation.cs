using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Domain
{
    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;

        public NewProjectionCreation(IProjectionRepository projectionsRepo)
        {
            this.projectionsRepo = projectionsRepo;
        }

        public NewProjectionSummary New(IProjectionCreation projection)
        {
            if (projection.AvailableSeatsCount < 0)
            {
                return new NewProjectionSummary(false, "Available seats count must be non-negative number!");
            }

            projectionsRepo.Insert(new Projection(projection.MovieId, projection.RoomId, projection.StartDate, projection.AvailableSeatsCount));

            return new NewProjectionSummary(true);
        }
    }
}
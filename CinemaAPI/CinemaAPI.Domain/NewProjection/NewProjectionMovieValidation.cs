using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Movie;
using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Domain.NewProjection
{
    public class NewProjectionMovieValidation : INewProjection
    {
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionMovieValidation(IMovieRepository movieRepo, INewProjection newProj)
        {
            this.movieRepo = movieRepo;
            this.newProj = newProj;
        }

        public NewProjectionSummary New(IProjectionCreation projection)
        {
            IMovie movie = movieRepo.GetById(projection.MovieId);

            if (movie == null)
            {
                return new NewProjectionSummary(false, $"Movie with id {projection.MovieId} does not exist");
            }

            return newProj.New(projection);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Movie;
using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Domain.NewProjection
{
    public class NewProjectionPreviousOverlapValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionPreviousOverlapValidation(IProjectionRepository projectRepo, IMovieRepository movieRepo, INewProjection proj)
        {
            this.projectRepo = projectRepo;
            this.movieRepo = movieRepo;
            this.newProj = proj;
        }

        public NewProjectionSummary New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = projectRepo.GetActiveProjections(proj.RoomId);

            IProjection previousProjection = movieProjectionsInRoom.Where(x => x.StartDate < proj.StartDate)
                                                                        .OrderByDescending(x => x.StartDate)
                                                                        .FirstOrDefault();

            if (previousProjection != null)
            {
                IMovie previousProjectionMovie = movieRepo.GetById(previousProjection.MovieId);

                DateTime previousProjectionEnd = previousProjection.StartDate.AddMinutes(previousProjectionMovie.DurationMinutes);

                if (previousProjectionEnd >= proj.StartDate)
                {
                    return new NewProjectionSummary(false, $"Projection overlaps with previous one: {previousProjectionMovie.Name} at {previousProjection.StartDate}");
                }
            }

            return newProj.New(proj);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;

using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Movie;
using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Domain.NewProjection
{
    public class NewProjectionNextOverlapValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionNextOverlapValidation(IProjectionRepository projectRepo, IMovieRepository movieRepo, INewProjection newProj)
        {
            this.projectRepo = projectRepo;
            this.movieRepo = movieRepo;
            this.newProj = newProj;
        }

        public NewProjectionSummary New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = projectRepo.GetActiveProjections(proj.RoomId);

            IProjection nextProjection = movieProjectionsInRoom.Where(x => x.StartDate > proj.StartDate)
                                                                       .OrderBy(x => x.StartDate)
                                                                       .FirstOrDefault();

            if (nextProjection != null)
            {
                IMovie curMovie = movieRepo.GetById(proj.MovieId);
                IMovie nextProjectionMovie = movieRepo.GetById(nextProjection.MovieId);

                DateTime curProjectionEndTime = proj.StartDate.AddMinutes(curMovie.DurationMinutes);

                if (curProjectionEndTime >= nextProjection.StartDate)
                {
                    return new NewProjectionSummary(false, $"Projection overlaps with next one: {nextProjectionMovie.Name} at {nextProjection.StartDate}");
                }
            }

            return newProj.New(proj);
        }
    }
}
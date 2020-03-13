using System;

using CinemaAPI.Data;
using CinemaAPI.Models.Contracts.Movie;
using CinemaAPI.Models.Contracts.Projection;
using CinemaAPI.Models.Contracts.Ticket;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Domain.Contracts;

namespace CinemaAPI.Domain.NewTicket
{
    public class NewTicketProjectionValidation : INewTicket
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly INewTicket newTicket;
        private readonly IMovieRepository movieRepo;


        public NewTicketProjectionValidation(IProjectionRepository projectionRepo, IMovieRepository movieRepo, INewTicket newTicket)
        {
            this.projectionRepo = projectionRepo;
            this.movieRepo = movieRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummаry New(ITicketRequest ticket)
        {
            IProjection projection = projectionRepo.GetById(ticket.ProjectionId);

            if (projection == null)
            {
                return new NewTicketSummаry(false, "The projection that u selected does not exist!");
            }

            IMovie movie = movieRepo.GetById(projection.MovieId);

            var currentDateTime = DateTime.UtcNow;
            var projectionEnd = projection.StartDate.AddMinutes(movie.DurationMinutes);

            if (projection.StartDate <= currentDateTime || projectionEnd <= currentDateTime)
            {
                return new NewTicketSummаry(false, "The projection that u selected has already started or ended!");
            }

            return newTicket.New(ticket);
        }
    }
}

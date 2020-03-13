using System.Collections.Generic;
using System.Linq;

using CinemaAPI.Data.EF;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Ticket;
using CinemaAPI.Models.DTOs;

namespace CinemaAPI.Data.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext db;

        public TicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ITicket> BoughtSeats(long id)
        {
            return db.Tickets.Where(t => t.ProjectionId == id)
                .SelectMany(x => new List<TicketDto>
                {
                    new TicketDto
                    {
                        Row = x.Row,
                        Column = x.Column
                    }
                });
        }

        public ITicket GetInfo(long id)
        {
            return db.Projections
                .Where(p => p.Id == id)
                .Select(s => new TicketDto
                {
                    ProjectionStartDate = s.StartDate,
                    MovieName = s.Movie.Name,
                    RoomNumber = s.Room.Number,
                    CinemaName = s.Room.Cinema.Name
                })
                .Single();
        }

        public ITicket Insert(ITicketCreation ticket)
        {
            Ticket newTicket = new Ticket(
                ticket.ProjectionId,
                ticket.UniqueNumberGuid,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNumber,
                ticket.Row,
                ticket.Column
                );
            db.Tickets.Add(newTicket);

            db.Projections
                .Where(p => p.Id == ticket.ProjectionId)
                .ToList()
                .ForEach(x => x.AvailableSeatsCount--);

            db.SaveChanges();

            return newTicket;
        }
    }
}
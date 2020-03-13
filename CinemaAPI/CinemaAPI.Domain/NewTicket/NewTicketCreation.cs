using System;

using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Ticket;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models.Ticket;

namespace CinemaAPI.Domain.NewTicket
{
    public class NewTicketCreation : INewTicket
    {
        private readonly ITicketRepository ticketRepo;

        public NewTicketCreation(ITicketRepository ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public NewTicketSummаry New(ITicketRequest ticketRequest)
        {
            string newUniqueNumber = Guid.NewGuid().ToString().GetHashCode().ToString("x");

            ITicket ticket = ticketRepo.GetInfo(ticketRequest.ProjectionId);

            ITicket newTicket = ticketRepo.Insert(new Ticket(
                ticketRequest.ProjectionId,
                newUniqueNumber,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNumber,
                ticketRequest.Row,
                ticketRequest.Column));

            ITicketSuccess ticketSuccess = new TicketModel(
                newUniqueNumber,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNumber,
                ticketRequest.Row,
                ticketRequest.Column
                );

            return new NewTicketSummаry(true, ticketSuccess);
        }
    }
}
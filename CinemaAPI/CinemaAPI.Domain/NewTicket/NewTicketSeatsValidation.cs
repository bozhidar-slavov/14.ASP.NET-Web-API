using System.Collections.Generic;

using CinemaAPI.Domain.Contracts;
using CinemaAPI.Data;
using CinemaAPI.Models.Contracts.Ticket;
using CinemaAPI.Models.Contracts.Reservation;
using CinemaAPI.Domain.Contracts.Models;

namespace CinemaAPI.Domain.NewTicket
{
    public class NewTicketSeatsValidation : INewTicket
    {
        private readonly ITicketRepository ticketRepo;
        private readonly IReservationRepository reservationRepo;
        private readonly INewTicket newTicket;

        public NewTicketSeatsValidation(ITicketRepository ticketRepo, IReservationRepository reservationRepo, INewTicket newTicket)
        {
            this.reservationRepo = reservationRepo;
            this.ticketRepo = ticketRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummаry New(ITicketRequest ticket)
        {
            if (ticket.UniqueNumberGuid == null)
            {
                IEnumerable<ITicket> seats = ticketRepo.BoughtSeats(ticket.ProjectionId);
                IEnumerable<IReservation> seatsWithReservation = reservationRepo.GetRowsAndColsById(ticket.ProjectionId);

                foreach (var seat in seats)
                {
                    if (ticket.Row == seat.Row && ticket.Column == seat.Column)
                    {
                        return new NewTicketSummаry(false, "This seat is already taken!");

                    }
                }

                foreach (var seat in seatsWithReservation)
                {
                    if (ticket.Row == seat.Row && ticket.Column == seat.Column)
                    {
                        return new NewTicketSummаry(false, "This seat is already reserved for another customer!");
                    }
                }
            }

            return newTicket.New(ticket);
        }
    }
}
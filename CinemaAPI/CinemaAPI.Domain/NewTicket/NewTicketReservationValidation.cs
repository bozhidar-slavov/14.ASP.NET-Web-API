using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Domain.Contracts.Models.Ticket;
using CinemaAPI.Models.Contracts.Reservation;
using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Domain.NewTicket
{
    public class NewTicketReservationValidation : INewTicket
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewTicket newTicket;

        public NewTicketReservationValidation(IReservationRepository reservationRepo, INewTicket newTicket)
        {
            this.reservationRepo = reservationRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummаry New(ITicketRequest ticket)
        {
            if (ticket.UniqueNumberGuid != null)
            {
                IReservation reservation = reservationRepo.GetReservationByUniqueNumber(ticket.UniqueNumberGuid);

                if (reservation == null)
                {
                    return new NewTicketSummаry(false, "The reservation that u want to access does not exist!");
                }

                if (reservation.IsActive == false)
                {
                    return new NewTicketSummаry(false, "This reservation is already used or canceled!");
                }

                return newTicket.New(new TicketWithReservationtModel(
                        reservation.ProjectionId,
                        reservation.Row,
                        reservation.Column
                    ));
            }

            return newTicket.New(ticket);
        }
    }
}
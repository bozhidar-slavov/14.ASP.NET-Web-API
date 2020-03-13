using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Domain.Contracts.Models
{
    public class NewReservationSummary
    {
        public NewReservationSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewReservationSummary(bool isCreated, IReservationTicket reservationTicket)
        {
            this.IsCreated = isCreated;
            this.ReservationTicket = reservationTicket;
        }

        public NewReservationSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public IReservationTicket ReservationTicket { get; }
    }
}

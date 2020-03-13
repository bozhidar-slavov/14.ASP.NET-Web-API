using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Reservation;
using CinemaAPI.Models.Contracts.Room;

namespace CinemaAPI.Domain.NewReservation
{
    public class NewReservationRoomValidation : INewReservation
    {
        private readonly INewReservation newReserv;
        private readonly IRoomRepository roomRepo;

        public NewReservationRoomValidation(INewReservation newReserv, IRoomRepository roomRepo)
        {
            this.newReserv = newReserv;
            this.roomRepo = roomRepo;
        }

        public NewReservationSummary New(IReservationRequest reservation)
        {
            IRoom room = roomRepo.GetRowsAndSeatsPerRow(reservation.ProjectionId);

            if (reservation.Row <= 0 || reservation.Column <= 0 || reservation.Row > room.Rows || reservation.Column > room.SeatsPerRow)
            {
                return new NewReservationSummary(false, "The seat that u selected does not exist!");
            }

            return newReserv.New(reservation);
        }
    }
}

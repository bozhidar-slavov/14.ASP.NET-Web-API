using System.Collections.Generic;

using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Domain.NewReservation
{
    public class NewReservationSeatsValidation : INewReservation
    {
        private readonly INewReservation newReservation;
        private readonly IReservationRepository reservationRepo;

        public NewReservationSeatsValidation(INewReservation newReservation, IReservationRepository reservationRepo)
        {
            this.newReservation = newReservation;
            this.reservationRepo = reservationRepo;
        }

        public NewReservationSummary New(IReservationRequest reservation)
        {
            IEnumerable<IReservation> reservationSeats = reservationRepo.GetRowsAndColsById(reservation.ProjectionId);

            foreach (var res in reservationSeats)
            {
                if (reservation.Row == res.Row && reservation.Column == res.Column)
                {
                    return new NewReservationSummary(false, "The seat that u choose for reservation is already reserved!");
                }
            }

            return newReservation.New(reservation);
        }
    }
}

using System;

using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Reservation;
using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Models.Input.Reservation;

namespace CinemaAPI.Domain.NewReservation
{
    public class NewReservationCreation : INewReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IRoomRepository roomRepo;
        private readonly IReservationRepository reservationRepo;

        public NewReservationCreation(IProjectionRepository projectionRepo, IRoomRepository roomRepo,
            IReservationRepository reservationRepo)
        {
            this.projectionRepo = projectionRepo;
            this.roomRepo = roomRepo;
            this.reservationRepo = reservationRepo;
        }

        public NewReservationSummary New(IReservationRequest reservationRequest)
        {
            string newUniqueNumber = Guid.NewGuid().ToString().GetHashCode().ToString("x");

            IReservation reservation = reservationRepo.GetInfo(reservationRequest.ProjectionId);

            bool isActive = true;

            IReservation newReservetion = reservationRepo.Insert(new Reservation(
                reservationRequest.ProjectionId,
                newUniqueNumber,
                reservation.ProjectionStartDate,
                reservation.MovieName,
                reservation.CinemaName,
                reservation.RoomNumber,
                reservationRequest.Row,
                reservationRequest.Column,
                isActive));

            IReservationTicket reservetionTicket = new ReservationTicketModel(
                newUniqueNumber,
                reservation.ProjectionStartDate,
                reservation.MovieName,
                reservation.CinemaName,
                reservation.RoomNumber,
                reservationRequest.Row,
                reservationRequest.Column
                );

            return new NewReservationSummary(true, reservetionTicket);
        }
    }
}

using System;

using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Projection;
using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Domain.NewReservation
{
    public class NewReservationProjectionValidation : INewReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly INewReservation newReservation;

        public NewReservationProjectionValidation(IProjectionRepository projectionRepo, INewReservation newReservation)
        {
            this.projectionRepo = projectionRepo;
            this.newReservation = newReservation;
        }

        public NewReservationSummary New(IReservationRequest reservation)
        {
            IProjection projection = projectionRepo.GetById(reservation.ProjectionId);

            var currentDateTime = DateTime.UtcNow;

            if (projection == null)
            {
                return new NewReservationSummary(false, $"Projection with id {reservation.ProjectionId} does not exist");
            }

            var tenMinutesBeforeStart = projection.StartDate.AddMinutes(-10);

            if (projection.StartDate <= currentDateTime || currentDateTime > tenMinutesBeforeStart)
            {
                return new NewReservationSummary(false,
                    "Reservation for projection that is already started or there is less then 10 minutes to start cannot be done.");
            }

            return newReservation.New(reservation);
        }
    }
}
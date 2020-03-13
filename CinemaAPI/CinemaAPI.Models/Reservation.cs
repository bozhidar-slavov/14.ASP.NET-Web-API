using System;

using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Models
{
    public class Reservation : IReservation, IReservationCreation, IReservationRequest
    {
        public Reservation()
        {
        }

        public Reservation(long projectionId, int row, int column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        public Reservation(long projectionId, string uniqueNumberGuid, DateTime projectionStartDate,
            string movieName, string cinemaName, int roomNumber, int row, int column, bool isActive)
        {
            this.ProjectionId = projectionId;
            this.UniqueNumberGuid = uniqueNumberGuid;
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNumber;
            this.Row = row;
            this.Column = column;
            this.IsActive = isActive;
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }

        public string UniqueNumberGuid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsActive { get; set; }
    }
}
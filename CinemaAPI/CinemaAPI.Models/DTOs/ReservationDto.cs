﻿using System;

using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Models.DTOs
{
    public class ReservationDto : IReservation
    {
        public ReservationDto()
        {
        }

        public ReservationDto(int row, int column)
        {
            this.Row = row;
            this.Column = column;
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

using System;

using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Models.Input.Reservation
{
    public class ReservationTicketModel : IReservationTicket
    {
        public ReservationTicketModel(string uniqueNumberGuid, DateTime projectionStartDate, string movieName, string cinemaName, int roomNum, int row, int column)
        {
            this.UniqueNumberGuid = uniqueNumberGuid;
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNum = roomNum;
            this.Row = row;
            this.Column = column;
        }

        public string UniqueNumberGuid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNum { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
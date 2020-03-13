using System;

using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Domain.Contracts.Models.Ticket
{
    public class TicketModel : ITicketSuccess
    {

        public TicketModel(string uniqueNumberGuid, DateTime projectionStartDate, string movieName, string cinemaName, int roomNumber, int row, int column)
        {
            this.UniqueNumberGuid = uniqueNumberGuid;
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNumber;
            this.Row = row;
            this.Column = column;
        }

        public string UniqueNumberGuid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
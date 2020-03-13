using System;

using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Models.DTOs
{
    public class TicketDto : ITicket
    {
        public TicketDto()
        {
        }

        public TicketDto(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public string UniqueNumberGuid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
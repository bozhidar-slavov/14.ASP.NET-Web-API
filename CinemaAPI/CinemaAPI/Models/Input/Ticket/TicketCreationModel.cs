using System;

namespace CinemaAPI.Models.Input.Ticket
{
    public class TicketCreationModel
    {
        public long ProjectionId { get; set; }

        public string UniqueNumber { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsActive { get; set; }
    }
}
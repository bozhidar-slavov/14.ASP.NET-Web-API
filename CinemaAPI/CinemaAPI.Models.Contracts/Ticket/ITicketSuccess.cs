using System;

namespace CinemaAPI.Models.Contracts.Ticket
{
    public interface ITicketSuccess
    {
        string UniqueNumberGuid { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        int RoomNumber { get; }

        int Row { get; }

        int Column { get; }
    }
}
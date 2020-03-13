using System;

namespace CinemaAPI.Models.Contracts.Reservation
{
    public interface IReservationTicket
    {
        string UniqueNumberGuid { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        int RoomNum { get; }

        int Row { get; }

        int Column { get; }
    }
}

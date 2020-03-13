using System;

namespace CinemaAPI.Models.Contracts.Reservation
{
    public interface IReservation
    {
        long Id { get; }

        long ProjectionId { get; }

        string UniqueNumberGuid { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        int RoomNumber { get; }

        int Row { get; }

        int Column { get; }

        bool IsActive { get; }
    }
}

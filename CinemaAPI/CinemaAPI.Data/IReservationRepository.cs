using System.Collections.Generic;

using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Data
{
    public interface IReservationRepository
    {
        IEnumerable<IReservation> GetRowsAndColsById(long id);

        IReservation GetInfo(long id);

        IReservation Insert(IReservationCreation reservation);

        IReservation GetReservationByUniqueNumber(string uniqueNumberGuid);
    }
}

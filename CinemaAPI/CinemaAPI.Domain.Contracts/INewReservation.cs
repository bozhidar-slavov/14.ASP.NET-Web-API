using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Reservation;

namespace CinemaAPI.Domain.Contracts
{
    public interface INewReservation
    {
        NewReservationSummary New(IReservationRequest reservation);
    }
}

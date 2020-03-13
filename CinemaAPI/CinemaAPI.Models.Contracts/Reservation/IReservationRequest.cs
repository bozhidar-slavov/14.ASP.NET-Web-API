namespace CinemaAPI.Models.Contracts.Reservation
{
    public interface IReservationRequest
    {
        string UniqueNumberGuid { get; }

        long ProjectionId { get; }

        int Row { get; }

        int Column { get; }
    }
}
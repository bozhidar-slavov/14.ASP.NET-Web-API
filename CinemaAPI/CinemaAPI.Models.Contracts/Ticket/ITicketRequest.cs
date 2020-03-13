namespace CinemaAPI.Models.Contracts.Ticket
{
    public interface ITicketRequest
    {
        long ProjectionId { get; }

        string UniqueNumberGuid { get; }

        int Row { get; }

        int Column { get; }
    }
}
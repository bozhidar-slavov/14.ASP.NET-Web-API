using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Domain.Contracts.Models.Ticket
{
    public class TicketWithReservationtModel : ITicketRequest
    {
        public TicketWithReservationtModel(long projectionId, int row, int column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        public long ProjectionId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public string UniqueNumberGuid { get; set; }
    }
}
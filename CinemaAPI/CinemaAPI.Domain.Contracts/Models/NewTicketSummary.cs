using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Domain.Contracts.Models
{
    public class NewTicketSummаry
    {
        public NewTicketSummаry(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewTicketSummаry(bool isCreated, ITicketSuccess ticket)
        {
            this.IsCreated = isCreated;
            this.Ticket = ticket;
        }


        public NewTicketSummаry(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public ITicketSuccess Ticket { get; }
    }
}
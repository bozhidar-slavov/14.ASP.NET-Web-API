using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Domain.Contracts
{
    public interface INewTicket
    {
        NewTicketSummаry New(ITicketRequest ticket);
    }
}
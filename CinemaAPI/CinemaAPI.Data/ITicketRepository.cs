using System.Collections.Generic;

using CinemaAPI.Models.Contracts.Ticket;

namespace CinemaAPI.Data
{
    public interface ITicketRepository
    {
        ITicket GetInfo(long id);

        ITicket Insert(ITicketCreation ticket);

        IEnumerable<ITicket> BoughtSeats(long id);
    }
}

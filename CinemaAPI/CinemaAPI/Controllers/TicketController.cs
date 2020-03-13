using System.Web.Http;

using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models;
using CinemaAPI.Models.Input.Ticket;

namespace CinemaAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly INewTicket newTicket;

        public TicketController(INewTicket newTicket)
        {
            this.newTicket = newTicket;
        }

        [HttpPost] // Without reservation
        public IHttpActionResult Index(TicketRequestModel model)
        {
            NewTicketSummаry summary = newTicket.New(new Ticket(
                model.ProjectionId,
                model.Row,
                model.Column
                ));

            if (summary.IsCreated)
            {
                return Ok(summary.Ticket);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult TicketWithReservation(TicketRequestModel model)
        {
            NewTicketSummаry summary = newTicket.New(new Ticket(
                model.ReservationGuid
                ));

            if (summary.IsCreated)
            {
                return Ok(summary.Ticket);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
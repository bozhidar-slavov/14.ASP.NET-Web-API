using System.Web.Http;

using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models;
using CinemaAPI.Models.Input.Reservation;

namespace CinemaAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReservation;

        public ReservationController(INewReservation newReserv)
        {
            this.newReservation = newReserv;
        }

        [HttpPost]
        public IHttpActionResult Index(ReservationRequestModel model)
        {
            NewReservationSummary summary = newReservation.New(new Reservation(
                model.ProjectionId,
                model.Row,
                model.Column
                ));

            if (summary.IsCreated)
            {
                return Ok(summary.ReservationTicket);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
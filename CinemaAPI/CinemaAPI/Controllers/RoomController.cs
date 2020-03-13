using System.Web.Http;

using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Room;
using CinemaAPI.Models.Input.Room;

namespace CinemaAPI.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomRepository roomRepo;

        public RoomController(IRoomRepository roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(RoomCreationModel model)
        {
            IRoom room = roomRepo.GetByCinemaAndNumber(model.CinemaId, model.Number);

            if (room == null)
            {
                roomRepo.Insert(new Room(model.Number, model.SeatsPerRow, model.Rows, model.CinemaId));

                return Ok();
            }

            return BadRequest("Room already exists");
        }
    }
}
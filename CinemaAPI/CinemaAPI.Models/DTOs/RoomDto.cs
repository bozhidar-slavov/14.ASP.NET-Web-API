using CinemaAPI.Models.Contracts.Room;

namespace CinemaAPI.Models.DTOs
{
    public class RoomDto : IRoom
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }
    }
}
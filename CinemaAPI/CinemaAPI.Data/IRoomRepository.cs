using CinemaAPI.Models.Contracts.Room;

namespace CinemaAPI.Data
{
    public interface IRoomRepository
    {
        IRoom GetRowsAndSeatsPerRow(long id);

        IRoom GetById(int id);

        IRoom GetByCinemaAndNumber(int cinemaId, int number);

        void Insert(IRoomCreation room);
    }
}
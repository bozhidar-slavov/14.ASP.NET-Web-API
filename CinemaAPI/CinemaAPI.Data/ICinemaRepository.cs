using CinemaAPI.Models.Contracts.Cinema;

namespace CinemaAPI.Data
{
    public interface ICinemaRepository
    {
        ICinema GetByNameAndAddress(string name, string address);

        void Insert(ICinemaCreation cinema);
    }
}
using System.Linq;

using CinemaAPI.Data.EF;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Cinema;

namespace CinemaAPI.Data.Implementation
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext db;

        public CinemaRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public ICinema GetByNameAndAddress(string name, string address)
        {
            return db.Cinemas.Where(x => x.Name == name &&
                                         x.Address == address)
                             .FirstOrDefault();
        }

        public void Insert(ICinemaCreation cinema)
        {
            Cinema newCinema = new Cinema(cinema.Name, cinema.Address);

            db.Cinemas.Add(newCinema);

            db.SaveChanges();
        }
    }
}
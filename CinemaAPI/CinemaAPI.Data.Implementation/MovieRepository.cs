using System.Linq;

using CinemaAPI.Data.EF;
using CinemaAPI.Models;
using CinemaAPI.Models.Contracts.Movie;

namespace CinemaAPI.Data.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IMovie GetById(int movieId)
        {
            return db.Movies.FirstOrDefault(x => x.Id == movieId);
        }

        public IMovie GetByNameAndDuration(string name, short duration)
        {
            return db.Movies.FirstOrDefault(x => x.Name == name &&
                                                 x.DurationMinutes == duration);
        }

        public void Insert(IMovieCreation movie)
        {
            Movie newMovie = new Movie(movie.Name, movie.DurationMinutes);

            db.Movies.Add(newMovie);
            db.SaveChanges();
        }
    }
}
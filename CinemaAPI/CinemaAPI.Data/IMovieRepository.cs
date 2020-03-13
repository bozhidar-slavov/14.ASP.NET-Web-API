using CinemaAPI.Models.Contracts.Movie;

namespace CinemaAPI.Data
{
    public interface IMovieRepository
    {
        IMovie GetById(int movieId);

        IMovie GetByNameAndDuration(string name, short duration);

        void Insert(IMovieCreation movie);
    }
}
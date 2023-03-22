using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int id);
        Movie GetMovie(string title);
        decimal GetMovieRating(int movieId);
        bool MovieExists(int movieId);
        bool CreateMovie(int directorId, int categoryId, Movie movie);
        bool UpdateMovie(int directorId, int categoryId, Movie movie);
        bool Save();
    }
}

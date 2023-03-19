using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
    }
}

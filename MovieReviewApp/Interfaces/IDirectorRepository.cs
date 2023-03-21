using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface IDirectorRepository
    {
        ICollection<Director> GetDirectors();
        Director GetDirector(int id);
        ICollection<Director> GetDirectorOfMovie(int movieId);
        ICollection<Movie> GetMoviesByDirector(int directorId);
        bool DirectorExists(int id);
    }
}

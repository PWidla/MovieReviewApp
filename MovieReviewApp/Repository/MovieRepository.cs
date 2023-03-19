using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public Movie GetMovie(string title)
        {
            return _context.Movies.Where(m => m.Title == title).FirstOrDefault();
        }

        public decimal GetMovieRating(int movieId)
        {
            var review = _context.Reviews.Where(m =>m.Movie.Id == movieId);
            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(m => m.Rating) / review.Count());
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Id).ToList();
        }

        public bool MovieExists(int movieId)
        {
            return (_context.Movies.Any(m => m.Id == movieId));
        }
    }
}

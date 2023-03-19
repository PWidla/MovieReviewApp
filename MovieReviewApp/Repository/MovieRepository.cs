using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class MovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Id).ToList();
        }
    }
}

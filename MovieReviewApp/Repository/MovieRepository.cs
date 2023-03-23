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

        public bool CreateMovie(int directorId, int categoryId, Movie movie)
        {
            var movieDirectorEntity = _context.Directors.Where(a => a.Id == directorId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var movieDirector = new MovieDirector()
            {
                Director = movieDirectorEntity,
                Movie = movie,
            };

            _context.Add(movieDirector);

            var movieCategory = new MovieCategory()
            {
                Category = category,
                Movie = movie,
            };

            _context.Add(movieCategory);

            _context.Add(movie);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMovie(int directorId, int categoryId, Movie movie)
        {
            // Get the existing MovieDirector and MovieCategory objects for the movie
            var movieDirector = movie.MovieDirectors.FirstOrDefault(md => md.DirectorId == directorId);
            var movieCategory = movie.MovieCategories.FirstOrDefault(mc => mc.CategoryId == categoryId);

            // Update the director and category IDs
            if (movieDirector != null)
            {
                movieDirector.DirectorId = directorId;
            }
            else
            {
                movieDirector = new MovieDirector { DirectorId = directorId, MovieId = movie.Id };
                movie.MovieDirectors.Add(movieDirector);
            }

            if (movieCategory != null)
            {
                movieCategory.CategoryId = categoryId;
            }
            else
            {
                movieCategory = new MovieCategory { CategoryId = categoryId, MovieId = movie.Id };
                movie.MovieCategories.Add(movieCategory);
            }

            _context.Update(movie);
            return Save();
        }
    }
}

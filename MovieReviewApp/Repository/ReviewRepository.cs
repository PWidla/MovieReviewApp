using AutoMapper;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public Review GetReview(int reviewId)
        {
            return _context.
        }

        public ICollection<Review> GetReviews()
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewsOfAMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly object _mapper;

        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewerExists(int reviewerId)
        {
            throw new NotImplementedException();
        }
    }
}

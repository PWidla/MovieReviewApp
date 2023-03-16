namespace MovieReviewApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieDirector> MovieDirectors { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}

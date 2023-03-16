namespace MovieReviewApp.Models
{
    public class MovieDirector
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }
    }
}

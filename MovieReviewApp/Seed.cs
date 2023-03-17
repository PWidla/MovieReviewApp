using MovieReviewApp.Data;
using MovieReviewApp.Models;

namespace MovieReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.MovieDirectors.Any())
            {
                var movieDirectors = new List<MovieDirector>()
                {
                    new MovieDirector()
                    {
                        Movie = new Movie()
                        {
                            Title = "Dune",
                            ReleaseDate = new DateTime(2021,10,22),
                            MovieCategories = new List<MovieCategory>()
                            {
                                new MovieCategory { Category = new Category() { Name = "Action"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Dune",Text = "Great movie", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Dune", Text = "Bad movie", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Dune",Text = "Could be better", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Denis",
                            LastName = "Villeneuve",
                            Country = new Country()
                            {
                                Name = "France"
                            }
                        }
                    },

                    new MovieDirector()
                    {
                        Movie = new Movie()
                        {
                            Title = "Inception",
                            ReleaseDate = new DateTime(2010,09,12),
                            MovieCategories = new List<MovieCategory>()
                            {
                                new MovieCategory { Category = new Category() { Name = "Sci-Fi"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Inception",Text = "It's my favourite movie", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Inception", Text = "I'm a huge fan of Mr. Nolan", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Inception",Text = "I fell asleep", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Christopher",
                            LastName = "Nolan",
                            Country = new Country()
                            {
                                Name = "England"
                            }
                        }
                    },

                    new MovieDirector()
                    {
                        Movie = new Movie()
                        {
                            Title = "Forrest Gump",
                            ReleaseDate = new DateTime(2014,04,09),
                            MovieCategories = new List<MovieCategory>()
                            {
                                new MovieCategory { Category = new Category() { Name = "Drama"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Forrest Gump",Text = "Great movie. Better than Twilight", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Forrest Gump", Text = "Could be better", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Forrest Gump",Text = "Brilliant movie", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Robert",
                            LastName = "Zemeckis",
                            Country = new Country()
                            {
                                Name = "USA"
                            }
                        }
                    },
                };
                dataContext.MovieDirectors.AddRange(movieDirectors);
                dataContext.SaveChanges();
            }
        }
    }
}

using MovieReviewApp.Models;

namespace MovieReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Movie> GetMoviesByCategory(int categoryId);
        bool CategoryExist(int id);
        bool CreateCategory(Category category);
        bool Save();
    }
}

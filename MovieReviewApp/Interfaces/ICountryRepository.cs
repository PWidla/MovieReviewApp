using MovieReviewApp.Models;
using System.Diagnostics.Metrics;

namespace MovieReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByDirector(int directorId);
        ICollection<Director> GetDirectorsFromACountry(int countryId);
        bool CountryExist(int id);
        bool CreateCountry(Country country);
        //bool UpdateCountry(Country country);
        bool Save();
    }
}

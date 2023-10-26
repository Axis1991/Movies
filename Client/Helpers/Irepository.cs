using Movies.Shared.Entities;

namespace BlazorApp1.Client.Helpers
{
    public interface Irepository
    {
        List<Movie> GetMovies();
    }
}

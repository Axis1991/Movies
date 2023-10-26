using Movies.Shared.Entities;

namespace BlazorApp1.Client.Helpers
{
    public class RepositoryInMemory : Irepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
        {
            new Movie() { Title = "spiderman: far from home", ReleaseDate = new DateTime(2019, 7, 2) },
            new Movie() { Title = "moana", ReleaseDate = new DateTime(2016, 11, 23) },
            new Movie() {Title = "inception", ReleaseDate = new DateTime(2010, 7, 16)}
        };
        }
    }
}

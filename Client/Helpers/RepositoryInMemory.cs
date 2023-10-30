using Movies.Shared.Entities;
using static System.Net.WebRequestMethods;

namespace BlazorApp1.Client.Helpers
{
    public class RepositoryInMemory : Irepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
            new Movie() { Title = "Avatar: The way of water", ReleaseDate = new DateTime(2022, 12, 16), Poster="https://m.media-amazon.com/images/I/71dcqYNTKmL._AC_UF1000,1000_QL80_.jpg" },
            new Movie() { Title = "Lord of the Rings", ReleaseDate = new DateTime(2001, 02, 15) , Poster="https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg"},
            new Movie() {Title = "Les Misérables", ReleaseDate = new DateTime(2013, 01, 25), Poster="https://fwcdn.pl/fpo/95/95/599595/7504935.3.jpg"}
        };
        }
    }
}

using Microsoft.AspNetCore.Components;
using Movies.Shared.Entities;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton {  get; set; }
        [Inject] TransientService transient {  get; set; }

        private List<Movie> movies;
        protected override void OnInitialized()
        {
            movies = new List<Movie>()
        {
            new Movie(){Title = "Joker", ReleaseDate = new DateTime(2021, 8, 12)},
            new Movie(){Title = "Avengers: End Game", ReleaseDate = new DateTime(2016, 11, 23)},
            new Movie(){Title = "Piccolo", ReleaseDate = new DateTime(2013, 1, 16)}
        };
        }

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            singleton.Value += 1;
            transient.Value += 1;
        }
    }
}

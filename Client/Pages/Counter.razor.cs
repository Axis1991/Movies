using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Movies.Shared.Entities;
using static BlazorApp1.Client.Shared.MainLayout;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton {  get; set; }
        [Inject] TransientService transient {  get; set; }
        [Inject] IJSRuntime js { get; set; }
        [CascadingParameter] public AppState AppState { get; set; }

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
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            singleton.Value += 1;
            transient.Value += 1;
            currentCountStatic++;
            js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        private async Task IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvocation", DotNetObjectReference.Create(this));
        }


        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}

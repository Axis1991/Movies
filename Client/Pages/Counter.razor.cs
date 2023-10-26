using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Movies.Shared.Entities;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton {  get; set; }
        [Inject] TransientService transient {  get; set; }
        [Inject] IJSRuntime js { get; set; }

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
        IJSObjectReference module;

        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert", "hello world");
            currentCount++;
            singleton.Value += currentCount;
            transient.Value += currentCount;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
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

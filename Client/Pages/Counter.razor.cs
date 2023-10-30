using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Movies.Shared.Entities;
using static BlazorApp1.Client.Shared.MainLayout;
using MathNet.Numerics.Statistics;
using System.Security.Cryptography;

namespace BlazorApp1.Client.Pages
{

    public partial class Counter
    {
        [Inject] IJSRuntime js { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;
        IJSObjectReference module;

        [JSInvokable]
        public async Task IncrementCount()
        {
            var array = new double[] { 1, 2, 3, 4, 5 };
            var max = array.Maximum();
            var min = array.Minimum();

            module = await js.InvokeAsync<IJSInProcessObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert", $"Max is {max} and min is {min}");

            currentCount++;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }
    }
}

using MathNet.Numerics.Optimization;
using MathNet.Numerics.Statistics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Movies.Shared.Entities;
using static BlazorApp1.Client.Shared.MainLayout;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }
        public async Task IncrementCount()
        {
            var authState = await AuthenticationState;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                currentCount++;
            }
            else { currentCount--; }
            
         }

        //[JSInvokable]
        //public static Task<int> GetCurrentCount()
        //{
        //    return Task.FromResult(currentCountStatic);
        //}
    }
}

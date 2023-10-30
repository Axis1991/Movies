using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Movies.Shared.Entities;
using static BlazorApp1.Client.Shared.MainLayout;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        public void IncrementCount()
        {
            currentCount++;
        }
    }
}

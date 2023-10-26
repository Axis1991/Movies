using Microsoft.JSInterop;

namespace BlazorApp1.Client.Helpers
{
    public static class USRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", "example message");
            return await  js.InvokeAsync<bool>("confirm", message);
        }
        public static async ValueTask MyFunction(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("my_function", message);
        }
    }
}

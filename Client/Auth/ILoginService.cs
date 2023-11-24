namespace BlazorApp1.Client.Auth
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Login();

    }
}

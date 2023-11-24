using BlazorApp1.Client.Helpers;
using Movies.Shared;
using System.ComponentModel.Design;

namespace BlazorApp1.Client.Pages.UserState
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/accounts";

        public AccountsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var httpResponse = await httpService.Post<UserInfo, UserToken>($"{baseURL}/register", userInfo);
            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }
            return httpResponse.Response;
        }
        public Task<UserToken> Login(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken> RenewToken()
        {
            throw new NotImplementedException();
        }
    }
}

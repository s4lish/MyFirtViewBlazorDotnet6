
using Microsoft.AspNetCore.Components;

namespace BlazorAll.Client.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _nav;
        public LoginService(HttpClient http, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService, NavigationManager navigationManger)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorageService;
            _nav = navigationManger;
        }

        public async Task Login(UserLoginDto userInfo)
        {
            var res = await _http.PostAsJsonAsync("api/auth", userInfo);
            if (res.IsSuccessStatusCode)
            {
                var token = await res.Content.ReadAsStringAsync();
                await _localStorage.SetItemAsync("token", token);
                await _authenticationStateProvider.GetAuthenticationStateAsync();
                _nav.NavigateTo("/");
            }
            else
            {

            }
        }

    }
}

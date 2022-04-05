namespace BlazorAll.Client.Services.LoginService
{
    public interface ILoginService
    {
        Task Login(UserLoginDto userInfo);
    }
}

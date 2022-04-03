using System.Security.Claims;
using System.Text.Json;

namespace BlazorAll.Client;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2NDcyNjE1MDl9.zAPwArMdu4n-u_pg_5SMDQ7J5QhA-JkHUL74ENVEKa730O4ch9WHtjXLEX5jCl8aJd330VsPAlvMaU7MifXAYQ";

        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

        //var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WhitoutPadding(payload);
        var keyvaluePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyvaluePairs.Select(kvp => new Claim(kvp.Key,kvp.Value.ToString()));

    }

    private static byte[] ParseBase64WhitoutPadding(string base64)
    {
        switch(base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }
}


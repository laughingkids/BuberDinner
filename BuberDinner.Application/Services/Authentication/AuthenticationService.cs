using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

    AuthenticationResult IAuthenticationService.Register(string firstName, string lastName, string email, string password)
    {
        // check if user already exist
        // create user (generate unique id)
        // create token
        Guid uerId = Guid.NewGuid();
        string token = _jwtTokenGenerator.GenerateToken(uerId, firstName, lastName);
        return new AuthenticationResult(uerId, firstName, lastName, email, token);
    }
}
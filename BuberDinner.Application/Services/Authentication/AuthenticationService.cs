using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    ErrorOr<AuthenticationResult> IAuthenticationService.Login(string email, string password)
    {
        // check if user exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // create user (generate unique id)
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // create token
        string token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    ErrorOr<AuthenticationResult> IAuthenticationService.Register(string firstName, string lastName, string email, string password)
    {
        // check if user already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateError;
        }
        // create user (generate unique id)
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);
        // create token
        string token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
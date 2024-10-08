using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Interfaces.Authentication;
using BuberDinner.Domain.Entities;

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
    
    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exist");
        }
        // 2. Validate password
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        // 3. Generate token
        return new AuthenticationResult(
            user,
            token);

    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }
        // 2. create user (generate user id)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.AddUser(user);
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}
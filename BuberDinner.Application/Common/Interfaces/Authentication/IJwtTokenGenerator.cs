using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
using DinnerHostingApp.Domain.Entities;

namespace DinnerHostingApp.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
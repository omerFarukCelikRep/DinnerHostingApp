using DinnerHostingApp.Domain.Entities;

namespace DinnerHostingApp.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
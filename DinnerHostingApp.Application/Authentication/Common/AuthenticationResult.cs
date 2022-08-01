using DinnerHostingApp.Domain.Entities;

namespace DinnerHostingApp.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);
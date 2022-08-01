using DinnerHostingApp.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DinnerHostingApp.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
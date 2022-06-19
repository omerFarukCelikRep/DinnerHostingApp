using DinnerHostingApp.Application.Common.Interfaces.Authentication;
using DinnerHostingApp.Application.Common.Interfaces.Persistence;
using DinnerHostingApp.Domain.Entities;

namespace DinnerHostingApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Validate the user doesn't exist
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        //Create user (generate unique Id) && Persist the DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        //Validate the user exists
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("User with given email already exists");
        }

        //Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }

        //Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
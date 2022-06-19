using DinnerHostingApp.Domain.Entities;

namespace DinnerHostingApp.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void Add(User user);
}
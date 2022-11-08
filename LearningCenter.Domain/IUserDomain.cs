using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public interface IUserDomain
{
    Task<string> Login(User user);
    Task<bool> Signup(User user);
    Task<User> GetByUsername(string username);
}
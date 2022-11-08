namespace LearningCenter.Infraestructure;

public interface IUserRepository
{
    Task<User> GetByUsername(string username);
    Task<bool> Login(User user);
    Task<bool> Singup(User user);
}
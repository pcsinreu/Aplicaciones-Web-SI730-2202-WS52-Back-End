using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public class UserDomain :IUserDomain
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenDomain _tokenDomain;
    
    public UserDomain(IUserRepository userRepository,ITokenDomain tokenDomain)
    {
        _userRepository = userRepository;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(User user)
    {
        var result = await _userRepository.GetByUsername(user.Username);

        if (result.Password == user.Password)
        {
            return _tokenDomain.GenerateJwt(user.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<bool> Signup(User user)
    {
        return await _userRepository.Singup(user);
    }

    public async Task<User> GetByUsername(string username)
    {
        return  await _userRepository.GetByUsername(username);
    }
    
}
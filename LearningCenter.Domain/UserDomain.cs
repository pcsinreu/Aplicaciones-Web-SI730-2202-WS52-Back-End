using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public class UserDomain :IUserDomain
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenDomain _tokenDomain;
    private readonly IEncryptDomain _encryptDomain;
    
    public UserDomain(IUserRepository userRepository,ITokenDomain tokenDomain ,IEncryptDomain encryptDomain)
    {
        _userRepository = userRepository;
        _tokenDomain = tokenDomain;
        _encryptDomain = encryptDomain;
    }

    public async Task<string> Login(User user)
    {
        var result = await _userRepository.GetByUsername(user.Username);

        if (_encryptDomain.Decrypt(result.Password) == user.Password)
        {
            return _tokenDomain.GenerateJwt(user.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<bool> Signup(User user)
    {
        user.Password = _encryptDomain.Ecnrypt(user.Password);
        return await _userRepository.Singup(user);
    }

    public async Task<User> GetByUsername(string username)
    {
        return  await _userRepository.GetByUsername(username);
    }
    
}
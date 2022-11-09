using LearningCenter.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class UserRepository : IUserRepository
{
    private readonly LearningCentDBContext _learningCentDbContext;

    public UserRepository(LearningCentDBContext learningCentDbContext)
    {
        _learningCentDbContext = learningCentDbContext;
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _learningCentDbContext.Users.SingleOrDefaultAsync(user => user.Username ==  username);
        
        ///_learningCentDbContext.FromExpression("exec SP_finuserByNa "& username );

    }

    public async Task<bool> Login(User user)
    {
        _learningCentDbContext.Users.Add(user);
        await _learningCentDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Singup(User user)
    {
        await _learningCentDbContext.Users.AddAsync(user);
        await _learningCentDbContext.SaveChangesAsync();
        return true;
    }
}
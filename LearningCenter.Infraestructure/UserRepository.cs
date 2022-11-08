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
    }

    public async Task<bool> Login(User user)
    {
        _learningCentDbContext.Users.Add(user);
        await _learningCentDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Singup(User user)
    {
        using (var transacction = await _learningCentDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _learningCentDbContext.Users.AddAsync(user);
                await _learningCentDbContext.SaveChangesAsync();
                await transacction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transacction.RollbackAsync();
            }
            finally
            {
                await transacction.DisposeAsync();
            }
        }
        return true;
    }
}
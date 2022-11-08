using LearningCenter.Domain;

namespace LearningCenter.API.Middleware;

public class JwtMiddleware
{

    private readonly RequestDelegate _next;
    
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserDomain userDomain)
    {

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var username = tokenDomain.ValidateJwt(token);

        if (username != null)
        {
            context.Items["User"] = await  userDomain.GetByUsername(username);
        }
        
        await _next(context);
    }

}
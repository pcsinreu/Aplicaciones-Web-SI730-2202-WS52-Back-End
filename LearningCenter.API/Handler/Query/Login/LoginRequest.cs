using System.ComponentModel.DataAnnotations;
using MediatR;

namespace LearningCenter.API.Handler.Query.Login;

public class LoginRequest :IRequest<LoginRespond>
{
    [Required]
    [MaxLength(10)]
    public  String Username { get; set; }
    
    
    [Required]
    public  String Password { get; set; }
}
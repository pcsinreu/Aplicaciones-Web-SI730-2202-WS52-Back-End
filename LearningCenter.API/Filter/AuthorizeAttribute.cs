using LearningCenter.Infraestructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningCenter.API.Filter;

public class AuthorizeAttribute : Attribute,IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        // Then skip authorization process
        if (allowAnonymous)
            return;
        
        
        // Authorization process
        var user = (User)context.HttpContext.Items["User"];

        if (user == null)
        {
            context.Result = new JsonResult(new {message="Unathorized"}) {StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
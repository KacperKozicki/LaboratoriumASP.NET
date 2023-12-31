using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
public class AuthorizeRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string[] _roles;
    private readonly string _errorMessage;

    public AuthorizeRolesAttribute(string roles, string errorMessage)
    {
        _roles = roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        _errorMessage = errorMessage;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        bool isAuthorized = _roles.Any(role => user.IsInRole(role));

        if (!user.Identity.IsAuthenticated || !isAuthorized)
        {
            context.Result = new RedirectToActionResult("AccessDenied", "Account", new { message = _errorMessage });
        }
    }
}




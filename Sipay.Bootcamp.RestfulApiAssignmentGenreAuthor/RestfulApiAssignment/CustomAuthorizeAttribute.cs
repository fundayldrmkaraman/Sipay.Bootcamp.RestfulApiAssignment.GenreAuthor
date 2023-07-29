using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestfulApiAssignment.Users;

namespace RestfulApiAssignment
{
    public class CustomAuthorizeAttribute:Attribute,IAuthorizationFilter
    {
        private readonly IUserService _userService;

        public CustomAuthorizeAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            var authHeader = context.HttpContext.Request.Headers["Authorization"];
            var token = authHeader.ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token) && _userService.ValidateToken(token))
            {
                return;
            }

            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }
    }
}

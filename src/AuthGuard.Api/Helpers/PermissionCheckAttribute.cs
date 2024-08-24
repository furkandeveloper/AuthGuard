using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthGuard.Api.Helpers
{
    public class PermissionCheckAttribute : ActionFilterAttribute
    {
        private string Permission { get; }
        public PermissionCheckAttribute(string permission)
        {
            Permission = permission;
        }
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var currentPermissions = context.HttpContext.User.Claims.GetScope();
            var isExist = currentPermissions.Contains(Permission);
            if (!isExist)
            {
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = $"{Permission} Permission Required!!",
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}

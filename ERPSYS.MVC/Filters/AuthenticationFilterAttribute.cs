using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ERPSYS.MVC.Filters
{
    public class AuthenticationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = ((ControllerBase)context.Controller).ControllerContext;
            //var usuario = Startup.Session?.GetUserId("USERSESSION");
            var usuario = Startup.UserSession;
            bool funcionario = controller.ActionDescriptor.ControllerName == "Login";
            bool index = controller.ActionDescriptor.ActionName == "Index";
            bool autenticar = controller.ActionDescriptor.ActionName == "Autenticar";
            bool actionDeLogin = (funcionario && index) || (funcionario && autenticar);
            if (usuario == null && !actionDeLogin)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                        )
                    );
            }
        }
    }
}

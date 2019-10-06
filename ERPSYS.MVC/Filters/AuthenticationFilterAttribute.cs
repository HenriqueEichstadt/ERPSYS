using System;
using Microsoft.AspNetCore.Http;
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
            var nomeUsuario = Startup.Session?.GetString("USERNAME");
            bool funcionario = controller.ActionDescriptor.ControllerName == "Login";
            bool index = controller.ActionDescriptor.ActionName == "Index";
            bool autenticar = controller.ActionDescriptor.ActionName == "Autenticar";
            bool actionDeLogin = (funcionario && index) || (funcionario && autenticar);
            if (string.IsNullOrEmpty(nomeUsuario) && !actionDeLogin)
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

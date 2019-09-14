using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.Session;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class LoginController : Controller
    {
        [Inject] public IUsuarioDAO UsuarioDao { get; set; }
        [Inject] public IUsuario Usuario { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string apelido, string senha)
        {
            if (UsuarioDao.IsUsuarioCadastrado(apelido, senha))
            {
                Usuario = UsuarioDao.GetByApelido(apelido) as Usuario;
                Startup.Session = HttpContext.Session;
                Startup.UserSession = Usuario;
                HttpContext.Session.SetUserId("USERSESSION", Usuario.Id);
                return RedirectToAction("Index", "Home");
            }
                
            else
                return RedirectToAction("Index");
                //return Json(new { autenticou = false });
        }

        public JsonResult Logout()
        {
            HttpContext.Session.Clear();
            Startup.UserSession = null;
            //HttpContext.Session.SetUserId("USERSESSION", -1);
             foreach (var cookieKey in Request.Cookies.Keys)
             {
                 Response.Cookies.Delete(cookieKey);
             }
            return Json(new { logOut = true });
        }
    }
}
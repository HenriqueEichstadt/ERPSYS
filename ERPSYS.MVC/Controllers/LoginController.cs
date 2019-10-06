using System;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.Session;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Http;
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
            Usuario = UsuarioDao.GetByApelidoESenha(apelido, senha);

            if (Usuario != null)
            {
                Startup.Session = HttpContext.Session;
                Startup.UserSession = Usuario;
                AtribuirDadosUsuarioNaSessao(Usuario.Nome, Usuario.Id, Usuario.NivelAcesso);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }
        
        public JsonResult Logout()
        {
            HttpContext.Session.Clear();
            Startup.UserSession = null;
            Startup.Session = null;
            foreach (var cookieKey in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookieKey);
            }

            return Json(new {logOut = true});
        }
        
        private void AtribuirDadosUsuarioNaSessao(string usuarioNome, int usuarioId, char usuarioNivelAcesso)
        {
            HttpContext.Session.SetString("USERNAME", Usuario.Nome);
            HttpContext.Session.SetString("ID", Convert.ToString(Usuario.Id));
            HttpContext.Session.SetString("NIVELACESSO", Usuario.NivelAcesso.ToString());
        }
    }
}
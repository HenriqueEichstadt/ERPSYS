using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.Common;
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
            if (UsuarioDao.IsUsuarioCadastrado(apelido, senha))
            {
                Startup.Session = HttpContext.Session;
                Usuario = UsuarioDao.GetByApelido(apelido) as Usuario;
                HttpContext.Session.SetUserId("USERSESSION", Usuario.Id);
                return RedirectToAction("Index", "Home");
            }
                
            else
                return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
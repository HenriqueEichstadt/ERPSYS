using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.Models;
using ERPSYS.Models;
using ERPSYS.MVC.DAO;
using Ninject;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.Session;
using Microsoft.AspNetCore.Mvc;

namespace ERPSYS.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IPessoa Pessoa { get; set; }
        [Inject]
        public IUsuarioDAO UsuarioDao { get; set; }
        [Inject] public IUsuario UsuarioLogado { get; set; }

        public IActionResult Index()
        {
            GetUserInSession();
            ViewData["NomeUsuario"] = UsuarioLogado.Nome;
            ViewData["NivelAcesso"] = UsuarioLogado.NivelAcesso;
            var usuario = new UsuarioDAO().Teste();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void GetUserInSession()
        {
            //var usuarioId = HttpContext.Session.GetUserId("USERSESSION");
            var usuario = Startup.UserSession;
            if (usuario != null)
                UsuarioLogado = UsuarioDao.GetById(usuario.Id);
        }
    }
}

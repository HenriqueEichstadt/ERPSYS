using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class ClienteController : Controller
    {
        [Inject] public IPessoa Pessoa { get; set; }
        [Inject] public IPessoaDAO PessoaDao { get; set; }

        public IActionResult Cadastrados()
        {
            var pessoas = PessoaDao.ListAll();
            return View(pessoas);
        }

        public IActionResult Novo()
        {
            return View(Pessoa);
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                PessoaDao.Add(pessoa);

                return Json(new
                {
                    data = new { add = true, message = "Sucesso", type = "success" }
                });
            }
             return Json(new
            {
                data = new { add = false, message = "Erro", type = "warning" }
            });
        }
    }
}
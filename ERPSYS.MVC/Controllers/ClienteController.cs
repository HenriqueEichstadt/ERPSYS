using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
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
            return View();
        }

        public IActionResult Novo()
        {
            Pessoa.CPF = "082.,62.349-00";
            Pessoa.Email = "Teste";
            PessoaDao.AddCliente(Pessoa);
            return View();
        }
    }
}
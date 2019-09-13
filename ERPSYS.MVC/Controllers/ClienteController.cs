using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ModelState;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.IOC;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class ClienteController : Controller
    {
        [Inject] public ICliente Cliente { get; set; }
        [Inject] public IClienteDAO ClienteDao { get; set; }
        [Inject] public IUsuarioDAO UsuarioDao { get; set; }
        [Inject] public IMyActivator MyActivator { get; set; }

        public IActionResult Cadastrados()
        {
            var pessoas = ClienteDao.ListAll();
            return View(pessoas);
        }

        public IActionResult Novo()
        {
            Cliente.Pessoa = MyActivator.CreateInstance<Pessoa>();
            Cliente.Pessoa.Endereco = MyActivator.CreateInstance<IEndereco, Endereco>() as Endereco;
            return View(Cliente);
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Cliente cliente)
        {
            cliente.AtribuirDados();
            if (ModelState.IsValid)
            {
                ClienteDao.Add(cliente);
                return Json(new
                {
                    data = new { add = true, message = "Cliente cadastrado com sucesso!" }
                });
            }

            //string validacoes = cliente.Valida();
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
    }
}
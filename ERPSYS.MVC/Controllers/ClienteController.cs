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
using Newtonsoft.Json;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class ClienteController : Controller
    {
        [Inject] public ICliente Cliente { get; set; }
        [Inject] public IClienteDAO ClienteDao { get; set; }
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
            return View(Cliente as Cliente);
        }

        public IActionResult Editar(int id)
        {
            var cliente = ClienteDao.GetById(id);
            return View(cliente as Cliente);
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Cliente cliente)
        {
            cliente.AtribuirDadosInclusao();
            if (ModelState.IsValid)
            {
                ClienteDao.Add(cliente);
                return Json(new
                {
                    data = new { add = true, message = "Cliente cadastrado com sucesso!" }
                });
            }
            ViewBag.Cliente = cliente;
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
        
        
        public JsonResult ListarClientes()
        {
            return Json(new
            {
                data = ClienteDao.ListarClientes()
            });
        }

        public JsonResult UpdateCliente(Cliente cliente)
        {
            cliente.AtribuirDadosAlteracao();
            if (ModelState.IsValid)
            {
                ClienteDao.Update(cliente); 
                return Json(new
                {
                    data = new { add = true, message = "Cliente editado com sucesso!" }
                });
            }
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }

        public JsonResult InativarCliente(int id)
        {
            ClienteDao.Inativar(id);
            return Json(new
            {
                data = new { Inativou = true }
            });
        }
        
        public JsonResult AtivarCliente(int id)
        {
            ClienteDao.Ativar(id);
            return Json(new
            {
                data = new { Ativou = true }
            });
        }
    }
}
using System;
using System.Collections.Generic;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class VendaController : Controller
    {
        [Inject] public IVenda Venda { get; set; }
        [Inject] public IVendaDAO VendaDao { get; set; }
        [Inject] public IMyActivator MyActivator { get; set; }
        [Inject] public IEmissorDeVenda EmissorDeVenda { get; set; }

        public IActionResult Cadastrados()
        {
            return View();
        }

        public IActionResult Novo()
        {
            Venda = MyActivator.CreateInstance<Venda>();
            Venda.Data = DateTime.Now;
            return View(Venda as Venda);
        }

        public IActionResult Editar(int id)
        {
            var venda = VendaDao.GetById(id);
            return View(venda);
        }

        [HttpPost]
        public JsonResult EmitirVenda([FromBody] Venda venda)
        {
            try
            {
                venda.AtribuirDadosInclusao();
                if (ModelState.IsValid)
                {
                    var msg = EmissorDeVenda.EmitirVenda(venda);
                    return Json(new {emitida = true, mensagem = msg});
                }
                else
                {
                    return Json(new {emitida = false, mensagem = "Venda inválida"});
                }
            }
            catch(Exception ex)
            {
                return Json(new {emitida = false, mensagem = $"Erro ao emitir venda {ex.Message}"});
            }
        }
    }
}
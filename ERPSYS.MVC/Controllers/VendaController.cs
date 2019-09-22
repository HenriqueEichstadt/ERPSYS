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

       public IActionResult Cadastrados()
       {
           return View();
       }

       public IActionResult Novo()
       {
           Venda = MyActivator.CreateInstance<Venda>();
           return View(Venda);
       }

       public IActionResult Editar(int id)
       {
           var venda = VendaDao.GetById(id);
           return View(venda);
       }
       
       public JsonResult EmitirVenda(Venda venda, List<VendaItens> vendaItens)
       {
           try
           {
               venda.VendaItens = vendaItens;
               venda.Data = DateTime.Now;

               // Se for uma venda por troca de pontos
               if (venda.ClienteId != null && venda.FormaPagamento == 1)
               {
                   int trocaPontos = (int) (venda.PrecoTotal * 100);
                   VendaDao.TrocaPorPontos(venda.ClienteId, trocaPontos);
               }
               // Demais Vendas
               else
               {
                   VendaDao.AdicionaVenda(venda);
                   VendaDao.DecrementaDoEstoque(vendaItens);
               }

               // Se for no Dinheiro ou Débito gera pontos para o programa de fidelidade
               if (venda.ClienteId != null && venda.FormaPagamento == 0 || venda.FormaPagamento == 1)
               {
                   int qtdDePontos = Convert.ToInt32(venda.PrecoTotal);
                   int cliente = Convert.ToInt32(venda.ClienteId);
                   VendaDao.SomaPontos(cliente, qtdDePontos);
               }

               return Json(new {adicionou = true});
           }
           catch
           {
               return Json(new {Add = true, Message = "Erro ao emitir venda"});
           }
       }
    }
}
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ModelState;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        [Inject] public IProduto Produto { get; set; }
        [Inject] public IProdutoDAO ProdutoDao { get; set; }
        [Inject] public IMyActivator MyActivator { get; set; }
        
        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Cadastrados()
        {
            var produtos = ProdutoDao.ListAll();
            return View(produtos);
        }

        public IActionResult Editar(int id)
        {
            var produto = ProdutoDao.GetById(id);
            return View(produto);
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Produto produto)
        {
            produto.AtribuirDadosInclusao();
            if (ModelState.IsValid)
            {
                ProdutoDao.Add(produto);
                return Json(new
                {
                    data = new { add = true, message = "Produto cadastrado com sucesso!" }
                });
            }
            ViewBag.Cliente = produto;
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
        
        public JsonResult ListarProdutos()
        {
            return Json(new
            {
                data = ProdutoDao.ListAll()
            });
        }

        public JsonResult UpdateProduto(Produto produto)
        {
            produto.AtribuirDadosAlteracao();
            if (ModelState.IsValid)
            {
                ProdutoDao.Update(produto); 
                return Json(new
                {
                    data = new { add = true, message = "Produto editado com sucesso!" }
                });
            }
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }

        public JsonResult InativarProduto(int id)
        {
            ProdutoDao.Inativar(id);
            return Json(new
            {
                data = new { Inativou = true }
            });
        }
        
        public JsonResult AtivarProduto(int id)
        {
            ProdutoDao.Ativar(id);
            return Json(new
            {
                data = new { Ativou = true }
            });
        }

        public JsonResult ListarProdutosAtivos()
        {
            return Json(new
            {
                data = ProdutoDao.ListarAtivosComEstoqueDisponivel()
            });
        }
    }
}
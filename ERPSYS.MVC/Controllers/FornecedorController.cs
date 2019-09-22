using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ModelState;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class FornecedorController : Controller
    {
        [Inject] public IPessoa Pessoa { get; set; }
        [Inject] public IPessoaDAO PessoaDao { get; set; }
        [Inject] public IMyActivator MyActivator { get; set; }
        
        public IActionResult Cadastrados()
        {
            var fornecedores = PessoaDao.ListAll();
            return View(fornecedores);
        }

        public IActionResult Novo()
        {
            Pessoa = MyActivator.CreateInstance<Pessoa>();
            Pessoa.Endereco = MyActivator.CreateInstance<IEndereco, Endereco>() as Endereco;
            return View(Pessoa as Pessoa);
        }

        public IActionResult Editar(int id)
        {
            var pessoa = PessoaDao.GetById(id);
            return View(pessoa);
        }
        
        [HttpPost]
        public JsonResult AdicionarNovo(Pessoa pessoa)
        {
            pessoa.AtribuirDadosInclusao('J');
            if (ModelState.IsValid)
            {
                PessoaDao.Add(pessoa);
                return Json(new
                {
                    data = new { add = true, message = "Fornecedor cadastrado com sucesso!" }
                });
            }
            ViewBag.Cliente = pessoa;
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
        
        
        public JsonResult ListarFornecedores()
        {
            return Json(new
            {
                data = PessoaDao.ListFornecedores()
            });
        }
        
        public JsonResult UpdateFornecedor(Pessoa pessoa)
        {
            pessoa.AtribuirDadosAlteracao();
            if (ModelState.IsValid)
            {
                PessoaDao.Update(pessoa); 
                return Json(new
                {
                    data = new { add = true, message = "Fornecedor editado com sucesso!" }
                });
            }
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }

        public JsonResult InativarFornecedor(int id)
        {
            PessoaDao.Inativar(id);
            return Json(new
            {
                data = new { Inativou = true }
            });
        }
        
        public JsonResult AtivarFornecedor(int id)
        {
            PessoaDao.Ativar(id);
            return Json(new
            {
                data = new { Ativou = true }
            });
        }
    }
}
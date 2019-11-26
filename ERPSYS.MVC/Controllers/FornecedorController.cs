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
        
        public IActionResult Cadastrados() => View();

        public IActionResult Novo()
        {
            //ViewBag.Pessoa = new Pessoa();
            //ViewBag.Pessoa.Endereco = new Endereco();
            return View();
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Pessoa = PessoaDao.GetById(id);
            return View();
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Pessoa pessoa) =>
            ConsistirInformacoes(pessoa);

        public JsonResult UpdateFornecedor(Pessoa pessoa) =>
            ConsistirInformacoes(pessoa, false);
        
        public JsonResult ListarFornecedores()
        {
            return Json(new
            {
                data = PessoaDao.ListFornecedores()
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

        private JsonResult ConsistirInformacoes(Pessoa pessoa, bool insertMode = true)
        {
            string str;
            if (insertMode)
            {
                pessoa.AtribuirDadosInclusao('J');
                str = "cadastrado";
            }
            else
            {
                pessoa.AtribuirDadosAlteracao();
                str = "editado";
            }

            if (ModelState.IsValid)
            {
                if (insertMode)
                    PessoaDao.Add(pessoa);
                else
                    PessoaDao.Update(pessoa);
                return Json(new
                {
                    data = new { add = true, message = $"Fornecedor {str} com sucesso!" }
                });
            }
            return Json(new
            {
                data = new { add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
    }
}
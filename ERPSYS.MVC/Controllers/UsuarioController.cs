using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ModelState;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ERPSYS.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [Inject] public IUsuarioDAO UsuarioDao { get; set; }

        public IActionResult Cadastrados() => View();

        public IActionResult Novo() => View();


        public IActionResult Editar(int id)
        {
            ViewBag.Fornecedor = UsuarioDao.GetById(id);
            return View();
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Usuario usuario, string senhaRepetida) =>
            ConsistirInformacoes(usuario, senhaRepetida);


        public JsonResult UpdateUsuario(Usuario usuario, string senhaRepetida) =>
            ConsistirInformacoes(usuario, senhaRepetida, false);

        public JsonResult ListarUsuarios() =>
            Json(new {data = UsuarioDao.ListAll()});

        public JsonResult InativarUsuario(int id)
        {
            UsuarioDao.Inativar(id);
            return Json(new {data = new {Inativou = true}});
        }

        public JsonResult AtivarUsuario(int id)
        {
            UsuarioDao.Ativar(id);
            return Json(new {data = new {Ativou = true}});
        }

        private JsonResult ConsistirInformacoes(Usuario user, string repeatedPassword, bool insertMode = true)
        {
            string srt;
            if (user.Senha != repeatedPassword)
                return Json(new
                {
                    data = new {add = false, message = "As senhas não coincidem"}
                });

            if (insertMode)
            {
                user.AtribuirDadosInclusao();
                srt = "cadastrado";
            }
            else
            {
                user.AtribuirDadosAlteracao();
                srt = "editado";
            }

            if (ModelState.IsValid)
            {
                if (insertMode)
                    UsuarioDao.Add(user);
                else
                    UsuarioDao.Update(user);
                    
                return Json(new
                {
                    data = new {add = true, message = $"Usuário {srt} com sucesso!"}
                });
            }
            return Json(new
            {
                data = new {add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }
    }
}
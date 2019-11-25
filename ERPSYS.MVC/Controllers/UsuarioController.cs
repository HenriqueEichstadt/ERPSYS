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
        [Inject] public IUsuario Usuario { get; set; }
        [Inject] public IUsuarioDAO UsuarioDao { get; set; }

        public IActionResult Cadastrados() => View();
        
        public IActionResult Novo() => View();
        

        public IActionResult Editar(int id)
        {
            Usuario = UsuarioDao.GetById(id);
            ViewBag.usuario = Usuario;
            ViewData["USER"] = Usuario;
            return View();
        }

        [HttpPost]
        public JsonResult AdicionarNovo(Usuario usuario, string senhaRepetida)
        {
            if (usuario.Senha != senhaRepetida)
                return Json(new
                {
                    data = new {add = false, message = "As senhas não coincidem"}
                });
            
            usuario.AtribuirDadosInclusao();
            if (ModelState.IsValid)
            {
                UsuarioDao.Add(usuario);
                return Json(new
                {
                    data = new {add = true, message = "Usuário cadastrado com sucesso!"}
                });
            }

            return Json(new
            {
                data = new {add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }


        public JsonResult ListarUsuarios()
        {
            var usuarios = UsuarioDao.ListAll();
            return Json(new
            {
                data = usuarios
            });
        }

        public JsonResult UpdateUsuario(Usuario usuario, string senhaRepetida)
        {
            if (usuario.Senha != senhaRepetida)
                return Json(new
                {
                    data = new {add = false, message = "As senhas não coincidem"}
                });

            usuario.AtribuirDadosAlteracao();
            if (ModelState.IsValid)
            {
                UsuarioDao.Update(usuario);
                return Json(new
                {
                    data = new {add = true, message = "Usuário editado com sucesso!"}
                });
            }

            return Json(new
            {
                data = new {add = false, message = "Erro no cadastro", validate = ModelState.GetAllErrors()}
            });
        }

        public JsonResult InativarUsuario(int id)
        {
            UsuarioDao.Inativar(id);
            return Json(new
            {
                data = new {Inativou = true}
            });
        }

        public JsonResult AtivarUsuario(int id)
        {
            UsuarioDao.Ativar(id);
            return Json(new
            {
                data = new {Ativou = true}
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;

namespace ERPSYS.MVC.Models
{
    public partial class Usuario
    {
        private UsuarioDAO _usuarioDao = new UsuarioDAO();
        
        public void AtribuirDadosInclusao()
        {
            Ativo = true;
            UsuarioInclusaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
        }
        
        public void AtribuirDadosAlteracao()
        {
            DataAlteracao = DateTime.Now;
            UsuarioAlteracaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
        }
    }
}

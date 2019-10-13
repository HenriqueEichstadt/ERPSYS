using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;

namespace ERPSYS.MVC.Models
{
    public partial class VendaItens
    {
        private UsuarioDAO _usuarioDao = new UsuarioDAO();
        public void AtribuirDadosInclusao()
        {
            DataInclusao = DateTime.Now;
            UsuarioInclusaoId =  _usuarioDao.GetById(Startup.UserSession.Id).Id;
        }
    }
}

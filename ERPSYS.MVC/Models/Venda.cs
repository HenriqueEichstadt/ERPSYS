using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;

namespace ERPSYS.MVC.Models
{
    public partial class Venda
    {
        private UsuarioDAO _usuarioDao = new UsuarioDAO();
        
        public void AtribuirDadosInclusao()
        {
            DataInclusao = DateTime.Now;
            UsuarioInclusaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            foreach (var item in VendaItens)
            {
                item.AtribuirDadosInclusao();    
            }
        }
    }
}

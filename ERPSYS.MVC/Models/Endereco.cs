using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.IOC;

namespace ERPSYS.MVC.Models
{
    public partial class Endereco
    {
        
        internal void AtribuirDados()
        {
            DataInclusao = DateTime.Now;
            UsuarioInclusaoId = new UsuarioDAO().GetById(Startup.UserSession.Id).Id;
        }
    }
}

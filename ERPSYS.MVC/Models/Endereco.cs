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
        [Inject] public IMyActivator MyActivator { get; set; }
        
        internal void AtribuirDados()
        {
            DataInclusao = DateTime.Now;
            var usuarioDao = MyActivator.CreateInstance<IUsuarioDAO, UsuarioDAO>();
            UsuarioInclusaoId = usuarioDao.GetById(Startup.UserSession.Id).Id;
        }
    }
}

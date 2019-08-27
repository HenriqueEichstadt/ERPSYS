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
        public IUsuarioDAO UsuarioDao { get; set; }
        [Inject] public IMyActivator MyActivator { get; set; }

        public Endereco()
        {
            MyDependencyContainer.Inject(this);
        }
        
        internal void AtribuirDados()
        {
            DataInclusao = DateTime.Now;
            var usuarioDao = MyActivator.CreateInstance<IUsuarioDAO>();
            UsuarioInclusaoId = usuarioDao.GetById(Startup.UserSession.Id).Id;
        }
    }
}

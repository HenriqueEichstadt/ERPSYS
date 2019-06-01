using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public class ERPSYSNinjectModule : NinjectModule
    {
        public override void Load()
        {
            RegistroModelos();
        }

        private void RegistroModelos()
        {
            Kernel.Bind<IEndereco>().To<Endereco>();
            Kernel.Bind<IPessoa>().To<Pessoa>();
        }
    }
}

using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ApplicationBuilder;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public class ERPSYSNinjectModule : NinjectModule
    {
        private StandardKernel Kernel { get; set; }

        public ERPSYSNinjectModule(StandardKernel kernel)
        {
            Kernel = kernel;
        }

        public override void Load()
        {
            RegistroModelos(Kernel);
            RegistroDaos(Kernel);
        }

        private static void RegistroModelos(StandardKernel kernel)
        {
            kernel.Bind<IPessoa>().To<Pessoa>();
            kernel.Bind<IEndereco>().To<Endereco>();
        }

        private static void RegistroDaos(StandardKernel kernel)
        {
            kernel.Bind<IPessoaDAO>().To<PessoaDAO>();
        }
        //public static void LoadDependencyInjection(StandardKernel kernel,Func<IContext, object> requestScope)
        //{

        //}
    }
}

using ERPSYS.MVC.Extensions.ApplicationBuilder;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public static class ERPSYSNinjectModule
    {
        public static void LoadDependencyInjection(StandardKernel kernel,Func<IContext, object> requestScope)
        {
            RegistroModelos(kernel, requestScope);
        }

        private static void RegistroModelos(StandardKernel kernel, Func<IContext, object> requestScope)
        {
            kernel.Bind<ITestService>().To<TestService>().InScope(requestScope);
            kernel.Bind<IPessoa>().To<Pessoa>().InScope(requestScope);
            kernel.Bind<IEndereco>().To<Endereco>().InScope(requestScope);
        }
    }
}

using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.Extensions.DependencyInjection;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public static class IoCModule
    {
        public static void LoadDependencyInjection(IServiceCollection service)
        {
            RegistroModelos(service);
        }

        private static void RegistroModelos(IServiceCollection service)
        {
            
        }
    }
}

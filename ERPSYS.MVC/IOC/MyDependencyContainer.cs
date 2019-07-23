using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public interface IDependencyContainer
    {
        void Inject<T>(T instance);
        IBindingToSyntax<T> Rebind<T>();
        void Unload(string callerFilePath);
        T TryGet<T>(IParameter[] parameters);
    }

    public class MyDependencyContainer //: IDependencyContainer
    {
        private IKernel _kernel => new StandardKernel();

        public void Inject<T>(T instance)
        {
            var processor = _kernel.Get<T>();
        }

        //public IBindingToSyntax<T> Rebind<T>()
        //{
        //   // return DependencyContainer.Rebind<T>();
        //}

        public void Unload(string callerFilePath)
        {
            throw new Exception("Unload não suportado pelo DependencyContainerRh.");
        }

        //public T TryGet<T>(IParameter[] parameters)
        //{
        //   // return DependencyContainer.TryGet<T>(parameters);
        //}
    }
}

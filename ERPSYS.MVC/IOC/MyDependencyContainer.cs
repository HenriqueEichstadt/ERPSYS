using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Syntax;
using System;

namespace ERPSYS.MVC.IOC
{
    internal static class MyDependencyContainer
    {
        public static IKernel Kernel { get; set; }

        public static void LoadModule(INinjectModule module)
        {
            ModuleLoadExtensions.Load(Kernel, (INinjectModule[])new INinjectModule[1]
            {
            module
            });
        }

        public static T Get<T>()
        {
            return ResolutionExtensions.Get<T>(Kernel, Array.Empty<IParameter>());
        }

        public static T Get<T>(params IParameter[] parameters)
        {
            return ResolutionExtensions.Get<T>(Kernel, parameters);
        }

        public static object Get(Type type)
        {
            return ResolutionExtensions.Get(Kernel, type, Array.Empty<IParameter>());
        }

        public static object Get(Type type, params IParameter[] parameters)
        {
            return ResolutionExtensions.Get(Kernel, type, parameters);
        }

        public static T TryGet<T>()
        {
            return ResolutionExtensions.TryGet<T>(Kernel, Array.Empty<IParameter>());
        }

        public static T TryGet<T>(params IParameter[] parameters)
        {
            return ResolutionExtensions.Get<T>(Kernel, parameters);
        }

        public static object TryGet(Type type)
        {
            return ResolutionExtensions.Get(Kernel, type, Array.Empty<IParameter>());
        }

        public static object TryGet(Type type, params IParameter[] parameters)
        {
            return ResolutionExtensions.Get(Kernel, type, parameters);
        }

        public static void Inject(object instance)
        {
            IKernel kernel = Kernel;
            IParameter[] array = (IParameter[])new Parameter[0];
            kernel.Inject(instance, array);
        }

        public static IBindingToSyntax<T> Bind<T>()
        {
            return Kernel.Bind<T>();
        }
    }
}

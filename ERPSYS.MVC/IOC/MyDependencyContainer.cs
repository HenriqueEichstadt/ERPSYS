using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Syntax;
using System;

namespace ERPSYS.MVC.IOC
{
    internal static class MyDependencyContainer
    {
        private static IKernel _kernel = new StandardKernel(Array.Empty<INinjectModule>());

        public static void LoadModule(INinjectModule module)
        {
            ModuleLoadExtensions.Load(_kernel, (INinjectModule[])new INinjectModule[1]
            {
            module
            });
        }

        public static T Get<T>()
        {
            return ResolutionExtensions.Get<T>(_kernel, Array.Empty<IParameter>());
        }

        public static T Get<T>(params IParameter[] parameters)
        {
            return ResolutionExtensions.Get<T>(_kernel, parameters);
        }

        public static object Get(Type type)
        {
            return ResolutionExtensions.Get(_kernel, type, Array.Empty<IParameter>());
        }

        public static object Get(Type type, params IParameter[] parameters)
        {
            return ResolutionExtensions.Get(_kernel, type, parameters);
        }

        public static T TryGet<T>()
        {
            return ResolutionExtensions.TryGet<T>(_kernel, Array.Empty<IParameter>());
        }

        public static T TryGet<T>(params IParameter[] parameters)
        {
            return ResolutionExtensions.Get<T>(_kernel, parameters);
        }

        public static object TryGet(Type type)
        {
            return ResolutionExtensions.Get(_kernel, type, Array.Empty<IParameter>());
        }

        public static object TryGet(Type type, params IParameter[] parameters)
        {
            return ResolutionExtensions.Get(_kernel, type, parameters);
        }

        public static void Inject(object instance)
        {
            IKernel kernel = _kernel;
            IParameter[] array = (IParameter[])new Parameter[0];
            kernel.Inject(instance, array);
        }

        public static IBindingToSyntax<T> Bind<T>()
        {
            return _kernel.Bind<T>();
        }
    }
}

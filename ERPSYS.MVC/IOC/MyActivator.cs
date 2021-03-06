﻿using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public class MyActivator : IMyActivator
    {
        public T CreateInstance<T>()
             where T : class
        {
            return CreateInstance<T>(typeof(T));
        }

        public T CreateInstance<T>(Type tipo)
             where T : class
        {
            var tipoDoCast = typeof(T);
            if (!tipoDoCast.IsAssignableFrom(tipo))
                throw new Exception($"{tipo.Name} não implementa {tipoDoCast.Name}");

            return (T)CreateInstance(tipo);
        }

        public object CreateInstance(Type tipo)
        {
            if (!tipo.Namespace.StartsWith("ERPSYS"))
                throw new Exception($"{tipo.Name} não pertence ao sistema ERPSYS");

            object result = null;
            if (TipoValidoParaInstanciar(tipo))
            {
                result = GetInstanceFromActivator(tipo);
                MyDependencyContainer.Inject(result);
            }
            return result;
        }

        private bool TipoValidoParaInstanciar(Type tipo)
        {
            var result = tipo.IsClass;
            result = result && !tipo.IsInterface;
            result = result && !tipo.IsAbstract;
            result = result && !tipo.IsGenericTypeDefinition;
            return result;
        }

        private object GetInstanceFromActivator(Type tipo)
        {
            return Activator.CreateInstance(tipo);
        }

        public T CreateInstance<T, U>()
            where U : class, T
            where T : class
        {
            return CreateInstance<T>(typeof(U));
        }
    }
}

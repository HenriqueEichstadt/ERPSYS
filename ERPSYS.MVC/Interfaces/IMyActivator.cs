using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IMyActivator
    {
        T CreateInstance<T>() where T : class;
        T CreateInstance<T>(Type tipo) where T : class;
        object CreateInstance(Type tipo);
        T CreateInstance<T, U>() where U : class, T
            where T : class;
    }
}

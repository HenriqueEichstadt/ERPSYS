using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Common.Interfaces
{
    public interface IEntityValidationResultFactory
    {
        void NewResult(string message);
        string GetValidationMessage();
    }
}

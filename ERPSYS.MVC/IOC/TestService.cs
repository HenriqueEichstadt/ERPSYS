using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.IOC
{
    public interface ITestService
    {
        string GetData();
    }

    public class TestService : ITestService
    {
        public string GetData()
        {
            return "some magic string";
        }
    }
}

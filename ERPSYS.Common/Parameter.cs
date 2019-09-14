using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.Common
{
    public class Parameter
    {
        public string Param { get; set; }
        public void Add(string parameter, object value)
        {
            Param = parameter;
        }

    }
}

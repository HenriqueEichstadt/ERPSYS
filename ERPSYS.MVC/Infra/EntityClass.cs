using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Infra
{
    [DataContract]
    public class EntityClass
    {
        [DataMember]
        public int Id { get; set; }
    }
}

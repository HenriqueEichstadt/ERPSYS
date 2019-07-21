using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    [DataContract]
    public class EntityModel
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public DateTime DataInclusao { get; set; }

        [DataMember]
        public DateTime DataAlteracao { get; set; }

        [DataMember]
        public Usuario UsuarioInclusao { get; set; }

        [DataMember]
        public Usuario UsuarioAlteracao { get; set; }
    }
}

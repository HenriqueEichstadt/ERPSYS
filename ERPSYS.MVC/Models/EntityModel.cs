using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    [DataContract]
    public class EntityModel
    {
        [DataMember]
        [Column("ID")]
        public int Id { get; set; }

        [DataMember]
        [Column("DATAINCLUSAO")]
        [DataType(DataType.DateTime)]
        public DateTime DataInclusao { get; set; }

        [DataMember]
        [Column("DATAALTERACAO")]
        [DataType(DataType.DateTime)]
        public DateTime? DataAlteracao { get; set; }

        [DataMember]
        [NotMapped] public Usuario UsuarioInclusao { get; set; }

        [DataMember]
        [Column("USUARIOINCLUSAO")]
        public int? UsuarioInclusaoId { get; set; }

        [DataMember]
        [NotMapped] public Usuario UsuarioAlteracao { get; set; }

        [DataMember]
        [Column("USUARIOALTERACAO")]
        public int? UsuarioAlteracaoId { get; set; }
    }
}

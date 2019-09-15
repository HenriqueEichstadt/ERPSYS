using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class EntityModel
    {
        
        [Column("ID")]
        public int Id { get; set; }
        
        [Column("DATAINCLUSAO")]
        [DataType(DataType.DateTime)]
        public DateTime DataInclusao { get; set; }
        
        [Column("DATAALTERACAO")]
        [DataType(DataType.DateTime)]
        public DateTime? DataAlteracao { get; set; }
        
        [NotMapped] public Usuario UsuarioInclusao { get; set; }
        
        [Column("USUARIOINCLUSAO")]
        public int? UsuarioInclusaoId { get; set; }
        
        [NotMapped] public Usuario UsuarioAlteracao { get; set; }
        
        [Column("USUARIOALTERACAO")]
        public int? UsuarioAlteracaoId { get; set; }
    }
}

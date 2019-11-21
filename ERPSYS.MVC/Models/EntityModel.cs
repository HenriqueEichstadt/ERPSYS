using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO.Interfaces;

namespace ERPSYS.MVC.Models
{
    public class EntityModel<T> : IEntityModel<T>
    {
        
        [Column(FieldNames.Id)]
        public int Id { get; set; }
        
        [Column(FieldNames.DataInclusao)]
        [DataType(DataType.DateTime)]
        public DateTime DataInclusao { get; set; }
        
        [Column(FieldNames.DataAlteracao)]
        [DataType(DataType.DateTime)]
        public DateTime? DataAlteracao { get; set; }
        
        [NotMapped] public Usuario UsuarioInclusao { get; set; }
        
        [Column(FieldNames.UsuarioInclusao)]
        public int? UsuarioInclusaoId { get; set; }
        
        [NotMapped] public Usuario UsuarioAlteracao { get; set; }
        
        [Column(FieldNames.UsuarioAlteracao)]
        public int? UsuarioAlteracaoId { get; set; }

        public T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        public partial class FieldNames
        {
            public const string Id = "ID";
            public const string DataInclusao = "DATAINCLUSAO";
            public const string DataAlteracao = "DATAALTERACAO";
            public const string UsuarioInclusao = "USUARIOINCLUSAO";
            public const string UsuarioInclusaoId = "USUARIOINCLUSAOID";
            public const string UsuarioAlteracao = "USUARIOALTERACAO";
            public const string UsuarioAlteracaoId = "USUARIOALTERACAOID";
        }
    }
}

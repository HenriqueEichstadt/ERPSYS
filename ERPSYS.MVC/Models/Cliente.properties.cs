using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Cliente : EntityModel, ICliente
    {
        public Pessoa Pessoa { get; set; }

        public int? Pontos { get; set; }

        public bool Ativo { get; set; }
    }
}

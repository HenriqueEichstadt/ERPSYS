using ERPSYS.MVC.Common.Interfaces;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.IOC;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Cliente
    {
        //[Inject] public IUsuarioDAO UsuarioDao { get; set; }
        [Inject] public IEntityValidationResultFactory EntityValidationResult { get; set; }
        public void AtribuirDados()
        {
            Ativo = true;
            Pontos = 0;
            UsuarioInclusaoId = (new UsuarioDAO().GetById(Startup.UserSession.Id) as Usuario).Id;
            DataInclusao = DateTime.Now;
            Pessoa.AtribuirDados('F');
        }

        public string Validade()
        {
            if(!Validacoes.ValidaCpf(Pessoa.CPFCNPJ))
            {
                EntityValidationResult.NewResult(" O CPF informado não é válido! ");
            }

            return EntityValidationResult.GetValidationMessage();
        }
    }
}

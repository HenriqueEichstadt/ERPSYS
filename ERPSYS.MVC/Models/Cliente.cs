using ERPSYS.MVC.Common.Interfaces;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.IOC;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.Common;

namespace ERPSYS.MVC.Models
{
    public partial class Cliente
    {
        public void AtribuirDados()
        {
            Ativo = true;
            Pontos = 0;
            UsuarioInclusaoId = new UsuarioDAO().GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
            Pessoa.AtribuirDados('F');
        }

        public string Valida()
        {
            var validationResult = new EntityValidationResultFactory();
            if (Validacoes.ValidaCpf(Pessoa.CPFCNPJ))
                validationResult.NewResult("CPF inválido");
            if(Validacoes.ValidaEmail(Pessoa.Email))
                validationResult.NewResult("Email inválido");



            return validationResult.GetValidationMessage();
        }
    }
}

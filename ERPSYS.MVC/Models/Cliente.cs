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

namespace ERPSYS.MVC.Models
{
    public partial class Cliente
    {
        [Inject] public IMyActivator MyActivator { get; set; }
        [Inject] public IEntityValidationResultFactory EntityValidationResult { get; set; }
        public void AtribuirDados()
        {
            Ativo = true;
            Pontos = 0;
            var usuarioDao = MyActivator.CreateInstance<IUsuarioDAO, UsuarioDAO>();
            UsuarioInclusaoId = usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
            Pessoa.AtribuirDados('F');
        }

        public string Validade()
        {
            if(!Validacoes.ValidaCpf(Pessoa.CPFCNPJ))
            {
                EntityValidationResult.NewResult(" O CPF informado não é válido!");
            }

            return EntityValidationResult.GetValidationMessage();
        }
    }
}

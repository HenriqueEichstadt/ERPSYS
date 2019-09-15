using ERPSYS.MVC.DAO;
using System;
using ERPSYS.Common;

namespace ERPSYS.MVC.Models
{
    public partial class Cliente
    {
        private UsuarioDAO _usuarioDao = new UsuarioDAO();
        
        public void AtribuirDadosInclusao()
        {
            Ativo = true;
            Pontos = 0;
            UsuarioInclusaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
            Pessoa.AtribuirDadosInclusao('F');
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

        public void AtribuirDadosAlteracao()
        {
            DataAlteracao = DateTime.Now;
            UsuarioAlteracaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            Pessoa.AtribuirDadosAlteracao();
        }
    }
}

using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.IOC;
using Ninject;
using System;

namespace ERPSYS.MVC.Models
{
    public partial class Pessoa
    {
        private UsuarioDAO _usuarioDao = new UsuarioDAO();
        
        public void AtribuirDadosInclusao(char tipoPessoa)
        {
            switch (tipoPessoa)
            {
                case 'F':
                    AtribuirPessoaFisica();
                    break;
                case 'J':
                    AtribuirPessoaJuridica();
                    break;
            }
        }

        public int GetIdade(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
        private void AtribuirPessoaFisica()
        {
            Ativo = true;
            UsuarioInclusaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
            TipoPessoa = 'F';
            Endereco.AtribuirDados();
        }
        private void AtribuirPessoaJuridica()
        {
            Ativo = true;
            UsuarioInclusaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataInclusao = DateTime.Now;
            TipoPessoa = 'J';
            Endereco.AtribuirDados();
        }

        public void AtribuirDadosAlteracao()
        {
            UsuarioAlteracaoId = _usuarioDao.GetById(Startup.UserSession.Id).Id;
            DataAlteracao = DateTime.Now;
        }
    }
}
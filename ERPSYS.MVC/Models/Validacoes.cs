using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public static class Validacoes
    {
        #region Validacao de CPF
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf == null || string.IsNullOrEmpty(cpf))
            {
                return false;
            }
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        #endregion

        #region Validacao de CNPJ
        public static bool ValidaCnpj(string cnpj)
        {
            if (cnpj == null || string.IsNullOrEmpty(cnpj))
            {
                return false;
            }
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        #endregion

        #region Validacao de Idade
        public static bool ValidaIdade(DateTime nascimento)
        {
            Pessoa pessoa = new Pessoa();
            var idade = pessoa.GetIdade(nascimento);
            if (idade < 18 || idade > 150)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de Nome Fantasia
        public static bool ValidaNomeFantasia(string nomeFantasia)
        {
            if (nomeFantasia == null || nomeFantasia.Length < 5 && nomeFantasia.Length > 50 || string.IsNullOrEmpty(nomeFantasia))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de Inscricao estadual
        public static bool ValidaInscricaoEstadual(string inscricaoEstadual)
        {
            if (inscricaoEstadual == null || inscricaoEstadual.Length < 8 && inscricaoEstadual.Length > 10 || string.IsNullOrEmpty(inscricaoEstadual))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de Nome Razao Social
        public static bool ValidaNomeRazaoSocial(string nomeRazaoSocial)
        {
            if (nomeRazaoSocial == null || nomeRazaoSocial.Length < 5 && nomeRazaoSocial.Length > 50 || string.IsNullOrEmpty(nomeRazaoSocial))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de Telefone 1
        public static bool ValidaTelefoneUm(string telefone)
        {
            if (telefone == null || telefone.Length < 13 && telefone.Length > 14 || string.IsNullOrEmpty(telefone))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de Telefone 2
        public static bool ValidaTelefoneDois(string telefone)
        {
            if (telefone == null || telefone.Length > 12 && telefone.Length < 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Validacao de Email
        public static bool ValidaEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Validacao de Nome Obrigatório (para Cliente e Funcionário)
        public static bool ValidaNomeFornecedor(string nome)
        {
            if (nome == null || nome.Length > 4 && nome.Length < 51 || string.IsNullOrEmpty(nome))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Validacao de Nome Opcional (para Fornecedor)
        public static bool ValidaNomePessoa(string nome)
        {
            if (nome == null || nome.Length < 5 && nome.Length > 50 || string.IsNullOrEmpty(nome))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Validacao de RG
        public static bool ValidaRg(string rg)
        {
            if (rg == null || rg.Length < 5 && rg.Length > 15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        #endregion
    }
}

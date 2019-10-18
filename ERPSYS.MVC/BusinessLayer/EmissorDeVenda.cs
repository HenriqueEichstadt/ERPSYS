using System;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Ninject;

namespace ERPSYS.MVC.BusinessLayer
{
    public class EmissorDeVenda : IEmissorDeVenda
    {
        private const int PontosProgramaFidelidade = 100;
        [Inject] public IVendaDAO VendaDao { get; set; }
        public const string mensagemVenda = "Venda efetuada com sucesso";

        public string EmitirVenda(Venda venda)
        {
            if (venda.ClienteId == null)
            {
                VendaDao.GravarVenda(venda);
                return mensagemVenda;
            }
                 
            else
                return EmitirVendaComCliente(venda);
        }

        private string EmitirVendaComCliente(Venda venda)
        {
            var msg = string.Empty;
            switch (venda.FormaPagamento)
            {
                case 1:
                case 2:
                    msg = VendaComAtribuicaoDePontosProgFidelidade(venda);
                    break;
                case 3:
                    VendaDao.GravarVenda(venda);
                    msg = mensagemVenda;
                    break;
                case 4:
                    msg = VendaNaTrocaPorPontosProgFidelidade(venda);
                    break;
            }

            return msg;
        }

        private string VendaNaTrocaPorPontosProgFidelidade(Venda venda)
        {
            VendaDao.GravarVenda(venda);
            var trocaPontos = (int)(venda.PrecoTotal * PontosProgramaFidelidade);
            VendaDao.TrocaPorPontos(venda.ClienteId ?? 0, trocaPontos);
            return "Troca por pontos efetuada com sucesso";
        }

        private string VendaComAtribuicaoDePontosProgFidelidade(Venda venda)
        {
            VendaDao.GravarVenda(venda);
            var qtdPontos = (int)(venda.PrecoTotal);
            VendaDao.SomaPontos(venda.ClienteId ?? 0, qtdPontos);
            return $"{mensagemVenda}, o cliente somou {qtdPontos} pontos para o programa de fidelidade";
        }
    }
}
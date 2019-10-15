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

        public void EmitirVenda(Venda venda)
        {
            if (venda.ClienteId == null)
                VendaDao.GravarVenda(venda);
            else
                EmitirVendaComCliente(venda);
        }

        private void EmitirVendaComCliente(Venda venda)
        {
            switch (venda.FormaPagamento)
            {
                case 1:
                case 2:
                    VendaComAtribuicaoDePontosProgFidelidade(venda);
                    break;
                case 3:
                    VendaDao.GravarVenda(venda);
                    break;
                case 4:
                    VendaNaTrocaPorPontosProgFidelidade(venda);
                    break;
            }
        }

        private void VendaNaTrocaPorPontosProgFidelidade(Venda venda)
        {
            VendaDao.GravarVenda(venda);
            var trocaPontos = (int)(venda.PrecoTotal * PontosProgramaFidelidade);
            VendaDao.TrocaPorPontos(venda.ClienteId ?? 0, trocaPontos);
        }

        private void VendaComAtribuicaoDePontosProgFidelidade(Venda venda)
        {
            VendaDao.GravarVenda(venda);
            var qtdPontos = (int)(venda.PrecoTotal);
            VendaDao.SomaPontos(venda.ClienteId ?? 0, qtdPontos);
        }
    }
}
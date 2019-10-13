using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.Interfaces
{
    public interface IEmissorDeVenda
    {
        void EmitirVenda(Venda venda);
    }
}
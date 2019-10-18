using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.Interfaces
{
    public interface IEmissorDeVenda
    {
        string EmitirVenda(Venda venda);
    }
}
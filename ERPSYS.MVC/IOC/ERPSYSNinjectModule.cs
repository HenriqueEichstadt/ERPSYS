using ERPSYS.Common;
using ERPSYS.MVC.Common.Interfaces;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Ninject;
using Ninject.Modules;

namespace ERPSYS.MVC.IOC
{
    public class ERPSYSNinjectModule : NinjectModule
    {
        private StandardKernel _kernel;

        public ERPSYSNinjectModule(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public override void Load()
        {
            RegistroIoC(_kernel);
            RegistroComuns(_kernel);
            RegistroModelos(_kernel);
            RegistroDaos(_kernel);
            
        }

        private void RegistroIoC(StandardKernel kernel)
        {
            kernel.Bind<IMyActivator>().To<MyActivator>();
        }

        private static void RegistroModelos(StandardKernel kernel)
        {
            kernel.Bind<IPessoa>().To<Pessoa>();
            kernel.Bind<IEndereco>().To<Endereco>();
            kernel.Bind<IUsuario>().To<Usuario>();
            kernel.Bind<ICliente>().To<Cliente>();
            kernel.Bind<IProduto>().To<Produto>();
            kernel.Bind<IVenda>().To<Venda>();
            kernel.Bind<IVendaItens>().To<VendaItens>();
        }

        private static void RegistroDaos(StandardKernel kernel)
        {
            kernel.Bind<IPessoaDAO>().To<PessoaDAO>();
            kernel.Bind<IUsuarioDAO>().To<UsuarioDAO>();
            kernel.Bind<IClienteDAO>().To<ClienteDAO>();
        }

        private void RegistroComuns(StandardKernel kernel)
        {
            kernel.Bind<IEntityValidationResultFactory>().To<EntityValidationResultFactory>();
        }
    }
}

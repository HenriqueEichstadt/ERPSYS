using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.Infra;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ERPSYS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Chamando o método que Gera ou atualiza as tabelas do banco de dados
            NHibernateHelper.GerarOuAtualizarTabelas();
            // Iniciando o Host Web
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

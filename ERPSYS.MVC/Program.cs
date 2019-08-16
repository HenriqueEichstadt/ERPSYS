﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ninject;

namespace ERPSYS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Iniciando o Host Web
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

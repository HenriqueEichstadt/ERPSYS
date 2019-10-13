using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Extensions.ApplicationBuilder;
using ERPSYS.MVC.Extensions.AspNetCore;
using ERPSYS.MVC.Filters;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.IOC;
using ERPSYS.MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;

namespace ERPSYS
{
    public class Startup
    {
        private readonly AsyncLocal<Scope> scopeProvider = new AsyncLocal<Scope>();
        private IKernel Kernel { get; set; }
        private object Resolve(Type type) => Kernel.Get(type);
        private object RequestScope(IContext context) => scopeProvider.Value;

        public static string ConnectionString { get; private set; }
        public static ISession Session { get; set; }
        public static IUsuario UserSession { get; set; }

        private sealed class Scope : DisposableObject { }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddSession();
            
            services.AddMvc(options =>
                {
                    options.Filters.Add(new AuthenticationFilterAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddSessionStateTempDataProvider();
            
            // Registrar Connection String para acesso ao banco de dados
            ConnectionString = Configuration.GetConnectionString("Default");
            
            services.ConfigureApplicationCookie(options => options.LoginPath = "/login");
            // Registrar as Injeções de dependências
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<DbContext, ApplicationContext>();
            services.AddTransient(typeof(BaseDAO<>), typeof(BaseDAO<>));
            services.AddTransient(typeof(ApplicationContext));
            services.AddTransient(typeof(DbContextOptions<ApplicationContext>));
            services.AddRequestScopingMiddleware(() => scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);
        }

        private void CriaUsuarioPrincipalNoSistema()
        {
            var usuarioDao = new UsuarioDAO();
            var usuario = new Usuario
            {
                Nome = "Administrador",
                Email = "administrador@adm.com",
                Apelido = "admin",
                Senha = "admin",
                DataInclusao = DateTime.Now,
                NivelAcesso = 'A'
            };
            // Criar o usuário principal do sistema
            if (!usuarioDao.IsUsuarioCadastrado(usuario.Apelido))                    
                usuarioDao.Add(usuario);
        }

        private IKernel RegisterApplicationComponents(IApplicationBuilder app)
        {
            // IKernelConfiguration config = new KernelConfiguration();
            var kernel = new StandardKernel();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            // This is where our bindings are configurated


            // ERPSYSNinjectModule.LoadDependencyInjection(kernel, RequestScope); tentativa antiga

            var module = new ERPSYSNinjectModule(kernel);
            module.Load();
            // Cross-wire required framework services
            kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);

            return kernel;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Kernel = RegisterApplicationComponents(app);
            MyDependencyContainer.Kernel = this.Kernel;
            CriaUsuarioPrincipalNoSistema();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}

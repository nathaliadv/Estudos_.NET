using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo_v2.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CasaDoCodigo_v2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Responsável por manter as informações na memória enquanto vamos navegando.- cache.
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(connectionString)
            );

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Aqui os serviços adicionados acima são consumidos.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
            });

            //Cria o banco de dados e seus objetos (tabelas, campos, indices, etc) quando a aplicação for iniciada, utilizando migrações para isso.
            //Vai gerar uma instancia nova do ApplicationContext.
            //O ASP.NET reconhece o parâmetro serviceProvider através de uma técnica chamada de injeção de dependência.
            //Ela é utilizada para criar uma instância a partir da definição de parâmetros do tipo interface. Ou seja, podemos deifinir uma interface, dizer que ela gerará uma instância de uma determinada classe, e então injetar, inserindo parâmetros para riação das novas instâncias.
            serviceProvider.GetService<IDataService>().InicializaDB();
        }
    }
}

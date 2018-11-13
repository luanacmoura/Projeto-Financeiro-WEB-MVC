using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto_Financeiro_WEB_MVC {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            //Adicionamos
            services.AddMvc ();

            //Para trabalhar com autenticação
            services.AddDistributedMemoryCache();
            services.AddSession(
                options => options.IdleTimeout=TimeSpan.FromMinutes(10) //Definindo que após 10 minutos, ele desloga(tempo limite)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            //a p a g a r
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

            app.UseSession(); //Tem que vir primeiro que o mvc

            app.UseStaticFiles();
            
            //Vamos utilizar
            app.UseMvc (
                //Definimos a rota default (a aplicação vai iniciar nessa rota, ou seja na página de cadastro)
                rota => rota.MapRoute(
                    name:"default",
                    template: "{controller=Usuario}/{action=Login}"
                )
            );

           

        }
    }
}
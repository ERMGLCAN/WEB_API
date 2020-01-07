using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApiFunnyPlace
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "WebApi Funny Place"
                   ,
                    Version = "1.0"
                   ,
                    Description = "API PARA ANGULAR CON SWAGGER V 5.0"


                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(configUI => {
                configUI.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Angular API by Marin´s");                
            });
            //ESTO NO PUEDE SER EN UN AMBIENTE DE PRODUCCION JAMAS, 
            // SE PUEDE CONFIGURAR POR IPS, METODOS ETC, PERO JAMAS ABRIR TODAS LAS PUERTAS POR SEGURIDAD DE API WEB
            app.UseCors(options => {

                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();

            });
            app.UseMvc();
        }
    }
}

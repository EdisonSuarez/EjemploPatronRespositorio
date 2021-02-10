using Deloitte.Domain;
using Deloitte.Services;
using Deloitte.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.RepositoryPattern
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
            services.AddControllers();
            // cada que se usa Iusers o isuerrespotory se indica que clase se va a instanciar y ademas se agrega como parametro la conexion
            //services.AddSingleton<IUsers>(x => new UserService(Configuration.GetConnectionString("Connection")));

            // Cuando uso Iusers, estoy creando una "instancia" a la clase userServices y sus metodos.
            services.AddScoped<IUsers, UserService>();
            //Cuando Uso IuserRepository, estoy creando una "instancia" de la clase User repository y ademas estoy creando el parametro de la cadena de conexion.
            services.AddSingleton<IUserRepository>(x => new UserRepository(Configuration.GetConnectionString("Connection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace TransporteBusesApp.Servicios
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
            AddSwagger(services);

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

            app.UseSwagger();
            app.UseSwaggerUI( c =>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Foo API V1");
                
            });
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
            
        }

        //Metodo que agrega los servicios de swagger
        public void AddSwagger(IServiceCollection services){
            services.AddSwaggerGen(options =>{
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {

                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "FOO API",
                    Contact = new OpenApiContact{
                        Name = "Foo Company",
                        Email = "company@test.co",
                        Url = new Uri("https://foo.com")
                    }

            });
            });
        }
    }
}

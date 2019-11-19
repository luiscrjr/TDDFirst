using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Services.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Services
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
            //injeção de dependência para a classe ProdutoRepository.cs
            services.AddSingleton<ProdutoRepository>
                (map => new ProdutoRepository(new ConcurrentDictionary<Guid, Produto>()));

            //configurando oa automapper
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "API de controle de Produtos",
                            Version = "v1",
                            Description = "Projeto desenvolvido usando TDD"
                        });
                }
                );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                }
                );

            app.UseMvc();
        }
    }
}

using Application.Interfaces;
using Application.Services;
using Data.Configuration;
using Data.Repository;
using Data.Repository.Generic;
using Domain.Interfaces;
using Domain.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;

namespace Api
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
            var x = Configuration.GetConnectionString("Conn");
            services.AddDbContext<DbContext>(opt => opt.UseInMemoryDatabase("StefaniniDb"));
            services.AddScoped<Data.Configuration.Context, Data.Configuration.Context>();


            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IPessoa, PessoaRepository>();
            services.AddSingleton<INterfacePessoa, PessoaServices>();

            services.AddControllers();

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Stefanini Teste",
                        Version = "v1",
                        Description = "Exemplo básico de API REST criada com o ASP.NET Core com banco de dados na memroia",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Vitorino Neto",
                            Url = new Uri("https://github.com/vitorinomenezes", UriKind.Absolute)
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Stefanini V1");
            });

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

using Api_Restful.AccesData;
using Api_Restful.AccesData.Command;
using Api_Restful.AccesData.Command.Repository;
using Api_Restful.AccesData.Queries;
using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Application.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

namespace Api_Restful
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
            var connectionString = Configuration.GetSection("connectionString").Value;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IMercaderiaQuery, MercaderiaQuery>();
            services.AddTransient<IMercaderiaService, MercaderiaService>();
            services.AddTransient<IComandaQuery, ComandaQuery>();
            services.AddTransient<IComandaService, ComandaService>();
            services.AddTransient<IcomandaMercaderiaService, ComandaMercaderiaService>();
            services.AddTransient<ITipoMercaderiaService, TipoMercaderiaService>();
            services.AddTransient<ITipoMercaderiaQuery, TipoMercaderiaQuery>();
            services.AddTransient<IFormaEntregaService, FormaEntregaService>();
            services.AddTransient<IFormaEntregaQuery, FormaEntregaQuery>(); 

            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tp2 Api_Restful", Version = "v1" , Description = "Primer cuatrimestre 2021"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_Restful v1"));
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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

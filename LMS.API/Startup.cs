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
using LMS.API;
using LMS.Core.Interfaces;
using LMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using LMS.Infrastructure.Data;
using AutoMapper;
using LMS.Core.Services;
namespace LMS.API
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
            //agregar mapeadores
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //cadena de conexion en appsettings.json
            var conex = Configuration.GetConnectionString("lmsDB");
            //Conexion a SQL Server
            services.AddDbContext<LMS2Context>(options => options.UseSqlServer(conex));
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<ITemaService, TemaService>();
            services.AddTransient<ITemaRepository, TemaRepository>();

            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IRolRepository, RolRepository>();

            services.AddTransient<IParametroService, ParametroService>();
            services.AddTransient<IParametroRepository, ParametroRepository>();

            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();

            services.AddTransient<IInscripcionService, InscripcionService>();
            services.AddTransient<IInscripcionRepository, InscripcionRepository>();

            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IEstudianteRepository, EstudianteRepository>();

            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<ICursoRepository, CursoRepository>();

            services.AddTransient<IControlasistenciaService, ControlasistenciaService>();
            services.AddTransient<IControlasistenciaRepository, ControlasistenciaRepository>();

            services.AddTransient<ICalificacionService, CalificacionService>();
            services.AddTransient<ICalificacionRepository, CalificacionRepository>();

            services.AddTransient<IAdjuntoService, AdjuntoService>();
            services.AddTransient<IAdjuntoRepository, AdjuntoRepository>();

            services.AddTransient<IActividadService, ActividadService>();
            services.AddTransient<IActividadRepository, ActividadRepository>();



            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
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

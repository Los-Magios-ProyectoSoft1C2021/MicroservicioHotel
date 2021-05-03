using AutoMapper;
using MicroservicioHotel.AccessData;
using MicroservicioHotel.AccessData.Commands;
using MicroservicioHotel.AccessData.Queries;
using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.Mapper;
using MicroservicioHotel.Domain.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Template.API
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

            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new HotelProfile());
                mc.AddProfile(new HabitacionProfile());
                mc.AddProfile(new FotoHotelProfile());
                mc.AddProfile(new CategoriaProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Configuration busca diferentes opciones en appsettings.json; en este caso, le pedimos
            // el valor de la clave ConnectionString
            string connectionString = Configuration.GetSection("ConnectionString").Value;

            // Una vez que tenemos el string para conectarnos a la BD, se lo pasamos el método UseSqlServer()
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IGenericsRepository, GenericsRepository>();

            services.AddTransient<IHotelQuery, HotelQuery>();
            services.AddTransient<IHabitacionQuery, HabitacionQuery>();
            services.AddTransient<IFotoHotelQuery, FotoHotelQuery>();
            services.AddTransient<ICategoriaQuery, CategoriaQuery>();

            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IHabitacionService, HabitacionService>();
            services.AddTransient<IFotosService, FotosService>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Hotel API",
                        Description = "Swagger para Hotel API de Booking UNAJ",
                        Version = "v1"
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel API");
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

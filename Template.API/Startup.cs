using AutoMapper;
using FluentValidation.AspNetCore;
using MicroservicioHotel.AccessData;
using MicroservicioHotel.AccessData.Commands;
using MicroservicioHotel.AccessData.Queries;
using MicroservicioHotel.Application.HttpService;
using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.Mapper;
using MicroservicioHotel.Domain.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;
using System.Text;

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
            services
                .AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireClaim("Rol", "Admin"));

                options.AddPolicy("UsuarioOnly", policy =>
                    policy.RequireClaim("Rol", "Usuario"));
            });

            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new HotelProfile());
                mc.AddProfile(new HabitacionProfile());
                mc.AddProfile(new FotoHotelProfile());
                mc.AddProfile(new CategoriaProfile());
                mc.AddProfile(new JsonPatchDocumentProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Configuration busca diferentes opciones en appsettings.json; en este caso, le pedimos
            // el valor de la clave ConnectionString
            string connectionString = Configuration.GetSection("ConnectionString").Value;

            // Una vez que tenemos el string para conectarnos a la BD, se lo pasamos el m?todo UseSqlServer()
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IGenericsRepository, GenericsRepository>();

            services.AddTransient<IHotelQuery, HotelQuery>();
            services.AddTransient<IHabitacionQuery, HabitacionQuery>();
            services.AddTransient<IFotoHotelQuery, FotoHotelQuery>();
            services.AddTransient<ICategoriaQuery, CategoriaQuery>();
            services.AddTransient<IDestinoQuery, DestinoQuery>();

            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IHabitacionService, HabitacionService>();
            services.AddTransient<IFotosService, FotosService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IDestinoService, DestinoService>();

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

            services.AddCors(c => c.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddHttpClient<MicroservicioReservaService>();
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

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

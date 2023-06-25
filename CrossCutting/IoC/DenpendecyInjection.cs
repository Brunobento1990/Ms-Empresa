using Application.Interfaces;
using Application.Services;
using Application.Token;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace CrossCutting.IoC
{
    public static class DenpendecyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdicionarEmpresaService, AdicionarEmpresaService>();
            services.AddScoped<ILoginFuncionarioService, LoginFuncionarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<ICargoFuncionarioService, CargoFuncionarioService>();
            services.AddScoped<IAdicionarPrimeiroFuncionarioEmpresa, AdicionarPrimeiroFuncionarioEmpresa>();
            services.AddScoped<IGerarTokenService, GerarTokenService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IServicoService, ServicoService>();

            return services;
        }

        public static IServiceCollection AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Mypolicy",
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                          .AllowAnyMethod()
                                          .WithHeaders(
                                              HeaderNames.ContentType,
                                              HeaderNames.Authorization);
                                  });
            });


            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidAudience = configuration["TokenConfiguration:Audience"],
                     ValidIssuer = configuration["TokenConfiguration:Issuer"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                 });

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            ,IConfiguration configuration)
        {

            var connectionString = configuration["ConnectionStrings:Ms-Empresa"];
            services.AddDbContext<MsContext>(opt =>
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                b => b.MigrationsAssembly(typeof(MsContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IHistorioDePagemtosEmpresaRepository, HistorioDePagemtosEmpresaRepository>();
            services.AddScoped<ICargoFuncionarioRepository, CargoFuncionarioRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}

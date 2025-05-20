using DotNet.Repositories;
using DotNet.Repositories.Implementations;
using DotNet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.Extensions
{
    public static class ApplicaitonServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("DotNet.UI")));
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<IStateRepo, StateRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ISkillRepo, SkillRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}

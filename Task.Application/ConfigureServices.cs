using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Task.Application.Common.Models;

namespace Task.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection Addapplication(this IServiceCollection services)
        {
            services.AddScoped<ICsvFileParser, CsvFileParser>();
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}

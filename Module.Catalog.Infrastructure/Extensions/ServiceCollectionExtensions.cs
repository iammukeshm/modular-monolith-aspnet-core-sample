using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Infrastructure.Persistence;
using Shared.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Catalog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<CatalogDbContext>(config)
                .AddScoped<ICatalogDbContext>(provider => provider.GetService<CatalogDbContext>());
            return services;
        }
    }
}

using eCom.Core.RepositoryContract;
using eCom.Infrastructure.DBContext;
using eCom.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Infrastructure;

    public static class DependencyInjection
    {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}


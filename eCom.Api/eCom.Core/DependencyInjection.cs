using eCom.Core.ServiceContracts;
using eCom.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCom.eCom.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserServices, UserService>();

        return services;
    }
}


using DinnerHostingApp.WebApi.Common.Errors;
using DinnerHostingApp.WebApi.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerHostingApp.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, DinnerHostingAppProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}
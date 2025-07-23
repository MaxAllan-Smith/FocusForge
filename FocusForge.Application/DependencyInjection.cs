using FocusForge.Application.Interfaces.MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FocusForge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Assembly assembly)
        {
            services.AddSingleton<IMediator, Mediator>();

            var handlerTypes = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces(), (type, iface) => new { type, iface = iface })
                .Where(x =>
                    x.iface.IsGenericType &&
                    x.iface.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)
                );

            foreach (var registration in handlerTypes)
            {
                services.AddTransient(registration.iface, registration.type);
            }

            return services;
        }
    }
}

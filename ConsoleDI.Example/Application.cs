using ConsoleDI.Example.Lifetimes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConsoleDI.Example;

public static class Application
{
    public static void AddSingletonServices(this IServiceCollection services, Assembly assembly)
    {
        var baseInterface = typeof(ISingletonLifetime);
        var derivedInterfaces = assembly
            .GetTypes()
            .Where(type => type.IsInterface && baseInterface.IsAssignableFrom(type));
        foreach (var derivedInterface in derivedInterfaces)
        {
            var implementationType = Array
                .Find(assembly.GetTypes(), type => !type.IsInterface && !type.IsAbstract && derivedInterface.IsAssignableFrom(type));
            if (implementationType != null)
            {
                services.AddSingleton(derivedInterface, implementationType);
            }
        }
    }

    public static void AddScopedServices(this IServiceCollection services, Assembly assembly)
    {
        var baseInterface = typeof(IScopedLifetime);
        var derivedInterfaces = assembly
            .GetTypes()
            .Where(type => type.IsInterface && baseInterface.IsAssignableFrom(type));
        foreach (var derivedInterface in derivedInterfaces)
        {
            var implementationType = Array
                .Find(assembly.GetTypes(), type => !type.IsInterface && !type.IsAbstract && derivedInterface.IsAssignableFrom(type));
            if (implementationType != null)
            {
                services.AddScoped(derivedInterface, implementationType);
            }
        }
    }

    public static void AddTransistServices(this IServiceCollection services, Assembly assembly)
    {
        var baseInterface = typeof(ITransistLifetime);
        var derivedInterfaces = assembly
            .GetTypes()
            .Where(type => type.IsInterface && baseInterface.IsAssignableFrom(type));
        foreach (var derivedInterface in derivedInterfaces)
        {
            var implementationType = Array
                .Find(assembly.GetTypes(), type => !type.IsInterface && !type.IsAbstract && derivedInterface.IsAssignableFrom(type));
            if (implementationType != null)
            {
                services.AddTransient(derivedInterface, implementationType);
            }
        }
    }
}

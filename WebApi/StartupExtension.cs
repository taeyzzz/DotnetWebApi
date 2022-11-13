using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreApp.Attributes;
using CoreApp.Repositories.Users;
using CoreApp.Services.Users;
using Infrastructure.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public static class StartupExtension
    {
        public static IServiceCollection AutoWireAssembly(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var listAssemblies = assemblies.ToList();
            services.RegisterScoped(listAssemblies);
            services.RegisterTransient(listAssemblies);
            services.RegisterSingleton(listAssemblies);
            return services;
        }

        public static IServiceCollection RegisterSingleton(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var types = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => 
                    t.IsClass 
                    && !t.IsAbstract
                    && !t.IsGenericType 
                    && !t.IsNested 
                    && t.GetCustomAttribute<RegisterSingleton>() != null);
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var itf in interfaces)
                {
                    services.AddSingleton(itf, type);
                }
            }
            return services;
        }
        
        public static IServiceCollection RegisterTransient(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var types = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => 
                    t.IsClass 
                    && !t.IsAbstract
                    && !t.IsGenericType 
                    && !t.IsNested 
                    && t.GetCustomAttribute<RegisterTransient>() != null);
            foreach (var type in types)
            {
                services.AddTransient(type);
            }
            return services;
        }
        
        public static IServiceCollection RegisterScoped(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var types = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => 
                    t.IsClass 
                    && !t.IsAbstract
                    && !t.IsGenericType 
                    && !t.IsNested 
                    && t.GetCustomAttribute<RegisterScoped>() != null);
            foreach (var type in types)
            {
                services.AddScoped(type);
            }
            return services;
        } 
    }
}
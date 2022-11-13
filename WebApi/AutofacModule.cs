using System.Reflection;
using Autofac;
using CoreApp.Attributes;
using Module = Autofac.Module;

namespace WebApi
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[]
            {
                Assembly.GetAssembly(typeof(Startup)),
                Assembly.GetAssembly(typeof(CoreApp.Assembly)),
                Assembly.GetAssembly(typeof(Infrastructure.Assembly))
            }).Where(t => 
                t.IsClass 
                && !t.IsAbstract
                && !t.IsGenericType 
                && !t.IsNested 
                && t.GetCustomAttribute<RegisterSingleton>() != null)
                .AsImplementedInterfaces();
        }
    }
}
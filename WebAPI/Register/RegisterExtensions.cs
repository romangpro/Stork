using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace WebAPI.Register
{
    public static class RegisterExtensions
    {
        public static (Type Type, Type RegisterInterface) GetGenericInterfaceImplementor(this Type t, Type target)
        {
            var tuples = t.GetInterfaces().Select(i => (i, i.IsGenericType ? i.GetGenericTypeDefinition() : i));
            return (t, tuples.FirstOrDefault(x => x.Item2 == target).i);
        }

        public static void RegisterAllTypes<T>(this IServiceCollection services, string namespace2 = null, Assembly[] assemblies = null, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            assemblies ??= new[] { Assembly.GetExecutingAssembly() };
            var t = typeof(T);
            var types = assemblies.SelectMany(a => a.ExportedTypes.Where(x => t.IsAssignableFrom(x) && !x.IsAbstract));
            
            if (namespace2 != null)
                types = types.Where(x => x.Namespace.Contains(namespace2));
            
            foreach (var type in types)
                services.Add(new ServiceDescriptor(t, type, lifetime));
        }

        //need to support registering all OPEN generic
        public static void RegisterAllTypes(this IServiceCollection services, Type t, string namespace2 = null, Assembly[] assemblies = null, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (t == null)
                throw new ArgumentNullException("type cannot be null");

            assemblies ??= new[] { Assembly.GetExecutingAssembly() };

            var types = assemblies.SelectMany(a => a.ExportedTypes.Select(x => x.GetGenericInterfaceImplementor(t))).Where(x => x.RegisterInterface != null);

            if (namespace2 != null)
                types = types.Where(x => x.Type.Namespace.Contains(namespace2));

            foreach (var kvp in types)
                services.Add(new ServiceDescriptor(kvp.RegisterInterface, kvp.Type, lifetime));
        }

        // using microsoft DI, avoid implementing multiple interface, because each registration of singleton, will have different instance.
        //services.AddSingleton<IFoo, Foo>(); //multiple
        //services.AddSingleton<IFoo>(foo); //single instance
        //generic open type
        //serviceCollection.AddSingleton(typeof(IThing<>), typeof(GenericThing<>));

        //public static void UseOneTransactionPerHttpCall(this IServiceCollection serviceCollection, IsolationLevel level = IsolationLevel.ReadUncommitted)
        //{
        //    serviceCollection.AddScoped((serviceProvider) =>
        //    {
        //        var connection = serviceProvider.GetService<IDbConnection>();
        //        connection.Open();

        //        return connection.BeginTransaction(level);
        //    });

        //    serviceCollection.AddScoped(typeof(UnitOfWorkFilter), typeof(UnitOfWorkFilter));

        //    serviceCollection
        //        .AddMvc(setup =>
        //        {
        //            setup.Filters.AddService<UnitOfWorkFilter>(1);
        //        });
        //}


        //public static List<TypeInfo> GetTypesAssignableTo(this Assembly assembly, Type compareType)
        //{
        //    var typeInfoList = assembly.DefinedTypes.Where(x => x.IsClass
        //                        && !x.IsAbstract
        //                        && x != compareType
        //                        && x.GetInterfaces()
        //                                .Any(i => i.IsGenericType
        //                                        && i.GetGenericTypeDefinition() == compareType))?.ToList();

        //    return typeInfoList;
        //}

        //public static void AddClassesAsImplementedInterface(
        //        this IServiceCollection services,
        //        Assembly assembly,
        //        Type compareType,
        //        ServiceLifetime lifetime = ServiceLifetime.Scoped)
        //{
        //    assembly.GetTypesAssignableTo(compareType).ForEach((type) =>
        //    {
        //        foreach (var implementedInterface in type.ImplementedInterfaces)
        //        {
        //            switch (lifetime)
        //            {
        //                case ServiceLifetime.Scoped:
        //                    services.AddScoped(implementedInterface, type);
        //                    break;
        //                case ServiceLifetime.Singleton:
        //                    services.AddSingleton(implementedInterface, type);
        //                    break;
        //                case ServiceLifetime.Transient:
        //                    services.AddTransient(implementedInterface, type);
        //                    break;
        //            }
        //        }
        //    });
        //}
    }
}

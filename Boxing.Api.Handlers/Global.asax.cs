using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Boxing.Api.Handlers.App_Start;
using Boxing.Api.Handlers.Filters;
using Boxing.Core.Handlers;
using Boxing.Core.Handlers.CrossCutting;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace Boxing.Api.Handlers
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //config.Filters.Add(new AuthAttribute());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterFilters(config);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterHandlers(builder);
            RegisterContext(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            FluentValidationModelValidatorProvider.Configure(config);

            BoxingContext.SetInitializer();
            config.EnsureInitialized();
        }

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>();

            builder.RegisterAssemblyTypes(typeof(Mediator).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                    .Select(interfaceType => new KeyedService("handler", interfaceType)));

            builder.RegisterGenericDecorator(
                typeof(LoggingHandlerDecorator<,>),
                typeof(IRequestHandler<,>),
                fromKey: "handler");
        }

        private static void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<BoxingContext>()
                .InstancePerRequest()
                .AsSelf()
                .As<DbContext>();
        }
    }
}
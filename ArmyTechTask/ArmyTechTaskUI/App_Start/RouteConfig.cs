using Autofac;
using Autofac.Integration.Mvc;
using Repositories;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArmyTechTaskUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                    .InstancePerRequest();
            builder.RegisterType<ArmyTechTaskEntities>()
                .InstancePerRequest();
            builder.RegisterGeneric(typeof(GenaricReposoitories<>))
                  .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                  .InstancePerRequest();
            builder.RegisterAssemblyTypes
                    (
                    typeof(StudentService).Assembly
                    ).Where(i => i.Name.EndsWith("Service"))
                    .InstancePerRequest();
            Autofac.IContainer c = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(c));
        }
    }
}

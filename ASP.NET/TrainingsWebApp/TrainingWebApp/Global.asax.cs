using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GW.AspNetTraining.TrainingsWebApp.Business;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GW.AspNetTraining.TrainingsWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<OrderProcessor>();

            builder.RegisterType<TrainingRepository>()
                .As<ITrainingRepository>()
                .WithParameters(new Parameter[]{
                new NamedParameter("dataStorePath", @"c:\temp\trainings.xml")});

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

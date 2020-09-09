using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using GW.AspNetTraining.TrainingsWebApp.Business;
using System.Web.Mvc;
using System.Web.Routing;

namespace GW.AspNetTraining.TrainingsWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TrainingRepository>()
                .As<ITrainingRepository>()
                .WithParameters(new Parameter[]{
                new NamedParameter("dataStorePath", @"c:\temp\trainings.xml")});

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

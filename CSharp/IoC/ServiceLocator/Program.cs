using Autofac;
using ServiceLocator.Business;
using ServiceLocator.Contracts;
using ServiceLocator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TimeService>().As<ITimeService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<Repository>().As<IRepository>();
            builder.RegisterType<OrderProcessor>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                MyContainerSingleton.Instance.ComponentContext = scope;
                var instance = scope.Resolve<OrderProcessor>();
               
                instance.Execute();

            }

            Console.ReadLine();

        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HamburgGreeting>().As<IGreeting>();
            builder.RegisterType<BayernGreeting>().As<IGreeting>();
            builder.RegisterType<DemoClass>();

            var container = builder.Build();

            using(var scope = container.BeginLifetimeScope())
            {
                var instance = scope.Resolve<DemoClass>();
                Console.WriteLine(instance.SayHallo());

            }

            Console.ReadLine();

        }
    }
}

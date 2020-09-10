using Autofac;
using ServiceLocator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator.Business
{
    public class OrderProcessor
    {
        private readonly IRepository _repository;
        private readonly ITimeService _timeService;
        private readonly IPaymentService _paymentService;

        // Veröffentlichung aller Abhängigkeiten
        public OrderProcessor(IRepository repository, ITimeService timeService, IPaymentService paymentService)
        {
            _repository = repository;
            _timeService = timeService;
            _paymentService = paymentService;
        }

        /// <summary>
        /// IoC-Container als Abhängigkeit 
        /// </summary>
        //public OrderProcessor(IComponentContext componentContext)
        //{
        //                _repository = componentContext.Resolve<IRepository>();
        //    _timeService = componentContext.Resolve<ITimeService>();
        //    _paymentService = componentContext.Resolve<IPaymentService>();
        //}

        /// <summary>
        /// Statischer Zugriff auf den IoC-Container
        /// </summary>
        //public OrderProcessor()
        //{
        //    _repository = MyContainerSingleton.Instance.ComponentContext.Resolve<IRepository>();
        //    _timeService = MyContainerSingleton.Instance.ComponentContext.Resolve<ITimeService>();
        //    _paymentService = MyContainerSingleton.Instance.ComponentContext.Resolve<IPaymentService>();
        //}

        public void Execute()
        {
            Console.WriteLine($"Repository exists: {_repository != null}");
            Console.WriteLine($"TimeService exists: {_timeService != null}");
            Console.WriteLine($"PaymentService exists: {_paymentService != null}");
            Console.WriteLine();
            Console.WriteLine("Executed");
        }
    }
}

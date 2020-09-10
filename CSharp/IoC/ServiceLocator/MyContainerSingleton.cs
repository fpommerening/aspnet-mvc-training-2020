using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocator
{
    public class MyContainerSingleton
    {
        private MyContainerSingleton()
        {

        }

        private static MyContainerSingleton _instance;

        public static MyContainerSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MyContainerSingleton();
                }
                return _instance;
            }
        }

        public IComponentContext ComponentContext { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class DemoClass 
    {
        private IGreeting _greeting;
        public DemoClass(IGreeting greeting)
        {
            _greeting = greeting;
        }

        public string SayHallo()
        {
            return _greeting.SayHallo();
        }
    }
}

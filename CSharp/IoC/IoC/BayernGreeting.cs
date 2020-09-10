using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class BayernGreeting : IGreeting
    {
        public string SayHallo()
        {
            return "Grüß Gott";
        }
    }
}

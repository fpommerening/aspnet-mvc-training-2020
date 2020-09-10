using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class MySingleton
    {
        private MySingleton()
        {
        }

        private static MySingleton _instance;
        private static object syncRoot = new object();

        public static MySingleton Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new MySingleton();
                    }
                }
                return _instance;

            }
        }
    }
}

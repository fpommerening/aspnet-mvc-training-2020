using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.ReadLine();

        }

        public static void Print(object obj)
        {
            if (obj is IEnumerable<IGrouping<object, object>> groupedObject)
            {
                obj = groupedObject.Select(x => new
                {
                    Key = x.Key,
                    Items = x.ToArray()
                }).ToArray();
            }

            Console.WriteLine(JsonHelper.JsonPrettify(obj));

        }


    }
}

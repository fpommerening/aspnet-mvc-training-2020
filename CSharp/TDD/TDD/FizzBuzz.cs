using System;

namespace TDD
{
    internal class FizzBuzz
    {
        public FizzBuzz()
        {
        }

        internal string Calc(int zahl)
        {
            var result = "";
            if (zahl % 3 == 0)
            {
                result += "Fizz";
            }
            if(zahl % 5 == 0)
            {
                result += "Buzz";
            }
            return string.IsNullOrEmpty(result) ? zahl.ToString() : result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {

        public string Browsing(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Calling(string number)
        {
            if (number.Any(x => !Char.IsDigit(x)))
            {
                return "Invalid number!";
            }

            if (number.Length < 10)
            {
                return $"Dialing... {number}";
            }

            return $"Calling... {number}";
        }
    }
}

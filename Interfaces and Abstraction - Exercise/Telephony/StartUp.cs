using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split().ToList();
            List<string> urls = Console.ReadLine().Split().ToList();

            Smartphone smartphone = new Smartphone();

            foreach (string number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }

            foreach (string url in urls)
            {
                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}

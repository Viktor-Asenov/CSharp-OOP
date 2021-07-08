using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();
            ICar ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}

namespace Collector
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGetterAndSetter("Hacker");
            Console.WriteLine(result);
        }
    }
}

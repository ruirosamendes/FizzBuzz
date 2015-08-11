using System.Threading;

namespace FizzBuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.WriteOutput(1, 20);
            Thread.Sleep(10000);
        }
    }
}

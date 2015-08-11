using NUnit.Framework;
using System;
using System.Text;

namespace FizzBuzzApp
{
    public class FizzBuzz
    {      
        internal string Output(int bottomNumber, int topNumber)
        {
            StringBuilder lineOutput = new StringBuilder();
            string numberOutput = string.Empty;

            try
            {
                for (int number = bottomNumber; number <= topNumber; number++)
                {
                    if ((number % 15) == 0)
                        numberOutput = "fizzbuzz";
                    else if ((number % 5) == 0)
                        numberOutput = "buzz";
                    else if ((number % 3) == 0)
                        numberOutput = "fizz";
                    else
                        numberOutput = number.ToString();

                    if (number == topNumber)
                        lineOutput.Append(numberOutput);
                    else
                        lineOutput.Append(numberOutput + " ");
                }
            }
            catch (OutOfMemoryException)
            {
                lineOutput.Clear();
                lineOutput.Append("Huge contiguous range. Please select smaller contiguous range.");
            }
            return lineOutput.ToString();
        }

        public void WriteOutput(int bottomNumber, int topNumber)
        {
            Console.WriteLine(Output(bottomNumber, topNumber));
        }
    }

    [TestFixture()]
    public class FizzBuzzTests
    {
       
        [Test()]
        public void FizzBuzzFromOneToTwenty()
        {
            string expectedOutput = @"1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz";
            FizzBuzz fizzBuzz = new FizzBuzz();            
            Assert.AreEqual(expectedOutput, fizzBuzz.Output(1, 20));
        }

        [Test()]
        public void FizzBuzzBottomHigherThanTopOutputEmptyString()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual(string.Empty, fizzBuzz.Output(20, 1));
        }

        [Test()]
        public void FizzBuzzBottomHandlesOutOfMemoryException()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.Catch< OutOfMemoryException>(
                delegate 
                {
                       Assert.AreEqual (
                         "Huge contiguous range. Please select smaller contiguous range.",
                        fizzBuzz.Output(1, int.MaxValue));
                });
            
        }

    }
}

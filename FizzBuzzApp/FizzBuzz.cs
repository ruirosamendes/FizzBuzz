using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzApp
{
    public class FizzBuzz
    {
        Dictionary<string, int> _wordsCount = new Dictionary<string, int>();

        private void WordCount(string word)
        {
            if (!_wordsCount.ContainsKey(word))
                _wordsCount.Add(word, 1);
            else
                _wordsCount[word]++;
        }

        internal string LineOutput(int bottomNumber, int topNumber)
        {
            StringBuilder lineOutput = new StringBuilder();
            string numberOutput = string.Empty;
            
            try
            {
                for (int number = bottomNumber; number <= topNumber; number++)
                {
                    if(number.ToString().Contains("3"))
                        numberOutput = "lucky";
                    else if ((number % 15) == 0)
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

                    int numberInt;
                    if (int.TryParse(numberOutput, out numberInt))
                        WordCount("integer");
                    else
                        WordCount(numberOutput);                                            
                }
            }
            catch (OutOfMemoryException)
            {
                lineOutput.Clear();
                lineOutput.Append("Huge contiguous range. Please select smaller contiguous range.");
            }
            return lineOutput.ToString();
        }
      
        internal string ReportOutput(int bottomNumber, int topNumber)
        {
            StringBuilder reportOutput = new StringBuilder();

            reportOutput.Append(LineOutput(bottomNumber, topNumber) + Environment.NewLine);
            reportOutput.Append("fizz: " + _wordsCount["fizz"] + Environment.NewLine);
            reportOutput.Append("buzz: " + _wordsCount["buzz"] + Environment.NewLine);
            reportOutput.Append("fizzbuzz: " + _wordsCount["fizzbuzz"] + Environment.NewLine);
            reportOutput.Append("lucky: " + _wordsCount["lucky"] + Environment.NewLine);
            reportOutput.Append("integer: " + _wordsCount["integer"]);

            return reportOutput.ToString();
        }

        public void WriteOutput(int bottomNumber, int topNumber)
        {
            Console.Write(ReportOutput(bottomNumber, topNumber));
        }        
    }

    [TestFixture()]
    public class FizzBuzzTests
    {
       
        [Test()]
        public void FizzBuzzFromOneToTwenty()
        {
            string expectedOutput = @"1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            FizzBuzz fizzBuzz = new FizzBuzz();            
            Assert.AreEqual(expectedOutput, fizzBuzz.LineOutput(1, 20));
        }

        [Test()]
        public void FizzBuzzBottomHigherThanTopOutputEmptyString()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual(string.Empty, fizzBuzz.LineOutput(20, 1));
        }

        [Test()]        
        public void FizzBuzzHandlesOutOfMemoryException()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.Catch< OutOfMemoryException>(
                delegate 
                {
                       Assert.AreEqual (
                         "Huge contiguous range. Please select smaller contiguous range.",
                        fizzBuzz.LineOutput(1, int.MaxValue));
                });            
        }

        [Test()]
        public void FizzBuzzFromOneToTwentyMustOutputLuckyForNumbersContainingThree()
        {
            string expectedOutput = @"1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual(expectedOutput, fizzBuzz.LineOutput(1, 20));
        }

        [Test()]
        public void FizzBuzzMustReportWordsCounts()
        {
            string expectedOutput = 
                "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz" + Environment.NewLine +
                "fizz: 4" + Environment.NewLine +
                "buzz: 3" + Environment.NewLine +
                "fizzbuzz: 1" + Environment.NewLine +
                "lucky: 2" + Environment.NewLine +
                "integer: 10";
            FizzBuzz fizzBuzz = new FizzBuzz();
            Assert.AreEqual(expectedOutput, fizzBuzz.ReportOutput(1, 20));
        }

    }
}

using System;
using System.IO;
using Xunit;

namespace ConsoleApp.Tests
{
    public class ProgramTests
    {

        [Theory]
        [InlineData(1700)]
        [InlineData(1800)]
        [InlineData(1900)]
        [InlineData(2100)]
        [InlineData(2200)]
        [InlineData(2500)]
        [InlineData(2600)]
        [InlineData(2700)]
        [InlineData(2900)]
        [InlineData(3000)]
        public void IsLeapYear_shouldNotBeLeapYear(int year)
        {
            var result = Program.IsLeapYear(year);
            Assert.False(result);
        }


        [Theory]
        [InlineData(2000)]
        [InlineData(1696)]
        [InlineData(2788)]
        [InlineData(2988)]
        [InlineData(2504)]
        [InlineData(2024)]
        public void IsLeapYear_shouldBeALeapYear(int year)
        {
            var result = Program.IsLeapYear(year);
            Assert.True(result);
        }



        [Theory]
        [InlineData(1700)]
        [InlineData(1800)]
        [InlineData(1900)]
        [InlineData(2100)]
        [InlineData(2200)]
        [InlineData(2500)]
        [InlineData(2600)]
        [InlineData(2700)]
        [InlineData(2900)]
        [InlineData(3000)]
        public void Main_inputNonLeapYear_ShouldReplyNay(int year)
        {
            var writer = new StringWriter();
            var reader = new StringReader(year.ToString() + Environment.NewLine);

            Console.SetOut(writer);
            Console.SetIn(reader);

            Program.Main(new string[0]);

            var result = writer.GetStringBuilder().ToString();
            Assert.Contains("nay", result);
        }


        [Theory]
        [InlineData(2000)]
        [InlineData(2024)]
        [InlineData(1696)]
        [InlineData(2788)]
        [InlineData(2988)]
        [InlineData(2504)]
        public void Main_inputLeapYear_ShouldReplyYay(int year)
        {
            var result = captureOutput(new string[0], year.ToString());
            Assert.Contains("yay", result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1581)]
        [InlineData(-1)]
        [InlineData(1)]
        public void IsLeapYear_inputIsLowerThanRequired_ShouldThrowException(int year)
        {
            Assert.Throws<ArgumentException>(() => Program.IsLeapYear(year));
        }


        [Theory]
        [ClassData(typeof(StringInputData))]
        public void Main_inputIsNotANumber_ShouldPrintError(string input, string expected)
        {
            var output = captureOutput(new string[0], input);
            Assert.Contains(expected, output);
        }


        [Theory]
        [ClassData(typeof(StringInputDataValid))]
        public void Main_inputIsAValidNumber_ShouldPrintYay(string input, string expected)
        {
            var output = captureOutput(new string[0], input);
            Assert.Contains(expected, output);
        }



        public String captureOutput(string[] args, string input)
        {
            var writer = new StringWriter();
            var reader = new StringReader(input + Environment.NewLine);

            Console.SetOut(writer);
            Console.SetIn(reader);

            Program.Main(new string[0]);

            return writer.GetStringBuilder().ToString();
        }


    }
}

public class StringInputData : TheoryData<string, string>
{
    public StringInputData()
    {
        string ans = "invalid input";
        Add("", ans);
        Add(null, ans);
        Add("----", ans);
        Add("a333", ans);
        Add("199b", ans);
        Add("1 9 9 6", ans);
        Add("b", ans);
    }
}

public class StringInputDataValid : TheoryData<string, string>
{
    public StringInputDataValid()
    {
        string ans = "yay";
        Add("2004", ans);
        Add("2000", ans);
        Add("2024", ans);
        Add("1696", ans);
        Add("2788", ans);
        Add("2988", ans);
        Add("2504", ans);
    }
}
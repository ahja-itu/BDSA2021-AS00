using System;
using Xunit;

namespace ConsoleApp.Tests
{
    public class ProgramTests
    {

        [Theory]
        [InlineData(1700)]
        [InlineData(1800)]
        [InlineData(1900)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(3)]
        [InlineData(5)]
        public void IsLeapYear_shouldNotBeLeapYear(int year)
        {
            var result = Program.IsLeapYear(year);
            Assert.False(result);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(-4)]
        [InlineData(20)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(1200)]
        [InlineData(2000)]
        [InlineData(2024)]
        public void IsLeapYear_shouldBeALeapYear(int year)
        {
            var result = Program.IsLeapYear(year);
            Assert.True(result);
        }
    }
}

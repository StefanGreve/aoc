using Xunit;

using AoC2022.Day1;
using AoC2022.Day2;
using AoC2022.Day3;
using AoC2022.Day4;
using AoC2022.Day5;
using AoC2022.Day6;

namespace Day.Tests
{
    public class DayTests
    {
        #region Day 1

        [Theory]
        [InlineData("test-input1.txt")]
        public void TestDay1Task1(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day1.ParseInput(input);

            // Act
            var expected = Day1.Task1(data);

            // Assert
            Assert.Equal(24_000, expected);
        }

        [Theory]
        [InlineData("test-input1.txt")]
        public void TestDay1Task2(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day1.ParseInput(input);

            // Act
            var expected = Day1.Task2(data);

            // Assert
            Assert.Equal(45_000, expected);
        }

        #endregion

        #region Day 2

        [Theory]
        [InlineData("test-input2.txt")]
        public void TestDay2Task1(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day2.ParseInput(input);

            // Act
            var expected = Day2.Task1(data);

            // Assert
            Assert.Equal(15, expected);
        }

        [Theory]
        [InlineData("test-input2.txt")]
        public void TestDay2Task2(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day2.ParseInput(input);

            // Act
            var expected = Day2.Task2(data);

            // Assert
            Assert.Equal(12, expected);
        }

        #endregion

        #region Day 3

        [Theory]
        [InlineData("test-input3.txt")]
        public void TestDay3Task1(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day3.ParseInput(input);

            // Act
            var expected = Day3.Task1(data);

            // Assert
            Assert.Equal(157, expected);
        }

        [Theory]
        [InlineData("test-input3.txt")]
        public void TestDay3Task2(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);

            // Act
            var expected = Day3.Task2(input);

            // Assert
            Assert.Equal(70, expected);
        }

        #endregion

        #region Day 4

        [Theory]
        [InlineData("test-input4.txt")]
        public void TestDay4Task1(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day4.ParseInput(input);

            // Act
            var expected = Day4.Task1(data);

            // Assert
            Assert.Equal(2, expected);
        }

        [Theory]
        [InlineData("test-input4.txt")]
        public void TestDay4Task2(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            var data = Day4.ParseInput(input);

            // Act
            var expected = Day4.Task2(data);

            // Assert
            Assert.Equal(4, expected);
        }

        #endregion

        #region Day 5

        [Theory]
        [InlineData("test-input5.txt")]
        public void TestDay5Task1(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);
            
            // Act
            var expected = Day5.Task1(input, crateMover: 9000);

            // Assert
            Assert.Equal("CMZ", expected);
        }

        [Theory]
        [InlineData("test-input5.txt")]
        public void TestDay5Task2(string path)
        {
            // Arrange
            var input = File.ReadAllLines(path);

            // Act
            var expected = Day5.Task2(input);

            // Assert
            Assert.Equal("MCD", expected);
        }

        #endregion

        #region Day 6

        [Theory]
        [InlineData("test-input6.txt")]
        public void TestDay6Task1(string path)
        {
            // Arrange
            var input = File.ReadAllText(path).ToCharArray();

            // Act
            var expected = Day6.Task1(input);

            // Assert
            Assert.Equal(7, expected);
        }

        [Theory]
        [InlineData("test-input6.txt")]
        public void TestDay6Task2(string path)
        {
            // Arrange
            var input = File.ReadAllText(path).ToCharArray();

            // Act
            var expected = Day6.Task2(input);

            // Assert
            Assert.Equal(19, expected);
        }

        #endregion
    }
}
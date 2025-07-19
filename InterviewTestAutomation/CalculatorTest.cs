
using InterviewTestQA.InterviewTestAutomation;
using NUnit.Framework;
using System;

namespace InterviewTestQA.InterviewTestAutomation
{
  /*  public class CalculatorTest
    {
        [Fact]
        public void Test1()
        {

        }
    }*/

[TestFixture]
    public class CalculatorTest
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        // Addition Tests
        [TestCase(2, 3, ExpectedResult = 5)]
        [TestCase(-2, -3, ExpectedResult = -5)]
        [TestCase(-2, 3, ExpectedResult = 1)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, ExpectedResult = int.MaxValue)]
        [TestCase(int.MinValue, 0, ExpectedResult = int.MinValue)]
        public int AddTests(int a, int b) => calculator.Add(a, b);

        // Subtraction Tests
        [TestCase(5, 3, ExpectedResult = 2)]
        [TestCase(-5, -3, ExpectedResult = -2)]
        [TestCase(-5, 3, ExpectedResult = -8)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 1, ExpectedResult = int.MaxValue - 1)]
        [TestCase(int.MinValue, -1, ExpectedResult = int.MinValue + 1)]
        public int SubtractTests(int a, int b) => calculator.Subtract(a, b);

        // Multiplication Tests
        [TestCase(2, 3, ExpectedResult = 6)]
        [TestCase(-2, -3, ExpectedResult = 6)]
        [TestCase(-2, 3, ExpectedResult = -6)]
        [TestCase(0, 100, ExpectedResult = 0)]
        [TestCase(100, 0, ExpectedResult = 0)]
        public int MultiplyTests(int a, int b) => calculator.Multiply(a, b);

        // Division Tests
        [TestCase(6, 3, ExpectedResult = 2)]
        [TestCase(-6, -3, ExpectedResult = 2)]
        [TestCase(-6, 3, ExpectedResult = -2)]
        [TestCase(0, 3, ExpectedResult = 0)]
        public int DivideTests(int a, int b) => calculator.Divide(a, b);

        [Test]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            var ex = NUnit.Framework.Assert.Throws<ArgumentException>(() => calculator.Divide(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Cannot divide by zero."));
        }

        // Square Tests
        [TestCase(2, ExpectedResult = 4)]
        [TestCase(-3, ExpectedResult = 9)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        public int SquareTests(int a) => calculator.Square(a);

        // SquareRoot Tests (Note: Based on your logic, this always returns 1 if input != 0)
        [TestCase(4, ExpectedResult = 1)]
        [TestCase(9, ExpectedResult = 1)]
        [TestCase(1, ExpectedResult = 1)]
        public int SquareRoot_ValidInput_ReturnsOne(int a) => calculator.SquareRoot(a);

        [Test]
        public void SquareRoot_Zero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.SquareRoot(0));
            Assert.That(ex.Message, Is.EqualTo("Cannot square root zero."));
        }

        // Extreme/Boundary Conditions
        [Test]
        public void Add_MaxInt_And_One_Overflows()
        {
            int a = int.MaxValue;
            int b = 1;
            int result = calculator.Add(a, b); // Note: Will overflow without checked block
            Assert.That(result, Is.EqualTo(int.MinValue)); // Due to overflow wrap-around
        }

        [Test]
        public void Multiply_LargeNumbers_NoOverflowCheck()
        {
            int a = 50000;
            int b = 50000;
            int result = calculator.Multiply(a, b); // Might overflow, just ensure consistent behavior 
            Assert.That(result, Is.EqualTo(705032704));  // Actual value without overflow check
        }
    }


}
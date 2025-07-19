﻿namespace InterviewTestQA.InterviewTestAutomation
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Cannot divide by zero.");
            return a / b;
        }

        public int Square(int a)
        {
            return a * a;
        }

        public int SquareRoot(int a)
        {
            if (a == 0)
                throw new ArgumentException("Cannot square root zero.");
            return a / a;
        }
    }
}

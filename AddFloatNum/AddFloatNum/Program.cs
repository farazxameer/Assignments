using System;

namespace AddFloatNum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating two FloatNumber Objects two store two numbers
            FloatNumber firstNumber = new FloatNumber();
            FloatNumber secondNumber = new FloatNumber();
            string[] resultArray = new string[2];
            string[] binaryMantissa = new string[2];
            string[] binaryExponent = new string[2];
            string[] firstBinaryNumber = new string[2];
            string[] secondBinaryNumber = new string[2];

            firstBinaryNumber = firstNumber.GetNumber();
            secondBinaryNumber = secondNumber.GetNumber();

            binaryMantissa = firstNumber.Pad(firstBinaryNumber[0], secondBinaryNumber[0], true);
            binaryExponent = firstNumber.Pad(firstBinaryNumber[1], secondBinaryNumber[1], false);

            resultArray[0] = firstNumber.Add(binaryMantissa[0], binaryMantissa[1], true);
            resultArray[1] = firstNumber.Add(binaryExponent[0], binaryExponent[1], false);

            string Result = (firstNumber.ToDecimal(resultArray[0]) + firstNumber.ToDecimalFact(resultArray[1])).ToString();

            //Displaying the Result.
            Console.Write("The Sum of two number is : ");
            Console.WriteLine(Result);
            Console.Read();
        }
    }
}
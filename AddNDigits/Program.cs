using System;
using System.IO;

namespace AddNDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //It will increase the input intake buffer size.
            byte[] inputBuffer = new byte[(int)Math.Pow(2, 15)];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            //To read the First number. 
            Console.WriteLine("Enter the first number : ");
            string firstNumber = Console.ReadLine();

            //To read the Second number.
            Console.WriteLine("Enter the second number : ");
            string secondNumber = Console.ReadLine();

            //Finds which is smaller in length and pads with '0' to make the two numbers equal in length.
            firstNumber = (firstNumber.Length < secondNumber.Length) ? Pad(secondNumber.Length, firstNumber) : firstNumber;
            secondNumber = (firstNumber.Length > secondNumber.Length) ? Pad(firstNumber.Length, secondNumber) : secondNumber;

            //Declaring the an array to store result. 
            int[] resultArray = new int[firstNumber.Length];
            int carry = 0;

            //Itreating through each digit from left and adding the digits.
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                resultArray[i] = ((firstNumber[i] - 48) + (secondNumber[i] - 48) + carry) % 10;
                carry = ((firstNumber[i] - 48) + (secondNumber[i] - 48) + carry) / 10;
            }

            //Printing the result of the Addition.
            Console.WriteLine("The Sum of two number is : ");
            if (carry > 0)
            {
                Console.Write(carry);
            }
            foreach (int i in resultArray)
            {
                Console.Write(i);
            }
            Console.ReadLine();
        }

        ///<summary>
        /// Adds '0' to the left of the number to make the length equal to numbers
        ///</summary>
        ///<params name="length">This is length that has to be obtained</param>
        ///<params name="input">This string is to be padded with '0' to obtain the required length</param>
        private static string Pad(int length, string input)
        {
            int difference = length - input.Length;
            for (int i = 0; i < difference; i++)
            {
                input = "0" + input;
            }
            return input;
        }
    }
}
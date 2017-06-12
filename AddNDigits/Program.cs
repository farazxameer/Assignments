using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;


namespace AddNDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //This will increase the Input intake to 2^15
            byte[] inputBuffer = new byte[(int)Math.Pow(2, 15)];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            //Declaring Two Strings for Taking the input.
            string FirstNumber = String.Empty,
                   SecondNumber = String.Empty;

            //Reading the First Number
            Console.WriteLine("Enter the first number : ");
            FirstNumber = Console.ReadLine();
            
            //Reading the First Number
            Console.WriteLine("Enter the second number : ");
            SecondNumber = Console.ReadLine();

            if(FirstNumber.Length > SecondNumber.Length)
            {
                //Padding the '0' to left of SecondNumber till the length of FirstNumber. 
                SecondNumber = SecondNumber.PadLeft(FirstNumber.Length,'0');
            }
            else
            {
                //Padding the '0' to left of FirstNumber till the length of SecondNumber.
                FirstNumber = FirstNumber.PadLeft(SecondNumber.Length,'0');
            }

            //Converting the String to Char Array
            char[] FirstCharArray = FirstNumber.ToCharArray();
            char[] SecondCharArray = SecondNumber.ToCharArray();
            
            //Converting the Char Array to Int Array.
            int[] FirstIntArray = GetIntArray(FirstCharArray);
            int[] SecondIntArray = GetIntArray(SecondCharArray);

            //Declaring a Array to store Result.
            int[] ResultIntArray = new int[FirstIntArray.Length];
            int carry = 0;

            //Adding the Array From Reverse Order.
            for(int i = FirstIntArray.Length - 1; i >= 0; i--)
            {
                ResultIntArray[i] = (FirstIntArray[i] + SecondIntArray[i] + carry) % 10;
                carry = (FirstIntArray[i] + SecondIntArray[i] + carry) / 10;
            }

            //Printing the result of the Addition.
            Console.WriteLine("The Sum of two number is : ");
            if(carry == 1)
            {
                Console.Write(carry);
            }

            for(int i = 0; i < ResultIntArray.Length; i++)
            {
                Console.Write(ResultIntArray[i]);
            }   

            Console.ReadLine();
           
        }

        private static int[] GetIntArray(char[] arr)
        {
            int[] IntArr = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                IntArr[i] = int.Parse(Convert.ToString(arr[i]));
            }
            return IntArr;
        }
    }
}

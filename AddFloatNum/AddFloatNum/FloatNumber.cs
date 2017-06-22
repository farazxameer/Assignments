using System;
using System.Collections.Generic;

namespace AddFloatNum
{
    class FloatNumber
    {
        ///<summary>
        ///It will take a number as input from user, then splits the number into Mantissa and Exponent parts, 
        ///and converts to binary format.
        ///</summary>
        public string[] GetNumber()
        {
            string number, mantissa, exponent;
            string binaryMantissa, binaryExponent;
            string[] numberInBinary = new string[2];
            try
            {
                //Reading input from user.
                Console.Write("Enter a Number : ");
                number = Console.ReadLine();

                //checking if '.' is present in the input, if not present append it to the input.
                number = (ContainsValue(number, ".")) ? number : number + ".0";
                
                //If the input number has '.' at the first place then appending the number to '0'.
                number = (IndexOfValue(number, ".") == 0) ? "0" + number : number;

                //Spliting the Mantissa and Exponent parts.
                mantissa = SubString(number, 0, IndexOfValue(number, "."));
                exponent = SubString(number, IndexOfValue(number, ".") + 1, number.Length - (IndexOfValue(number, ".") + 1));

                //Converts to binary format.
                binaryMantissa = ToBinary(mantissa);
                binaryExponent = ToBinaryFact(exponent);
            }
            //Catches the Format Exception, if the number is not in correct format it sets the number to '0.0'. 
            catch (System.FormatException)
            {
                Console.Write("The Input String was not in correct format !!!\nThe First Number is set to 0.0\n");
                binaryMantissa = "0";
                binaryExponent = "0";
            }
            numberInBinary[0] = binaryMantissa;
            numberInBinary[1] = binaryExponent;
            return numberInBinary;
        }

        ///<summary>
        ///It will convert the mantissa part of the number to Binary. 
        ///</summary>
        ///<param name="input">The mantissa of the number has to be passed.</param>
        private string ToBinary(string input)
        {
            long quotient = Convert.ToInt64(input);
            List<long> binary = new List<long>();
            string binaryNumber = String.Empty;

            while (quotient != 0)
            {
                long x = quotient % 2;
                binary.Add(x);
                quotient = quotient / 2;
            }

            //The Binary number generated is in reverse, therefore revering the binary number. 
            for (int i = binary.Count - 1; i >= 0; i--)
            {
                binaryNumber += binary[i].ToString();
            }
            binaryNumber = (binaryNumber != "") ? binaryNumber : "0";
            return binaryNumber;
        }

        ///<summary>
        ///It will convert the decimal part which is after the '.' to Binary. 
        ///</summary>
        ///<param name="input">The exponent of the number has to be passed.</param>
        private string ToBinaryFact(string input)
        {
            int length = input.Length;
            string binary = String.Empty;
            input = "0." + input;
            double number = Convert.ToDouble(input);

            for (int i = 1; ; i++)
            {
                double multiply = number * 2;
                binary = (multiply >= 1.0) ? binary + "1" : binary += "0";
                string temp = (!(ContainsValue(multiply.ToString(), "."))) ? multiply.ToString() + ".0" : multiply.ToString();
                temp = SubString(temp, IndexOfValue(temp, ".") + 1, temp.Length - (IndexOfValue(temp, ".") + 1));
                if (temp == "0" || i > 500)
                {
                    break;
                }
                temp = "0." + temp;
                number = Double.Parse(temp);
                temp = "";
            }
            return binary;
        }

        ///<summary>
        ///It will Compare the two inputs and make them of equal size by padding '0'. If the isFirst parameter is true
        ///then it will append '0' before the number, and if it is false it will append '0' after the number. 
        ///</summary>
        public string[] Pad(string firstString, string secondString, bool isFirst)
        {
            if (firstString.Length > secondString.Length)
            {
                int difference = firstString.Length - secondString.Length;
                for (int i = 0; i < difference; i++)
                {
                    secondString = (isFirst) ? "0" + secondString : secondString;
                    secondString = (isFirst) ? secondString : secondString + "0";
                }
            }
            else
            {
                int difference = secondString.Length - firstString.Length;
                for (int i = 0; i < difference; i++)
                {
                    firstString = (isFirst) ? "0" + firstString : firstString;
                    firstString = (isFirst) ? firstString : firstString + "0";
                }
            }
            string[] output = { firstString, secondString };
            return output;
        }

        ///<summary>
        ///It will add the two string operands bit by bit.
        ///</summary>
        ///<param name="firstOperand">It is the first parameter or operand to add</param>
        ///<param name="secondOperand">It is the second parameter or operand to add</param>
        public string Add(string firstOperand, string secondOperand, bool isFirst)
        {
            char[] firstChars = firstOperand.ToCharArray();
            char[] secondChars = secondOperand.ToCharArray();
            string output = String.Empty;

            int[] result = new int[firstOperand.Length];
            int carry = 0;

            for (int i = firstOperand.Length - 1; i >= 0; i--)
            {
                result[i] = firstChars[i] - 48 ^ secondChars[i] - 48 ^ carry;
                carry = (firstChars[i] - 48 & secondChars[i] - 48) | ((firstChars[i] - 48 ^ secondChars[i] - 48) & carry);
            }
            foreach (int x in result)
            {
                output += x.ToString();
            }

            if (isFirst)
            {
                output = (carry == 1) ? "1" + output : output;
            }
            else
            {
                output = (carry == 1) ? (Convert.ToInt32(output) ^ carry).ToString() : output;
            }

            return output;
        }

        ///<summary>
        ///This method will convert the binary mantissa input to the decimal eqivalent.
        ///</summary>
        public long ToDecimal(string input)
        {
            long number = input[0] - 48, decimalValue = 0, baseValue = 2;
            int i = input.Length - 1;
            int j = 1;
            while (true)
            {
                decimalValue += number * (long)Math.Pow(baseValue, i);
                if (j == input.Length)
                    break;
                number = input[j] - 48;
                j++; i--;
            }
            return decimalValue;
        }

        ///<summary>
        ///This method will convert the binary exponent input to the decimal eqivalent.
        ///</summary>
        public double ToDecimalFact(string input)
        {
            int length = input.Length;
            char[] binaryValue = input.ToCharArray();
            double decimalValue = 0;

            for (int i = 0; i < length; i++)
            {
                if ((binaryValue[i] - 48) == '\u0001')
                {
                    decimalValue += 1 / Math.Pow(2, i + 1);
                }
            }
            return decimalValue;
        }

        ///<summary>
        ///This method will split the input string, and returns the string from stratPoint index to startPoint + length
        ///</summary>
        ///<param name="input">This is the string input for which the substring operation is to be performed</param>
        ///<param name="startPoint">This is the starting index of the output string</param>
        ///<param name="length">This specifies how much length the resuktant string should be.</param>
        private string SubString(string input, int startPoint, int length)
        {
            string output = String.Empty;
            for (int i = startPoint; i < (startPoint + length); i++)
            {
                output += input[i];
            }
            return output;
        }
        ///<summary>
        ///This method will return the index of the value in the string, if the value is not present it will return -1.
        ///</summary>
        ///<param name="input">This is the string in which the index of value is needed.</param>
        ///<param name="value">This is the value for which index value is to be find.</param>
        private int IndexOfValue(string input, string value)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i].ToString() == value)
                {
                    return i;
                }
            }
            return -1;
        }
        
        ///<summary>
        ///This method will will search for value in the input string if found it will return true else false.
        ///</summary>
        private bool ContainsValue(string input, string value)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i].ToString() == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
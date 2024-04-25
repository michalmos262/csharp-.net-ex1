using System;
using Ex01_04;

namespace Ex01_05
{
    class Program
    {
        private const uint k_InputStringLen = 8;

        public static void Main()
        {
            NumberAnalysis();
        }

        public static void NumberAnalysis()
        {
            string positiveNumberString;

            positiveNumberString = getStringOfPositiveNumber();
            printNumberStatistics(positiveNumberString);
        }

        private static void printNumberStatistics(string i_PositiveNumberString)
        {
            string statistics;
            int numOfDigitsSmallerThanOnesDigit, numOfDigitsDivisibleBy3, largestDigit;
            float averageDigitValue;

            numOfDigitsSmallerThanOnesDigit = getNumOfDigitsSmallerThanOnesDigit(i_PositiveNumberString);
            numOfDigitsDivisibleBy3 = getNumOfDigitsDivisibleByX(i_PositiveNumberString, 3);
            largestDigit = getLargestDigitInNumString(i_PositiveNumberString);
            averageDigitValue = getAverageDigitValueInNumString(i_PositiveNumberString);

            statistics = string.Format(
                @"
----- Statistics of the number you typed -----
The quantity of digits less than the ones digit is: {0}.
The quantity of digits that are divisible by 3 is: {1}.
The largest digit is: {2}.
The average value of all the digits is: {3}.
", numOfDigitsSmallerThanOnesDigit, numOfDigitsDivisibleBy3, largestDigit, averageDigitValue);
            Console.WriteLine(statistics);
        }

        private static string getStringOfPositiveNumber()
        {
            string inputString, welcomeMessage = $"Please enter a positve integer with {k_InputStringLen} digits.";

            Console.WriteLine(welcomeMessage);
            inputString = Console.ReadLine();
            while (!isStringAPositiveNum(inputString))
            {
                Console.Write("Invalid input ");
                Console.WriteLine(welcomeMessage);
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        private static bool isStringAPositiveNum(string i_String)
        {
            int stringNumberValue;
            bool isStringANumber;

            isStringANumber = int.TryParse(i_String, out stringNumberValue);

            return isStringANumber && stringNumberValue > 0;
        }

        private static int getNumOfDigitsSmallerThanOnesDigit(string i_PositiveNumberString)
        {
            int numOfDigitsSmallerThanOnesDigit = 0, onesDigitValue;

            onesDigitValue = (int)char.GetNumericValue(i_PositiveNumberString[i_PositiveNumberString.Length - 1]);

            foreach (char digit in i_PositiveNumberString)
            {
                if (char.GetNumericValue(digit) < onesDigitValue)
                {
                    numOfDigitsSmallerThanOnesDigit++;
                }
            }

            return numOfDigitsSmallerThanOnesDigit;
        }

        private static int getNumOfDigitsDivisibleByX(string i_PositiveNumberString, int i_X)
        {
            int numOfDigitsDivisibleByX = 0, digitValue;

            foreach (char digit in i_PositiveNumberString)
            {
                digitValue = (int)char.GetNumericValue(digit);
                if (digitValue % i_X == 0)
                {
                    numOfDigitsDivisibleByX++;
                }
            }

            return numOfDigitsDivisibleByX;
        }

        private static int getLargestDigitInNumString(string i_PositiveNumberString)
        {
            int maxDigit = int.MinValue, digitValue;

            foreach (char digit in i_PositiveNumberString)
            {
                digitValue = (int)char.GetNumericValue(digit);
                if (digitValue > maxDigit)
                {
                    maxDigit = digitValue;
                }
            }

            return maxDigit;
        }

        private static float getAverageDigitValueInNumString(string i_PositiveNumberString)
        {
            int digitsSum = 0, digitValue;

            foreach (char digit in i_PositiveNumberString)
            {
                digitValue = (int)char.GetNumericValue(digit);
                digitsSum += digitValue;
            }
            
            return (float)digitsSum / i_PositiveNumberString.Length;
        }

    }
}

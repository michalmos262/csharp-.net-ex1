using System;

namespace Ex01_05
{
    class Program
    {
        private const uint k_InputStringLen = 8;
        private const int k_Diviser = 3;

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
            int numOfDigitsSmallerThanOnesDigit, numOfDigitsDivisibleBySpecificDiviser, largestDigit;
            float averageDigitValue;

            numOfDigitsSmallerThanOnesDigit = getNumOfDigitsSmallerThanOnesDigit(i_PositiveNumberString);
            numOfDigitsDivisibleBySpecificDiviser = getNumOfDigitsDivisibleBySpecificDiviser(i_PositiveNumberString, k_Diviser);
            largestDigit = getLargestDigitInNumString(i_PositiveNumberString);
            averageDigitValue = getAverageDigitValueInNumString(i_PositiveNumberString);
            statistics = string.Format(
                @"
----- Statistics of the number you typed -----

The quantity of digits less than the ones digit is: {0}.
The quantity of digits that are divisible by {1} is: {2}.
The largest digit is: {3}.
The average value of all the digits is: {4}.
", numOfDigitsSmallerThanOnesDigit, k_Diviser, numOfDigitsDivisibleBySpecificDiviser, largestDigit, averageDigitValue);
            Console.WriteLine(statistics);
        }

        private static string getStringOfPositiveNumber()
        {
            string inputString, welcomeMessage = $"Please enter a positve integer with {k_InputStringLen} digits.";

            Console.WriteLine(welcomeMessage);
            inputString = Console.ReadLine();
            while (!isStringAPositiveNum(inputString))
            {
                Console.Write("Invalid input.");
                Console.WriteLine(welcomeMessage);
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        private static bool isStringAPositiveNum(string i_InputStr)
        {
            int numberValue;
            bool isStringANumber;

            isStringANumber = int.TryParse(i_InputStr, out numberValue);

            return isStringANumber && numberValue > 0;
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

        private static int getNumOfDigitsDivisibleBySpecificDiviser(string i_PositiveNumberString, int i_Diviser)
        {
            int numOfDigitsDivisibleByDiviser = 0, digitValue;

            foreach (char digit in i_PositiveNumberString)
            {
                digitValue = (int)char.GetNumericValue(digit);
                if (digitValue % i_Diviser == 0)
                {
                    numOfDigitsDivisibleByDiviser++;
                }
            }

            return numOfDigitsDivisibleByDiviser;
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

using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int diamondHeight = GetDiamondHeightFromUser();
            Ex01_02.Program.DrawDiamond(diamondHeight);
        }

        static int GetDiamondHeightFromUser()
        {
            string userInput;
            bool isInputInteger;

            Console.WriteLine("Please enter the diamond height:");
            userInput = Console.ReadLine();
            isInputInteger = int.TryParse(userInput, out int diamondHeight);
            while (!isInputInteger || diamondHeight <= 0)
            {
                Console.WriteLine("Wrong input! Diamond height must be a positive whole number, please try again:");
                userInput = Console.ReadLine();
                isInputInteger = int.TryParse(userInput, out diamondHeight);
            }
            return diamondHeight;
        }
    }
}
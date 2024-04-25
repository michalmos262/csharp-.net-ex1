using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        private const int k_DiamondHeight = 9;
        public static void Main()
        {
            DrawDiamond(k_DiamondHeight);
        }

        public static void DrawDiamond(int i_DiamondHeight)
        {
            StringBuilder diamond = new StringBuilder();
            BuildDiamond(diamond, i_DiamondHeight);
            Console.WriteLine(diamond.ToString());
        }

        static void BuildDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_CurrentRowIndexInDiamond = 1)
        {
            if (i_DiamondHeight % 2 == 0)
            {
                i_DiamondHeight--;
            }
            if (i_CurrentRowIndexInDiamond == i_DiamondHeight / 2 + 1)
            {
                AppendStarsToRowInDiamond(o_Diamond, i_CurrentRowIndexInDiamond * 2 - 1);
                return;
            }
            AppendLineToDiamond(o_Diamond, i_DiamondHeight, i_CurrentRowIndexInDiamond);
            BuildDiamond(o_Diamond, i_DiamondHeight, i_CurrentRowIndexInDiamond + 1);
            AppendLineToDiamond(o_Diamond, i_DiamondHeight, i_CurrentRowIndexInDiamond);
        }

        static void AppendLineToDiamond(StringBuilder o_Diamond, int i_DiamondHeight, int i_CurrentRowIndexInDiamond)
        {
            AppendSpacesToRowInDiamond(o_Diamond, i_DiamondHeight / 2 + 1 - i_CurrentRowIndexInDiamond);
            AppendStarsToRowInDiamond(o_Diamond, i_CurrentRowIndexInDiamond * 2 - 1);
        }

        static void AppendSpacesToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfSpaces)
        {
            io_Diamond.Append(new string(' ', i_NumberOfSpaces));
        }

        static void AppendStarsToRowInDiamond(StringBuilder io_Diamond, int i_NumberOfStars)
        {
            io_Diamond.Append(new string('*', i_NumberOfStars));
            io_Diamond.AppendLine();
        }
    }
}



namespace AsmtLib
{
    public class Lib
    {
        public static void NumToTxt()
        {
            int num = GetInputNum();

            if (num == 0)
                Console.WriteLine("ZERO");
            else
            {
                var numArray = GetNumArray(num);

                string text = SecondLevelText(numArray);

                Console.WriteLine(text);
            }
        }

        private static int GetInputNum()
        {
            int intInput;

            while (true)
            {
                Console.WriteLine("Please input a 32-bit number");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out intInput))
                    break;
                else
                {
                    Console.Clear();
                    continue;
                }
            }

            return intInput;
        }

        private static int[] GetNumArray(int num)
        {
            List<int> numList = new List<int>();

            while (num > 0)
            {
                numList.Add(num % 10);
                num = num / 10;
            }
            numList.Reverse();

            while (numList.Count % 3 != 0)
                numList.Insert(0, 0);

            return numList.ToArray();
        }

        private static string FirstLevelText(int[] numArray)
        {
            string textValue = "";
            Dictionary<int, string> singleDigit = new Dictionary<int, string>()
            {
                {1, "ONE"}, {2, "TWO"}, {3, "THREE"}, {4, "FOUR"}, {5, "FIVE"},
                {6, "SIX"}, {7, "SEVEN"}, {8, "EIGHT"}, {9, "NINE"}
            };

            Dictionary<int, string> doubleDigit = new Dictionary<int, string>()
            {
                {1, "TEN"}, {2, "TWENTY"}, {3, "THIRTY"}, {4, "FORTY"}, {5, "FIFTY"},
                {6, "SIXTY"}, {7, "SEVENTY"}, {8, "EIGHTY"}, {9, "NINTY"}
            };

            Dictionary<int, string> exceptions = new Dictionary<int, string>()
            {
                {1, "ELEVEN"}, {2, "TWELVE"}, {3, "THIRTEEN"}, {4, "FOURTEEN"}, {5, "FIFTEEN"},
                {6, "SIXTEEN"}, {7, "SEVENTEEN"}, {8, "EIGHTEEN"}, {9, "NINETEEN"}
            };

            if (numArray[0] != 0)                                                   //NOTE: EMPTY SPACES ARE ASSUMED TO BE ZEROES
            {
                textValue = string.Concat(textValue, singleDigit[numArray[0]] + " HUNDRED");

                if (numArray[1] != 0 || numArray[2] != 0)
                {
                    textValue = string.Concat(textValue, " AND ");
                }

                else
                    return textValue;
            }

            if (numArray[1] == 1 && numArray[2] != 0)
            {
                textValue = string.Concat(textValue, exceptions[numArray[2]]);
                return textValue;
            }

            else if (numArray[1] != 0)
            {
                textValue = string.Concat(textValue, doubleDigit[numArray[1]]);
                if (numArray[2] == 0)
                    return textValue;
                else
                {
                    textValue = string.Concat(textValue, " " + singleDigit[numArray[2]]);
                    return textValue;
                }
            }

            else
            {
                textValue = string.Concat(textValue, singleDigit[numArray[2]]);
                return textValue;
            }
        }

        private static string SecondLevelText(int[] numArray)
        {
            string finalWord = "";
            string[] magnitudes = { "", " THOUSAND, ", " MILLION, ", " BILLION, ", " TRILLION, " };

            for (int i = numArray.Length; i > 0; i--)
            {
                int[] values = { numArray[i - 1], numArray[i - 2], numArray[i - 3] };
                string words = FirstLevelText(values);
                string unit = magnitudes[(i / 3) - 1];

                finalWord = string.Concat(finalWord, words + unit);
                i -= 2;
            }

            return finalWord;
        }
    }
}

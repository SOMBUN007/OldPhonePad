using System;

namespace demo01.variable
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            string output0 = OldPhonePad("  #");
            string output1 = OldPhonePad("33#");
            string output2 = OldPhonePad("227*#");
            string output3 = OldPhonePad("4433555 555666#");
            string output4 = OldPhonePad("8 88777444666*664#");
            Console.WriteLine(output0);
            Console.WriteLine(output1);
            Console.WriteLine(output2);
            Console.WriteLine(output3);
            Console.WriteLine(output4);

        }

        private static String OldPhonePad(string input)
        {

            string word = string.Empty;
            int countIndex = 0;
            char preLetter = '\0';

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                //remove previous char
                if (letter == '*')
                {
                    preLetter = '\0';
                    countIndex = 0;
                    continue;
                }

                //display wording
                if (preLetter == '\0' && letter == '#')
                    return word;

                if (preLetter == '\0')
                    preLetter = letter;
                else if (preLetter == letter)
                    countIndex++;
                else
                {
                    int keypadNumber;
                    if (int.TryParse(preLetter.ToString(), out keypadNumber))
                    {
                        if (keypadNumber == 7 || keypadNumber == 9)
                            countIndex = countIndex % 4;
                        else
                            countIndex = countIndex % 3;

                        word += GetCharactor(keypadNumber, countIndex);
                        countIndex = 0;

                        if (letter == ' ')
                        {
                            preLetter = '\0';
                            continue;
                        }
                        
                    }
                    else
                    {
                        word += ' ';
                    }

                    if (letter == '#')
                        return word;

                    preLetter = letter;
                }
            }

            return "ไม่พบข้อมูล";
        }

        private static char GetCharactor(int keypadNumber, int index)
        {
            char[][] chars = {
                new char[] { '&', '\'', '(' },   //1
                new char[] { 'A', 'B', 'C' },   //2
                new char[] { 'D', 'E', 'F' },   //3
                new char[] { 'G', 'H', 'I' },   //4
                new char[] { 'J', 'K', 'L' },   //5
                new char[] { 'M', 'N', 'O' },   //6
                new char[] { 'P', 'Q', 'R', 'S' },   //7
                new char[] { 'T', 'U', 'V' },   //8
                new char[] { 'W', 'X', 'Y', 'Z' }    //9
            };
            return chars[(keypadNumber - 1)][index];
        }
    }
}
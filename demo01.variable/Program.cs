using System;

namespace demo01.variable
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //string output = OldPhonePad("33#");
            //string output = OldPhonePad("227*#");
            //string output = OldPhonePad("4433555 555666#");
            string output = OldPhonePad("8 88777444666*664#");
            Console.WriteLine(output);
        }

        private static String OldPhonePad(string input)
        {
            string word = string.Empty;
            int count = 0;
            char preLetter = '\0';

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (letter == '*')
                {
                    preLetter = '\0';
                    count = 0;
                    continue;
                }

                if (letter == ' ')
                {
                    word += GetCharactor(int.Parse(preLetter.ToString()), count);
                    preLetter = '\0';
                    count = 0;
                    continue;
                }

                if (preLetter == '\0' && letter == '#')
                    return word;

                if (preLetter == '\0')
                    preLetter = letter;
                else if (preLetter == letter)
                    count++;
                else
                {
                    int keypadNumber;
                    bool success = int.TryParse(preLetter.ToString(), out keypadNumber);
                    if (success)
                    {

                        if (keypadNumber == 7 || keypadNumber == 9)
                        {
                            count = count % 4;
                        }
                        else
                            count = count % 3;

                        word += GetCharactor(keypadNumber, count);

                        if (letter == '#')
                            return word;

                        count = 0;
                        preLetter = letter;
                    }
                    else
                    {
                        Console.WriteLine("การแปลงไม่สำเร็จ");
                    }
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
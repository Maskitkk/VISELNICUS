using System;
using System.Linq;


namespace VISELNICUS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "словоблуд", "гвоздодёр", "тридцать", "Шекспир", "зад", "ход", "кот", "пёс", "котичка", "котятка", "васятка" };

            Random random = new Random();

            string wordToGuess = words[random.Next(0, words.Length)];

            string guessed = "";

            int tries = 7;
            
            while (tries > 0 && !guessed.Equals(wordToGuess))
            {
                Console.Clear();
                Console.WriteLine("Угадай слово: " + GetWordWithSpaces(wordToGuess, guessed));
                
                Console.WriteLine(GetHangmanDrawing(tries));

                Console.WriteLine("Введи букву: ");
                char input = char.Parse(Console.ReadLine());



                if (wordToGuess.Contains(input))
                {
                    guessed += input;
                }
                else
                {
                    tries--;
                }
            }

            Console.Clear();
            if (guessed.Equals(wordToGuess))
            {
                Console.WriteLine("Поздравляю! Слово отгадано: " + wordToGuess);

            }
            else
            {
                Console.WriteLine("Извиняй, попытки кончились :( ");
                Console.WriteLine(GetHangmanDrawing(0));
            }

            Console.ReadKey();
            
        }

        static string GetWordWithSpaces(string word, string guessed)
        {
            string result = "";

            foreach (char c in word)
            {
                result += (guessed.Contains(c.ToString())) ? c + " " : "_ ";
            }

            return result.Trim();
        }

        static string GetHangmanDrawing(int tries)
        {
            switch (tries)
            {
                case 7: return @"
                    +---+
                        |
                        |
                        |
                        |
                ==========";
                case 6: return @"
                    +---+
                    |   |
                        |
                        |
                        |
                ==========";
                case 5: return @"
                    +---+
                    |   |
                    o   |
                        |
                        |
                ==========";
                case 4: return @"
                    +---+
                    |   |
                    o   |
                    |   |
                        |
                ==========";
                case 3: return @"
                    +---+
                    |   |
                    o   |
                    |\  |
                        |
                ==========";
                case 2: return @"
                    +---+
                    |   |
                    o   |
                   /|\  |
                        |
                ==========";
                case 1: return @"
                    +---+
                    |   |
                    o   |
                   /|\  |
                   /    |
                ==========";
                case 0: return @"
                    +---+
                    |   |
                    o   |
                   /|\  |
                   / \  |
                ==========";

                default: return "";


            }
        }
    }

}


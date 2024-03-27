using System;
using System.Linq;
using System.Net;


namespace VISULNICUS2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
            string[] words = { "балбес", "кот", "мотвей", "водим", "иван" };

            Random random = new Random();

            string wordToGuess = words[random.Next(0, words.Length)];

            int tries = 7;

            string guessed = "";

            
                Console.Clear();
                while (tries > 0 && !guessed.Equals(wordToGuess))
                {
                Console.Clear();

                Console.WriteLine("Отгадай слово: " + GetWordWithSpaces(wordToGuess, guessed));


                Console.WriteLine(GetHangmanDrawing(tries));

                Console.WriteLine("Введи букву: ");
                
                char input = char.Parse(Console.ReadLine());

                bool found = false;

                if (!guessed.Contains(input.ToString()))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == input)
                        {
                            guessed += input;
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        tries--;
                    }

                    if (guessed.Length == wordToGuess.Length)
                    {
                        break;
                    }
                }

            }

            Console.Clear();

            if (guessed.Length == wordToGuess.Length)
            {
                Console.WriteLine("Поздравляю! Слово " + wordToGuess + " отгадано!");
            }
            else
            {
                Console.WriteLine("Жаль, но из-за тебя человек погиб");
                Console.WriteLine(GetHangmanDrawing(0));
            }

             Console.WriteLine("Попробуешь ещё?");

                if ((Console.ReadLine() != "да"))
                {
                    break ;
                }

            }
        }

        static string GetWordWithSpaces(string word, string guessed)
        {
            string result = "";
            foreach (char c in word)
            {
                result += (guessed.Contains(c.ToString())) ? c + " " : " _";
            }
            return result.Trim();
        }



        static string GetHangmanDrawing(int tries)
        {
            switch (tries)
            {
                case 7: return @"
                ----+
                    |
                    |
                    |
                    |
               ======";

                case 6: return @"
                ----+
                |   |
                    |
                    |
                    |
               ======";
                case 5: return @"
                ----+
                |   |
                o   |
                    |
                    |
               ======";
                case 4: return @"
                ----+
                |   |
                o   |
                |   |
                    |
               ======";
                case 3: return @"
                ----+
                |   |
                o   |
               /|   |
                    |
               ======";
                case 2: return @"
                ----+
                |   |
                o   |
               /|\  |
                    |
               ======";
                case 1: return @"
                ----+
                |   |
                o   |
               /|\  |
               /    |
               ======";
                case 0: return @"
                ----+
                |   |
                o   |
               /|\  |
               / \  |
               ======";
                default: return "";

            }
        }
    }
}

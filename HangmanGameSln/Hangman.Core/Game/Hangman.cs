using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private int _lives = 6;


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {

            string wonGuess = string.Empty;


            //Give 20 words to guess from

            string[] listofWords = new string[20];
            listofWords[0] = "tennis";
            listofWords[1] = "octopus";
            listofWords[2] = "estrogen";
            listofWords[3] = "hummus";
            listofWords[4] = "peppermint";
            listofWords[5] = "domain";
            listofWords[6] = "Fuzzy";
            listofWords[7] = "mother";
            listofWords[8] = "class";
            listofWords[9] = "Factory";
            listofWords[10] = "mobile";
            listofWords[11] = "Janet";
            listofWords[12] = "program";
            listofWords[13] = "netball";
            listofWords[14] = "soccer";
            listofWords[15] = "generator";
            listofWords[16] = "family";
            listofWords[17] = "buzzed";
            listofWords[18] = "teleport";
            listofWords[19] = "zodiac";


            //select a random word from the array

            Random randomWordGenerator = new Random();
            var index = randomWordGenerator.Next(0, 19);
            string guessingword = listofWords[index];
            char[] userguess = guessingword.ToCharArray();



            //outputting the random words length as dashes/ absent character

            for (int i = 0; i < guessingword.Length; i++)

            {
                userguess[i] = '-';
            }


            //looping the game until the correct word is found

            while (_lives >= 0 && _lives <= 6 )

            {
               

                // represent hangmans body                       6 = begining 0 = Game Over
                _renderer.Render(5, 5, _lives);


                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                //  Console.WriteLine("--------------");
                Console.WriteLine(userguess);


                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = char.Parse(Console.ReadLine());

                bool livesStages = false;
                {

                    for (var g = 0; g < guessingword.Length; g++)
                    {
                        if (nextGuess == guessingword[g])
                        {
                            userguess[g] = nextGuess;
                            livesStages = true;
                        }
                    }


                    if (!livesStages)
                    {
                        _lives--;
                        _renderer.Render(5, 5, _lives); 
                    }

                }
                // If player won 

                wonGuess = new string(userguess);

                if (wonGuess == guessingword)
                {
                    Console.WriteLine("YOU WON!");
                }


            }
            
            //if player loses

            if (wonGuess != guessingword)
                {
                 Console.WriteLine("OOH NO YOU LOST");
                }

        }

    }
}

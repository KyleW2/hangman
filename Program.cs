using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Hangman
{
    class Game
    {
        private bool hasWon = false;
        private bool hasLost = false;
        private char[] currentGuess;
        private string word;
        private int guesses;
        private int remainingGuesses;
        
        public Game(int guesses) {
            this.guesses = guesses;
            this.remainingGuesses = guesses;

            this.word = getWord();
            this.currentGuess = new char[word.Length];

            for (int i = 0; i < word.Length; i++) {
                currentGuess[i] = '*';
            }
        }

        private string getWord()
        {
            return "fart";
        }

        public void run() {
            while (!(hasWon || hasLost)) {
                takeTurn();
            }
        }

        public void takeTurn() {
            Console.Write("Please enter your guess: ");

            // TODO: - Make this support guessing String
            //       - Error handling
            char guess = char.Parse(Console.ReadLine());
            this.remainingGuesses--;

            for (int j = 0; j < word.Length; j++)
            {
                if (guess == word[j]) {
                    currentGuess[j] = guess;
                }
            }

            writeCurrentGuess();

            checkWinOrLoss();
        }

        public void checkWinOrLoss() {
            if (this.remainingGuesses < 0) {
                Console.WriteLine("You loose.");
                hasLost = true;
            }

            foreach (char c in this.currentGuess) {
                if (c == '*') {
                    return;
                }
            }

            Console.WriteLine("You win!");
            hasWon = true;
        }

        public void writeCurrentGuess() {
            Console.Write("\n");

            for (int j = 0; j < word.Length; j++)
            {
                if (currentGuess[j] == null) {
                    Console.Write("*");
                } else {
                    Console.Write(currentGuess[j]);
                }
            }

            Console.Write("\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game test = new Game(5);
            test.run();
        }
    }
}
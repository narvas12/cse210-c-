using System;

class Program
{
    static void Main()
    {
        // Game loop
        while (true)
        {
            // Step 1: Generate a random number between 1 and 100 as the magic number
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int numberOfGuesses = 0;

            // Inner game loop
            while (true)
            {
                // Step 2: Ask the user for a guess
                Console.Write("What is your guess? ");
                int userGuess = int.Parse(Console.ReadLine());

                numberOfGuesses++; // Increment the number of guesses

                // Step 3: Determine if the user needs to guess higher, lower, or if they guessed it
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");
                    break; // Exit the inner loop if the guess is correct
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                break; // Exit the outer loop if the user doesn't want to play again
            }
        }
    }
}

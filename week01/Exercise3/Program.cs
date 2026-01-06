using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";
        
        while (playAgain == "yes")
        {
            int magicNumber = random.Next(1, 101);
            int guess = -1;
            int guesses = 0;
            
            Console.WriteLine("What is the magic number? ");
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guesses++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            
            Console.WriteLine($"It took you {guesses} guesses.");
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}
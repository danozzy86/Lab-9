//Daniel Osborne
//Programming I - Lab 9 Number Guess
//Github - danozzy86

using System;
using System.Threading;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random =new Random(); //Creates a new instance of the random object.

            Console.Clear();
            Console.WriteLine("Enter a number greater than 0.");

            int guessCount = 0; //Creates variable used to count the number of guesses.
            int intMax = Sanitize(Console.ReadLine()); //Collects user input and sanitizes.
            int intRand = random.Next(0, intMax); //Selects a random number within the designated range.

            bool correct = false;//Loop Control

            while(!correct){
                //Will loop through until the number is guessed correctly, will state if the number is higher or lower with a guess counter.
                Console.Clear();
                Console.WriteLine("Try to guess the number between 0 and "+intMax+".");
                Console.WriteLine("Total guesses = "+guessCount+".");

                int guess = Sanitize(Console.ReadLine(), 0, intMax);

                if(guess > intRand){
                    guessCount += 1;
                    
                    Console.WriteLine("The number is lower than "+guess+".");
                    Thread.Sleep(1500);
                } else if(guess < intRand){
                    guessCount += 1;
                    
                    Console.WriteLine("The number is greater than "+guess+".");
                    Thread.Sleep(1500);
                } else if(guess == intRand){
                    guessCount += 1;

                    Console.Clear();
                    Console.WriteLine("You have guessed correctly, the number was "+guess+".");
                    Console.WriteLine("Total number of guesses was "+guessCount+".");
                    
                    correct = true;
                }
            }
        }

        private static int Sanitize(string strUsrInput, int min = 0, int max = 2147483647){
            //Sanitizes the user integer inputs to prevent errors. Limits the highest selectable number to the maximum possible 32bit integer by default.
            bool valid = false;
            int input = 0;

            while(!valid){
                if(!int.TryParse(strUsrInput, out int temp) || temp < min || temp > max){
                    Console.WriteLine("Enter a valid integer input");
                    strUsrInput = Console.ReadLine();
                } else {
                    input = temp;
                    valid = true;
                }
            }
            return input;
        }
    }
}

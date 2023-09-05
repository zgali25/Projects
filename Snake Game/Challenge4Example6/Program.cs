using Challenge4Example6;
using Chapter4Example6;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            // Hide the console cursor
            Console.CursorVisible = false;

            // Initialize the position of the snake and create a new snake
            Snake snake = new Snake(35, 20);
            Console.WriteLine(snake);

            // Create a new fruit
            Fruit fruit = new Fruit();
            Console.WriteLine(fruit);

            // Initialize player key
            ConsoleKey playerKey = ConsoleKey.RightArrow;

            // Start the game loop
            while (true)
            {
                // Check if a key is pressed
                if (Console.KeyAvailable)
                {
                    // Read the pressed key
                    playerKey = Console.ReadKey(true).Key;
                }

                // Move the snake according to the key pressed
                switch (playerKey)
                {
                    case ConsoleKey.LeftArrow:
                        snake.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        snake.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        snake.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        snake.MoveDown();
                        break;
                }

                // Check if the snake has eaten the fruit
                if (snake.HeadXPosition == fruit.XPosition && snake.HeadYPosition == fruit.YPosition)
                {
                    // Increase the length of the snake and create a new fruit
                    snake.Length++;
                    fruit = new Fruit();
                }

                // Clear the console
                Console.Clear();

                // Draw the fruit and the snake
                Console.WriteLine(fruit);
                Console.WriteLine(snake);

                // Pause execution for a while
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
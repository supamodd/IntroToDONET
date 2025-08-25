using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static int width = 20;
        static int height = 10;

        static int snakeX, snakeY;

        static int foodX, foodY;

        static Direction direction;

        static List<Tuple<int, int>> snakeBody = new List<Tuple<int, int>>();

        static bool gameOver;

        static Random random = new Random();

        static char wallSymbol = '#';

        enum Direction
        {
            Up,   
            Down,  
            Left,  
            Right 
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            InitializeGame();

            while (!gameOver)
            {
                HandleInput();

                UpdateGame();

                DrawGame();
                
                Thread.Sleep(100);
            }

            Console.SetCursorPosition(width / 2 - 5, height / 2);
            Console.WriteLine("Игра окончена!");

            Console.ReadKey();
        }

        static void InitializeGame()
        {
            snakeX = width / 2;
            snakeY = height / 2;

            snakeBody.Add(Tuple.Create(snakeX, snakeY));

            GenerateFood();

            direction = Direction.Right;

            gameOver = false;
        }

        static void GenerateFood()
        {
            do
            {
                foodX = random.Next(1, width - 1); 
                foodY = random.Next(1, height - 1); 
            } while (snakeBody.Contains(Tuple.Create(foodX, foodY)));
        }

        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W: 
                        if (direction != Direction.Down) 
                            direction = Direction.Up;
                        break;
                    case ConsoleKey.S: 
                        if (direction != Direction.Up)  
                            direction = Direction.Down;
                        break;
                    case ConsoleKey.A: 
                        if (direction != Direction.Right)
                            direction = Direction.Left;
                        break;
                    case ConsoleKey.D: 
                        if (direction != Direction.Left)  
                            direction = Direction.Right;
                        break;
                }
            }
        }

        static void UpdateGame()
        {
            int prevX = snakeX;
            int prevY = snakeY;

            switch (direction)
            {
                case Direction.Up:   
                    snakeY--;         
                    break;
                case Direction.Down: 
                    snakeY++;         
                    break;
                case Direction.Left: 
                    snakeX--;         
                    break;
                case Direction.Right: 
                    snakeX++;         
                    break;
            }

            if (snakeX < 1 || snakeX >= width - 1 || snakeY < 1 || snakeY >= height - 1) 
            {
                gameOver = true; 
                return;            
            }

            if (snakeBody.Contains(Tuple.Create(snakeX, snakeY)))
            {
                gameOver = true;  
                return;            
            }

            snakeBody.Insert(0, Tuple.Create(snakeX, snakeY));

            if (snakeX == foodX && snakeY == foodY)
            {
                GenerateFood();
            }
            else
            {
                snakeBody.RemoveAt(snakeBody.Count - 1);
            }
        }

        static void DrawGame()
        {
            Console.Clear();

            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write(wallSymbol);
                Console.SetCursorPosition(x, height - 1);
                Console.Write(wallSymbol);
            }

            for (int y = 1; y < height - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(wallSymbol);
                Console.SetCursorPosition(width - 1, y);
                Console.Write(wallSymbol);
            }

            Console.SetCursorPosition(foodX, foodY);
            Console.Write("A");

            foreach (var bodyPart in snakeBody)         
            {
                Console.SetCursorPosition(bodyPart.Item1, bodyPart.Item2); 
                Console.Write("O");                                         
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для вычисления факториала числа.");
            Console.Write("Введите целое положительное число: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                if (number >= 0)
                {
                    long factorial = CalculateFactorial(number);
                    Console.WriteLine($"{number}! = {factorial}");
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите целое *положительное* число.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введенное значение не является целым числом.");
            }

            Console.ReadKey();
        }

  
        static long CalculateFactorial(int n)
        {
            if (n == 0)
            {
                return 1; // Факториал 0 равен 1
            }
            else
            {
                long result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }
    }
}
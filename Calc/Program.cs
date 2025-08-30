using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Простой консольный калькулятор.");
            Console.WriteLine("Введите выражение (например, 2+3*4-1) или 'exit' для выхода.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    input = input.Replace(" ", "");

                    double result = EvaluateExpression(input);

                    Console.WriteLine($"= {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Неверный формат чисел. Введите числа корректно.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: Результат вычислений слишком большой или слишком маленький.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("Калькулятор завершил работу.");
        }

        static double EvaluateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Введено пустое выражение.");
            }

            var matches = System.Text.RegularExpressions.Regex.Matches(expression, @"(\d+(\.\d+)?)|([+\-*/])");

            List<double> operands = new List<double>();
            List<char> operators = new List<char>();

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string value = match.Value;
                if (double.TryParse(value, out double number))
                {
                    operands.Add(number);
                }
                else if (value.Length == 1 && "+-*/".Contains(value[0]))
                {
                    operators.Add(value[0]);
                }
                else
                {
                    throw new ArgumentException($"Недопустимый символ или последовательность: {value}");
                }
            }

            if (operands.Count == 0)
            {
                throw new ArgumentException("Не найдено чисел в выражении.");
            }
            if (operands.Count != operators.Count + 1)
            {
                throw new ArgumentException("Некорректная структура выражения (неверное количество операторов или операндов).");
            }

            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {
                    double result = 0;
                    if (operators[i] == '*')
                    {
                        result = operands[i] * operands[i + 1];
                    }
                    else 
                    {
                        if (operands[i + 1] == 0)
                        {
                            throw new ArgumentException("Деление на ноль.");
                        }
                        result = operands[i] / operands[i + 1];
                    }
                    operands[i] = result;
                    operands.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            double finalResult = operands[0];
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '+')
                {
                    finalResult += operands[i + 1];
                }
                else 
                {
                    finalResult -= operands[i + 1];
                }
            }

            return finalResult;
        }
    }
}

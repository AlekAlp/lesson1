using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkLesson4
{
    class Task2
    {
        static void Main(string[] args)
        {
            (string input, int sum) = GetNumbers();
            Console.WriteLine($"Введённые числа: {input}");
            Console.WriteLine($"Сумма введённых чисел {sum}");

        }

        static (string input, int sum) GetNumbers()
        {
            Console.WriteLine("Введите целые числа через пробел");
            string input = Console.ReadLine();
            string[] rowNumbers = input.Split(' '); // Конвертируем строку из чисел в строку массив, разделяя числа одним пробелом
            int sum = 0;
            for (int i = 0; i < rowNumbers.Length; i++)
            {
                sum += Convert.ToInt32(rowNumbers[i]);
            }
            return (input, sum);
        }
    }
}

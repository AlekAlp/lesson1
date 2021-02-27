using System;

namespace HomeworkLesson4
{
    class Task4
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел Фибоначчи: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{fibonachi(number)} ");
        }

        static int fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return fibonachi(n - 1) + fibonachi(n - 2);
            }

        }
    }
}

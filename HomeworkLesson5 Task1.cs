using System;
using System.IO;

namespace HomeworkLesson5
{
    class HomeworkLesson5
    {
        static void Main(string[] args)
        {
            string path = "text.txt";
            string outputData;
            if (File.Exists(path)) // Проверяем существование файла
            {
                outputData = File.ReadAllText(path);
                Console.Write($"Текст в файле: {outputData}"); // Выводим текст в файле, если он существует
            }
            Console.Write("Введите новый текст: ");
            string inputData = Console.ReadLine();
            File.WriteAllText(path, $"{inputData}\n");

            Console.Write($"Новый текст: {inputData}");
        }
    }
}

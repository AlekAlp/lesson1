using System;
using System.IO;

namespace HomeworkLesson5
{
    class HomeworkLesson5
    {
        static void Main(string[] args)
        {
            string path = "startup.txt";
            var timeNow = DateTime.Now;

            if (File.Exists(path)) // Проверяем существование файла
            {
                string[] filetext = File.ReadAllLines(path);
                foreach(var item in filetext)
                    Console.WriteLine(item); // Выводим записанное в файл время
            }

            Console.WriteLine(timeNow.ToLongTimeString()); // Выводим время в данный момент, даже если файл только создался
            File.AppendAllText(path, ($"{timeNow.ToLongTimeString()}\n")); // Дописываем в файл выведенное время
        }
    }
}

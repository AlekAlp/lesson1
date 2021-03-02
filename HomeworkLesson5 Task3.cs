using System;
using System.IO;

namespace HomeworkLesson5
{
    class HomeworkLesson5
    {
        static void Main(string[] args)
        {
            int quantity;
            string path = "number.bin";
            
            Console.WriteLine("Введите количество чисел: ");
            quantity = Convert.ToInt32(Console.ReadLine());
            byte[] numbers = new byte[quantity];
            Console.WriteLine("Вводите числа");
            for (int i = 0; i < quantity; i++)
            {
                numbers[i] = Convert.ToByte(Console.ReadLine());
            }
            File.WriteAllBytes(path, numbers);

            Console.Write("Числа в файле: ");
            byte[] fileNumbers = File.ReadAllBytes(path);
            foreach(var item in fileNumbers)
                Console.Write($"{item} ");
        }
    }
}

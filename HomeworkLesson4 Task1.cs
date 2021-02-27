using System;

namespace HomeworkLesson4
{
    class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество человек");
            int numString = Convert.ToInt32(Console.ReadLine());
            string[] inputData = new string[numString];

            for (int i = 0; i < numString; i++)
            {
                (string inputName, string inputLastName, string inputPatronymic) = GetFullName();
                inputData[i] = $"{inputName}\t{inputLastName}\t{inputPatronymic}";
            }

            for (int i = 0; i < numString; i++)
            {
                Console.WriteLine(inputData[i]);
            }
        }

        static (string firstName, string lastName, string patronymic) GetFullName()
        {
            Console.WriteLine("Введите имя, фамилию и отчество");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string patronymic = Console.ReadLine();

            return (firstName, lastName, patronymic);
        }
    }
}

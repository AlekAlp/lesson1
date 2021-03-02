using System;

namespace HomeworkLesson4
{
    class Task3
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядковый номер месяца: ");
            int month;
        input: month = Convert.ToInt32(Console.ReadLine());
            if (month > 0 && month < 13)
                Console.WriteLine(Print(month));
            else
                Console.WriteLine(Print(month));
                goto input;
        }

        static string Print(int month)
        {
            string yearTime;
            switch(month)
            {
                case 12:
                case 1:
                case 2:
                    yearTime = Convert.ToString(Season.Зима);
                    break;
                case 3:
                case 4:
                case 5:
                    yearTime = Convert.ToString(Season.Весна);
                    break;
                case 6:
                case 7:
                case 8:
                    yearTime = Convert.ToString(Season.Лето);
                    break;
                case 9:
                case 10:
                case 11:
                    yearTime = Convert.ToString(Season.Осень);
                    break;
                default:
                    yearTime = "Ошибка: введите число от 1 до 12";
                    break;
            }    
            return yearTime;
        }

        enum Season
        {
            Зима = 1,
            Весна,
            Лето,
            Осень
        }
    }
}

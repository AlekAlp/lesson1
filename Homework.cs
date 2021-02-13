using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            var Today = DateTime.Now;
 //           string name = Console.ReadLine(); // Если необходимо ввести имя пользователя вручную
            string name = Environment.UserName; // Если необходимо использовать системное имя пользователя
            Console.WriteLine("Привет " + name + ", сегодня " + Today.ToLongDateString());

        }
    }
}
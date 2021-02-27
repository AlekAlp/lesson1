using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите минимальную и максимальную температуру за сутки"); // (Задание 1) вывод средней температуры
            int tempMin = Convert.ToInt32(Console.ReadLine());
            int tempMax = Convert.ToInt32(Console.ReadLine());
            int aveTemp = (tempMax + tempMin) / 2;
            string temp;
            if ((aveTemp % 10 == 1) && (aveTemp != 11))
                temp = "градус";
            else if ((aveTemp % 10 > 1) && (aveTemp % 10 < 5) && (aveTemp != 12) && (aveTemp != 13) && (aveTemp != 14))
                temp = "градуса";
            else
                temp = "градусов";
            Console.WriteLine("Среднесуточная температура " + aveTemp + " " + temp);
        
            Console.WriteLine("Введите порядковый номер месяца"); // (Задание 2) вывод названия месяца
                enterMonth:  int monthNum = Convert.ToInt32(Console.ReadLine());
                switch (monthNum)
                {
                    case 1:
                        Console.WriteLine("Январь");
                        break;
                    case 2:
                        Console.WriteLine("Февраль");
                        break;
                    case 3:
                        Console.WriteLine("Март");
                        break;
                    case 4:
                        Console.WriteLine("Апрель");
                        break;
                    case 5:
                        Console.WriteLine("Май");
                        break;
                    case 6:
                        Console.WriteLine("Июнь");
                        break;
                    case 7:
                        Console.WriteLine("Июль");
                        break;
                    case 8:
                        Console.WriteLine("Август");
                        break;
                    case 9:
                        Console.WriteLine("Сентябрь");
                        break;
                    case 10:
                        Console.WriteLine("Октябрь");
                        break;
                    case 11:
                        Console.WriteLine("Ноябрь");
                        break;
                    case 12:
                        Console.WriteLine("Декабрь");
                        break;
                    default:
                        Console.WriteLine("Неправильный номер");
                        goto enterMonth;
                }

                  Console.WriteLine(monthNum % 2 == 0 ? "Номер месяца чётное" : "Номер месяца нечётное"); // (Задание 3) Определение чётности или нечётности введёного числа

                  if ((monthNum == 1) || (monthNum == 11) || (monthNum == 12) && (aveTemp > 0)) // (Задание 5) Вывод текста на экран при выполнении условий (зимний месяц и температура выше 0)
                  Console.WriteLine("Дождливая зима");

            Console.WriteLine("");

            //Задание 6

            int allOffices = 0b000001;
            int monday = 0b000110, tuesday = 0b000111, wednesday = 0b001011, thursday = 0b001111, friday = 0b010011, saturday = 0b000110, sunday = 0b001110;

            Console.WriteLine((monday & allOffices) == allOffices ? "В понедельник работают оба офиса" : "В понедельник работает офис №2");
            Console.WriteLine((tuesday & allOffices) == allOffices ? "Во вторник работают оба офиса" : "Во вторник работает офис №2");
            Console.WriteLine((wednesday & allOffices) == allOffices ? "В среду работают оба офиса" : "В среду работает офис №2");
            Console.WriteLine((thursday & allOffices) == allOffices ? "В четверг работают оба офиса" : "В четверг работает офис №2");
            Console.WriteLine((friday & allOffices) == allOffices ? "В пятницу работают оба офиса" : "В пятницу работает офис №2");
            Console.WriteLine((saturday & allOffices) == allOffices ? "В субботу работают оба офиса" : "В субботу работает офис №2");
            Console.WriteLine((sunday & allOffices) == allOffices ? "В воскресенье работают оба офиса" : "В воскресенье работает офис №2");

            Console.WriteLine("");

            // Задание 4
            // Вывод чека с заранее заданными значениями

            float price1 = 25.99f, price2 = 49.99f, ndsPrice, money;
            string name = "Иван", surName = "Иванов";
            long znkkt = 65465423497277, rnkkt = 7654654234972778, inn = 8653863468, fn = 5686538634683486, fp = 7567268489;
            int fd = 75367, check = 001, groupDay = 00101;

            ndsPrice = (price1 + price2) * 0.10f;
            money = price1 + price2 + ndsPrice;

            Console.WriteLine("##############################################");
            Console.WriteLine("Кассовый чек");
            Console.WriteLine("Хлеб " + Math.Round(price1, 2));
            Console.WriteLine("Молоко " + Math.Round(price2, 2));
            Console.WriteLine("Итог " + Math.Round(money, 2));
            Console.WriteLine("Сумма НДС 10% " + Math.Round(ndsPrice, 2));
            Console.WriteLine("Безналичными " + Math.Round(money, 2));
            Console.WriteLine("Кассир " + name + " " + surName);
            Console.WriteLine("ООО Магазин");
            Console.WriteLine("Г. Санкт-Петербург");
            Console.WriteLine("##############################################");
            Console.WriteLine("ЗН ККТ " + znkkt);
            Console.WriteLine("РН ККТ " + rnkkt);
            Console.WriteLine("ИНН " + inn);
            Console.WriteLine("ФН " + fn);
            Console.WriteLine("ФД " + fd);
            Console.WriteLine("ФП " + fp);
            Console.WriteLine("ЧЕК " + check++ + " ПРИХОД");
            Console.WriteLine("СНО ОСН ");
            Console.WriteLine("СМЕНА " + groupDay);
            Console.WriteLine("##############################################");

        }
    }
}
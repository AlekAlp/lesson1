using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace HomeworkLesson6
{
    class Program
    {
        static string ShowStartCommand()
        {
            Console.WriteLine("Нажмите Enter чтобы вернуться в начало");
            Console.ReadLine();
            Console.Clear();
            string command = "add - создать директорию\n" +
                             "todo - вызвать список задач\n" +
                             "sum - создать массив и просуммировать его элементы\n" +
                             "emp - создать список сотрудников\n" +
                             "любое другое значение - завершение программы\n";
            return command;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("add - создать директорию\n" +
                              "todo - вызвать список задач\n" +
                              "sum - создать массив и просуммировать его элементы\n" +
                              "emp - создать список сотрудников\n" +
                              "любое другое значение - завершение программы\n");
            for (string i = ""; i != "exit";)
            {
                i = Console.ReadLine();
                if (i == "add")
                    AddDirTree();
                else if (i == "todo")
                    ToDoList();
                else if (i == "sum")
                    SumArray();
                else if (i == "emp")
                    Employee();
                else
                    Process.GetCurrentProcess().Kill();
            }

            // Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
            void AddDirTree()
            {
                int recursiveQuantity;
                string pathDirTree = @"C:\Homework\";
                string DirTree = pathDirTree;
                Console.WriteLine("Введите 1 чтобы создать одну директорию, или другое количество чтобы создать директории рекурсивно");
                recursiveQuantity = Convert.ToInt32(Console.ReadLine());
                if (recursiveQuantity == 1)
                {
                    DirTree = Path.Combine(pathDirTree, "DirTree");
                    Directory.CreateDirectory(DirTree);
                    TimeFile(DirTree);
                    Console.WriteLine(ShowStartCommand());
                }
                else if (recursiveQuantity < 1)
                    Console.WriteLine("Неверное значение");
                else
                {
                    for (int i = 0; i < recursiveQuantity; i++)
                    {
                        DirTree = Path.Combine(DirTree, $"DirTree{i}");
                        Directory.CreateDirectory(DirTree);
                    }
                    TimeFile(DirTree); // Записываем текстовый файл из предыдущего домашнего задания по адресу 
                    Console.WriteLine(ShowStartCommand());
                }
            }
            void TimeFile(string DirTree)
            {
                DirTree = Path.Combine(DirTree, "TimeText.txt");
                var timeNow = DateTime.Now;

                if (File.Exists(DirTree))
                {
                    string[] filetext = File.ReadAllLines(DirTree);
                    foreach (var item in filetext)
                        Console.WriteLine(item);
                }

                Console.WriteLine(timeNow.ToLongTimeString());
                File.AppendAllText(DirTree, ($"{timeNow.ToLongTimeString()}\n"));
            }
            // написать приложение для ввода списка задач;
            // задачу описать классом ToDo с полями Title и IsDone;
            // на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив
            // имеющихся задач и вывести их на экран;
            // если задача выполнена, вывести перед её названием строку «[x]»;
            // вывести порядковый номер для каждой задачи;
            // при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым
            // номером как выполненную;
            // записать актуальный массив задач в файл tasks.json/xml/bin.
            void ToDoList()
            {
                string pathJsonToDo = @"C:\Homework\ToDoList.json"; // Делал изначально с форматом json, так как посчитал что надо выбрать самому формат
                List<ToDo> tasksList = ReadJson(pathJsonToDo);
                ShowTaskList(tasksList);
                string command = "x - отметить задачу выполненной\n" +
                                 "add - добавить новую задачу\n" +
                                 "exit - выход\n";
                Console.WriteLine(command);
                string i;
                do
                {
                    i = Console.ReadLine();
                    if (i == "x")
                    {
                        if (tasksList.Count != 0)
                            CompleteTask(ref tasksList, pathJsonToDo);
                        else
                            Console.WriteLine($"Задач нет\n{command}");
                    }
                    else if (i == "add")
                    {
                        AddTask(ref tasksList);
                    }
                }while (i != "exit") ;
                Console.WriteLine(ShowStartCommand());
            }
            static void SaveTaskList(List<ToDo> tasksList, string pathJsonToDo)
            {
                string jsonText = JsonSerializer.Serialize(tasksList);
                File.WriteAllText(pathJsonToDo, jsonText);
            }
            void AddTask(ref List<ToDo> tasksList)
            {
                string pathJsonToDo = @"C:\Homework\ToDoList.json";
                Console.Write($"Новая задача: ");
                string newTask = Console.ReadLine();
                tasksList.Add(new ToDo(newTask, "[ ]"));
                SaveTaskList(tasksList, pathJsonToDo);
                ToDoList();
            }
            void CompleteTask(ref List<ToDo> tasksList, string pathJsonToDo)
            {
                Console.Write("Введите порядковый номер задачи из списка (0 - отменить): ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    number--; // Понижаем число на единицу, чтобы список ссылался правильно
                    if (number == -1)
                    {
                        ToDoList();
                    }
                    else if (((number) < tasksList.Count) && (tasksList[number].IsDone == "[ ]"))
                    {
                        tasksList[number].IsDone = "[X]";
                        SaveTaskList(tasksList, pathJsonToDo);
                        ToDoList();
                    }
                    else if (((number) < tasksList.Count) && (tasksList[number].IsDone == "[X]"))
                    {
                        Console.WriteLine("Задача уже выполнена");
                        CompleteTask(ref tasksList, pathJsonToDo);
                    }
                    else
                    {
                        Console.WriteLine("Неправильный номер задачи");
                        CompleteTask(ref tasksList, pathJsonToDo);
                    }
                }
            }
            static List<ToDo> ReadJson(string path)
            {
                List<ToDo> tasksList = new List<ToDo>();
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    tasksList = JsonSerializer.Deserialize<List<ToDo>>(jsonString);
                }
                return tasksList;
            }
            static void ShowTaskList(List<ToDo> tasksList)
            {
                for (int i = 0; i < tasksList.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {tasksList[i].IsDone} {tasksList[i].Title}"); // Прописал i + 1, чтобы выведенный список начинался с единицы
                }
            }
            //при подаче массива другого размера необходимо бросить исключение MyArraySizeException.
            //Далее метод должен пройтись по всем элементам массива, преобразовать в int, и просуммировать.
            //Если в каком - то элементе массива преобразование не удалось
            //(например, в ячейке лежит символ или текст вместо числа), 
            //должно быть брошено исключение MyArrayDataException, 
            //с детализацией в какой именно ячейке лежат неверные данные.
            //В методе main() вызвать полученный метод, обработать возможные исключения 
            //MySizeArrayException и MyArrayDataException, и вывести результат расчета.            
            void SumArray()
            {                
                int sum = 0, quantity;
                Console.Write("Введите размер массива: ");
                quantity = Convert.ToInt32(Console.ReadLine());
                string[,] array = new string[quantity, quantity]; // Для проверки исключения по размеру
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"[{i}] [{j}]: ");
                        array[i, j] = Console.ReadLine();
                    }
                }
                try
                {
                    sum = sumArray(array);
                }
                catch (MyArraySizeExeption ex)
                {
                    Console.WriteLine("Неправильный размер");
                    Console.WriteLine(ex.StackTrace);
                }
                catch (MyArrayDataException ex)
                {                    
                    Console.WriteLine(ex.StackTrace);
                }
                Console.Write($"Сумма: {sum}\n");
                Console.WriteLine(ShowStartCommand());
                return;
            }
            int sumArray(string[,] array)
            {
                int sumArray = 0;
                if (array.GetLength(0) != 4) throw new MyArraySizeExeption();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        try
                        {
                            sumArray += Int32.Parse(array[i, j]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Нечисловое значение: [{i}]-[{j}]");
                            throw new MyArrayDataException(i, j);
                        }
                    }
                }
                return sumArray;
            }
//            Конструктор класса должен заполнять эти поля при создании объекта;
//            Внутри класса «Сотрудник» написать метод, который выводит информацию об объекте в консоль;
//            Создать массив из 5 сотрудников

//            Пример:
//            Person[] persArray = new Person[5]; // Вначале объявляем массив объектов
//            persArray[0] = new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 30); // потом для каждой ячейки массива задаем объект
//            persArray[1] = new Person(...);
//            ...
//            persArray[4] = new Person(...);

//            С помощью цикла вывести информацию только о сотрудниках старше 40 лет;
            void Employee()
            {
                try
                {
                    Console.WriteLine(EmployeeList());
                    Console.WriteLine(ShowStartCommand());
                }
                catch (MyArraySizeExeption ex)
                {
                    Console.WriteLine("Неправильный формат даты");
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(ShowStartCommand());
                }
                catch (MyArrayDataException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(ShowStartCommand());
                }
            }

            string EmployeeList()
            {
                Console.Write("Введите количество сотрудников(0 - возврат на начальное меню): ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                EmployeeList[] persArray = new EmployeeList[quantity];
                for (int i = 0; i <= quantity - 1; i++)
                {
                    int[] birthday = new int[3];
                    Console.Write($"Введите имя {i+1} сотрудника: ");
                    string name = Console.ReadLine();
                    Console.Write($"Введите фамилию {i+1} сотрудника: ");
                    string surname = Console.ReadLine();
                    Console.Write($"Введите дату рождения(дд.мм.гггг) {i+1} сотрудника: ");
                    char[] delimiterChars = { ' ', ',', '.' };
                    string strBirthday = Console.ReadLine();
                    string[] arrStrBirthday = strBirthday.Split(delimiterChars);
                    if ((arrStrBirthday.GetLength(0) != 3) || // Проверка разделения даты рождения на день, месяц и год
                       (0 > Int32.Parse(arrStrBirthday[0]) || (30 <= Int32.Parse(arrStrBirthday[0]) || // Проверка дня рождения(условно) в пределах от 1 до 30
                       (0 > Int32.Parse(arrStrBirthday[1]) || (12 <= Int32.Parse(arrStrBirthday[1]) || // Проверка месяца рождения
                       (1900 >= Int32.Parse(arrStrBirthday[2]) || (2003 <= Int32.Parse(arrStrBirthday[2])))))))) // Проверка года рождения
                        throw new MyArraySizeExeption();
                    {
                        
                        for (int k = 0; k < 3; k++)
                        {
                            try
                            {
                                birthday[k] = Int32.Parse(arrStrBirthday[k]);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Введён неправильный формат даты");
                                throw new MyArrayDataException(k, 0);
                            }                            
                        }
                    }
                    persArray[i] = new EmployeeList(name, surname, birthday);                    
                }
                string emp = "";
                for (int i = 0; i < persArray.GetLength(0); i++)
                {
                    if((2021 - persArray[i].Birthday[2]) >= 40)
                    emp += $"{persArray[i].Info()}\n";
                }
                return emp;
            }
        }
    }
}
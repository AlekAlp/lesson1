using libraryTask;
using System;
using System.Diagnostics;

namespace ProcessExp
{
    class Program
    {
        static void Info(Process[] processes)
        {
            Console.Clear();
            Console.WriteLine($"Id\tProcess name");
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine($"{processes[i].Id}\t{processes[i].ProcessName}");
            }
        }
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            Info(processes);
            string commandName;
            int commandId;
            int choice;
            Console.WriteLine("завершить по id - 1\n" +
                              "завершить по названию - 2");
            choice = Int32.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.Write("введите id процесса: ");                    
                    commandId = Int32.Parse(Console.ReadLine());
                    for (int i = 0; i < processes.Length; i++)
                    {
                        if (processes[i].Id == commandId)
                            processes[i].Kill();
                    }                 
                    processes = Process.GetProcesses();                    
                    break;
                case 2:
                    Console.Write("введите название с учётом регистра процесса: ");
                    commandName = Console.ReadLine();
                    for (int i = 0; i < processes.Length; i++)
                    {
                        if (processes[i].ProcessName == commandName)
                            processes[i].Kill();                        
                    }
                    break;                    
                default:
                    break;
            }
            Msg.Message(); // задание с библиотекой
        }
    }
}

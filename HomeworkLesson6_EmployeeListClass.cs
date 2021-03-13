using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkLesson6
{
    [Serializable]
    class EmployeeList
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int[] Birthday { get; set; }
        public EmployeeList(string name, string surname, int[] birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = new int[3];
            for (int i = 0; i < Birthday.GetLength(0); i++)
            {
                Birthday[i] = birthday[i]; 
            }                      
        }
        public string Info()
        {
            return $"{Surname} {Name} {Birthday[0]}.{Birthday[1]}.{Birthday[2]}";
        }
        public EmployeeList()
        { }
        
    }
}

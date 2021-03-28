using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkLesson6
{
    [Serializable]
        public class ToDo
        {
            public string IsDone { get; set; }
            public string Title { get; set; }
            public ToDo(string title, string isdone)
            {
                IsDone = isdone;
                Title = title;            
            }        
            public ToDo()
            { }
        }
}
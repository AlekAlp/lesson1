using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkLesson6
{
    [Serializable]
    public class MyArrayDataException : Exception
    {
        public int row; 
        public int column;
        public MyArrayDataException(int Row, int Column)
        {
            Row = row;
            Column = column;
        }
    }
}
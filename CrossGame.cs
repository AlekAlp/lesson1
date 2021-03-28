using System;
using System.Collections.Generic;
using System.Text;

namespace cross
{
    class Cross
    {
        static int SIZE = 5;
        static int SIZE_WIN = 4;

        static char[,] field = new char[SIZE, SIZE];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();
        private static void InitField()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }
        private static void PrintField(int Player, int AI)
        {
            Console.Clear();
            Console.WriteLine("───────────");
            for (int i = 0; i < SIZE; i++)
            {
                Console.Write("│");
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write(field[i, j] + "│");
                }
                Console.WriteLine();
            }
            Console.WriteLine("───────────");
            Console.WriteLine($"Игрок {Player} : {AI} ИИ");
        }
        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }
        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE - 1 || y > SIZE - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }
        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static void PlayerStep()
        {
            int x = 0;
            int y = 0;
            do
            {
                x = random.Next(0, SIZE);
                y = random.Next(0, SIZE);
            } while (!IsCellValid(y, x));
            do
            {
                Console.WriteLine($"Введите координаты X Y (1-{SIZE}) (Enter - ввести случайноые координаты)");
                try
                {
                    x = Int32.Parse(Console.ReadLine()) - 1;
                    y = Int32.Parse(Console.ReadLine()) - 1;
                }
                catch(FormatException)
                { }
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiStep()
        {
            int x = 0;
            int y = 0;
            if (CheckAISymToWin(3))
                return;
            else if (CheckBlockFromAI(3))
                return;
            else if (CheckAISymToWin(2))
                return;
            else if (CheckBlockFromAI(2))
                return;
            else
            {
                do
                {
                    x = random.Next(0, SIZE);
                    y = random.Next(0, SIZE);
                } while (!IsCellValid(y, x));
                SetSym(y, x, AI_DOT);                
                return;
            }
        }
        private static bool CheckAISymToWin(int winQuantity)
        {            
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (i < SIZE - winQuantity)
                        if (VerticalCheckAI(i, j, AI_DOT, winQuantity) >= winQuantity)
                        {
                            if (field[i + winQuantity, j] == EMPTY_DOT)
                            {
                                SetSym(i + winQuantity, j, AI_DOT);
                                return true;
                            }
                            if ((i == 1) || (i == 2) || (i == 3))
                                if (field[i - 1, j] == EMPTY_DOT)
                                {
                                    SetSym(i - 1, j, AI_DOT);
                                    return true;
                                }
                        }
                    if (j < SIZE - winQuantity)
                    {
                        if (HorizontalCheckAI(i, j, AI_DOT, winQuantity) >= winQuantity)
                        {
                            if (field[i, j + winQuantity] == EMPTY_DOT)
                            {
                                SetSym(i, j + winQuantity, AI_DOT);
                                return true;
                            }
                            if ((j == 1) || (j == 2) || (j == 3))
                                if (field[i, j - 1] == EMPTY_DOT)
                                {
                                    SetSym(i, j - 1, AI_DOT);
                                    return true;
                                }
                        }
                        if (i < SIZE - winQuantity)
                        {
                            if (DiagonalDownCheckAI(i, j, AI_DOT, winQuantity) >= winQuantity)
                            {

                                if ((j == 1) || (j == 2) || (j == 3))
                                    if ((i == 1) || (i == 2) || (i == 3))
                                        if (field[i - 1, j - 1] == EMPTY_DOT)
                                        {
                                            SetSym(i - 1, j - 1, AI_DOT);
                                            return true;
                                        }
                                if (field[i + winQuantity, j + winQuantity] == EMPTY_DOT)
                                {
                                    SetSym(i + winQuantity, j + winQuantity, AI_DOT);
                                    return true;
                                }
                            }
                        }
                    }
                    if (j > winQuantity - 2) 
                        if (DiagonalUpCheckAI(i, j, AI_DOT, winQuantity) >= winQuantity)
                        {
                            if ((j == 1) || (j == 2) || (j == 3))
                                if ((i == 1) || (i == 2) || (i == 3))
                                    if (field[i - 1, j + 1] == EMPTY_DOT)
                                    {
                                        SetSym(i - 1, j + 1, AI_DOT);
                                        return true;
                                    }
                            if ((i > winQuantity) && (IsCellValid(i + winQuantity, j - winQuantity)))
                                if (field[i + winQuantity, j - winQuantity] == EMPTY_DOT)
                                {
                                    SetSym(i + winQuantity, j - winQuantity, AI_DOT);
                                    return true;
                                }
                        }
                }
            }
            return false;
        }
        private static bool CheckBlockFromAI(int blockQuantity)
        {                        
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (i < SIZE - blockQuantity)
                        if (VerticalCheckAI(i, j, PLAYER_DOT, blockQuantity) >= blockQuantity)
                        {       
                            if (field[i + blockQuantity, j] == EMPTY_DOT)
                            {
                                SetSym(i + blockQuantity, j, AI_DOT);
                                return true;
                            }
                            if((i == 1) || (i == 2) || (i == 3))
                                if (field[i - 1, j] == EMPTY_DOT)
                                {
                                SetSym(i - 1, j, AI_DOT);
                                return true;
                            }
                        }
                    if (j < SIZE - blockQuantity)
                    {
                        if (HorizontalCheckAI(i, j, PLAYER_DOT, blockQuantity) >= blockQuantity)
                        {
                            if (field[i, j + blockQuantity] == EMPTY_DOT)
                            {
                                SetSym(i, j + blockQuantity, AI_DOT);
                                return true;
                            }
                            if ((j == 1) || (j == 2) || (j == 3))
                                if (field[i, j - 1] == EMPTY_DOT)
                                {
                                    SetSym(i, j - 1, AI_DOT);
                                    return true;
                                }
                        }                        
                        if (i < SIZE - blockQuantity)
                        {
                            if (DiagonalDownCheckAI(i, j, PLAYER_DOT, blockQuantity) >= blockQuantity)
                            {
                                
                                if ((j == 1) || (j == 2) || (j == 3))
                                    if ((i == 1) || (i == 2) || (i == 3))
                                        if (field[i - 1, j - 1] == EMPTY_DOT)
                                        {
                                            SetSym(i - 1, j - 1, AI_DOT);
                                            return true;
                                        }
                                if (field[i + blockQuantity, j + blockQuantity] == EMPTY_DOT)
                                {
                                    SetSym(i + blockQuantity, j + blockQuantity, AI_DOT);
                                    return true;
                                }
                            }
                        }
                    }
                    if (j > blockQuantity - 2) 
                        if (DiagonalUpCheckAI(i, j, PLAYER_DOT, blockQuantity) >= blockQuantity)
                        {
                            if ((j == 1) || (j == 2) || (j == 3))
                                if ((i == 1) || (i == 2) || (i == 3))
                                    if (field[i - 1, j + 1] == EMPTY_DOT)
                                    {
                                        SetSym(i - 1, j + 1, AI_DOT);
                                        return true;
                                    }
                            if ((i > blockQuantity) && (IsCellValid(i + blockQuantity, j - blockQuantity)))
                                if (field[i + blockQuantity, j - blockQuantity] == EMPTY_DOT)
                                {
                                    SetSym(i + blockQuantity, j - blockQuantity, AI_DOT);
                                    return true;
                                }
                        }
                }
            }
            return false;
        }
        private static bool CheckWin(char sym)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (i < 2)
                        if (VerticalCheck(i, j, sym) > 3)
                            return true;
                    if (j < 2)
                    {
                        if (HorizontalCheck(i, j, sym) > 3)                            
                            return true;
                        if(i - SIZE_WIN > -2)
                            if (DiagonalUpCheck(i, j, sym) > 3)
                                return true;
                        if (i < 2)
                        {
                            if(DiagonalDownCheck(i, j, sym) > 3)
                                return true;
                        }
                    }                    
                }
            }
            return false;
        }
        private static int HorizontalCheck(int y, int x, char sym)
        {
            int symQuantity = 0;
            for (int j = x; j < SIZE_WIN + x; j++)
            {
                if (field[y, j] == sym)
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int HorizontalCheckAI(int y, int x, char sym, int quantity)
        {
            int symQuantity = 0;
            for (int j = x; j < quantity + x; j++)
            {
                if (field[y, j] == sym)
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int VerticalCheck(int y, int x, char sym)
        {
            int symQuantity = 0;
            for (int i = y; i < SIZE_WIN + y; i++)
            {
                if (field[i, x] == sym)
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int VerticalCheckAI(int y, int x, char sym, int quantity)
        {
            int symQuantity = 0;
            for (int i = y; i < quantity + y; i++)
            {
                if (field[i, x] == sym)
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int DiagonalDownCheck(int y, int x, char sym)
        {
            int symQuantity = 0;
            for (int i = 0; i < SIZE_WIN; i++)
            {
                if ((field[i + y, i + x] == sym)) 
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int DiagonalDownCheckAI(int y, int x, char sym, int quantity)
        {
            int symQuantity = 0;            
            for (int i = 0; i < quantity + y; i++)
            {
                if ((i + y < SIZE) && (i + x < SIZE))
                    if ((field[i + y, i + x] == sym)) 
                        symQuantity++;
            }
            return symQuantity;
        }
        private static int DiagonalUpCheck(int y, int x, char sym)
        {
            int symQuantity = 0;

            for (int i = 0, j = 0; j < SIZE_WIN; i--, j++)
            {
                if ((field[y + i, x + j] == sym))
                    symQuantity++;
            }
            return symQuantity;
        }
        private static int DiagonalUpCheckAI(int y, int x, char sym, int quantity)
        {
            int symQuantity = 0;            
                for (int i = 0, j = 0; (x + j > x - quantity) && (y + i < y + quantity); i++, j--)
                {
                    if ((i + y < SIZE) && (j + x < SIZE))
                        if ((field[y + i, x + j] == sym))
                        symQuantity++;
                }            
            return symQuantity;
        }
        static void Main(string[] args)
        {
            int winPL = 0;
            int winAI = 0;
            while (true)
            {
                InitField();
                PrintField(winPL, winAI);
                while (true)
                {
                    PlayerStep();
                    PrintField(winPL, winAI);
                    if (CheckWin(PLAYER_DOT))
                    {
                        Console.WriteLine("Игрок победил! (x - выход)");
                        winPL++;
                        break;
                    }
                    if (IsFieldFull())
                    {
                        Console.WriteLine("DRAW");
                        break;
                    }
                    AiStep();
                    PrintField(winPL, winAI);
                    if (CheckWin(AI_DOT))
                    {
                        Console.WriteLine("ИИ победил! (x - выход)");
                        winAI++;
                        break;
                    }
                    if (IsFieldFull())
                    {
                        Console.WriteLine("DRAW");
                        break;
                    }
                }
                string exit = Console.ReadLine();
                if (exit == "x")
                    break;
            }
        }
    }
}
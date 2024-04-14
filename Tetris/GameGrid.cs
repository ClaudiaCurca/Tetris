using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        //use a indexer c# To read
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //public bool IsInside(int r, int c)
        //{
        //    return r>=0 && r<Rows && c>=0 && c<Columns;

        //}
        public bool IsInside(int r, int c)
        {
            if ((r >= Rows || r < 0) || (c >= Columns || c < 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //public bool IsEmpty(int r, int c)
        //{
        // return IsInside(r, c) && grid[r, c]==0;
        //}
        public bool IsEmpty(int r, int c)
        {
            if (IsInside(r, c))
            {
                if (grid[r, c] == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

public bool IsRowFull(int r)
        {
            for(int i = 0; i < Columns; i++)
            {
                if (grid[r, i]==0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsRowEmpty(int r)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (!(grid[r, i]==0))
                {
                    return false;
                }
            }
            return true;
        }
        public void ClearRow(int r)
        {
            for(int i=0;i< Columns; i++)
            {
                  grid[r,i] = 0;
                
            }
        }

        public void MoveRowDown(int r,int numClearedRows)
        {
            for(int i=0;i< Columns; i++)
            {
                grid[r + numClearedRows, i] = grid[r, i];
                grid[r, i] = 0;
            }

        }
        public int ClearFullRows()
        {
            int fullRows = 0;
            for (int r = Rows-1; r >0; r--)
            {
                    if (IsRowFull(r))
                    {
                        fullRows++;
                        ClearRow(r);

                    }
                    else
                    {
                        if (fullRows != 0)
                        {
                            MoveRowDown(r, fullRows);
                        }
                    }

                
            }
            return fullRows;
            
        }
    }
}

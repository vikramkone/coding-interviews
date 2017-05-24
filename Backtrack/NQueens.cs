namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NQueens : ISolution
    {
        private int input;

        private int count;

        public NQueens(int n)
        {
            this.input = n;
        }

        public void Run()
        {
            // initilize board to all zeroes
            int[,] board = new int[this.input, this.input];

            NQueensUtil(board, 0, this.input);
            Console.WriteLine("Total solutions: {0}", this.count);
        }

        private void NQueensUtil(int[,] board, int row, int n)
        {
            // if all queens are placed, then print board
            if (row == n)
            {
                this.count++;
                PrintBoard(board, n);
            };

            // check for each column for this row
            for (int col = 0; col < n; col++)
            {
                if (this.IsSafe(row, col, board, n))
                {
                    // place queen in this cell
                    board[row, col] = 1;

                    // place next queen in next row
                    NQueensUtil(board, row + 1, n);

                    // back track if this place isnt leading to a solution
                    board[row, col] = 0;
                }
            }
        }

        private bool IsSafe(int row, int col, int[,] board, int n)
        {
            // check if any queen is in same column or on the diagonal
            for (int i = 0; i < row; i++)
            {
                // check if any queen in same col in the rows above
                if (board[i, col] == 1) return false;

                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == 1)
                    {
                        // queen in upper left diagonal
                        if (i - j == row - col) return false;

                        // queen in upper right diagonal
                        if (i + j == row + col) return false;
                    }
                }
            }

            return true;
        }

        private void PrintBoard(int[,] board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("|{0}|", board[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
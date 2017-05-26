namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RatInMaze : ISolution
    {
        private int[,] maze;

        private int count;

        public RatInMaze()
        {
            this.maze = new int[,]
                       {
                        {1, 0, 0, 0},
                        {1, 1, 0, 1},
                        {0, 1, 0, 0},
                        {1, 1, 1, 1}
                       };
        }
        public void Run()
        {
            // solution matrix witl all zeroes
            int[,] sol = new int[this.maze.GetLength(0), this.maze.GetLength(1)];

            this.RateInMazeUtil(0, 0, sol);
            Console.WriteLine("Total no of solutions found: {0}", count);
        }

        private void RateInMazeUtil(int x, int y, int[,] sol)
        {
            // If reached the corner, then return true
            if (x == maze.GetLength(0) - 1 && y == maze.GetLength(1) - 1)
            {
                sol[x, y] = 1;
                this.count++;
                PrintMaze(sol);
            }

            if (IsSafe(x, y))
            {
                // Mark as solution
                sol[x, y] = 1;

                // Move to the right
                RateInMazeUtil(x + 1, y, sol);

                // Move to the bottom
                RateInMazeUtil(x, y + 1, sol);

                // If no solution found, then backtrack
                sol[x, y] = 0;
            }
        }

        private bool IsSafe(int x, int y)
        {
            // Return true, if points are inside the matrix and is an empty cell ie 1
            return x >= 0 && x < maze.GetLength(0) && y >= 0 && y < maze.GetLength(1) && maze[x, y] == 1;
        }
        private void PrintMaze(int[,] input)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write("|{0}|", input[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
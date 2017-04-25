namespace ProjectEuler.Problems
{
    internal class ProblemSolver015 : ProblemSolverBase
    {
        protected override string GetSolution()
        {

            const int SIZE = 20;
            long[,] grid = new long[SIZE + 1, SIZE + 1];

            for (int x = 0; x < SIZE + 1; x++)
            {
                for (int y = 0; y < SIZE + 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        grid[0, 0] = 1;
                    }
                    else if (x == 0)
                    {
                        grid[0, y] = grid[0, y - 1];
                    }
                    else if (y == 0)
                    {
                        grid[x, 0] = grid[x - 1, 0];
                    }
                    else
                    {
                        grid[x, y] = grid[x - 1, y] + grid[x, y - 1];
                    }
                }
            }

            var result = grid[SIZE, SIZE].ToString();

            return result;
        }

        protected override string GetProblemDescription()
        {
            return @"Starting in the top left corner of a 2x2 grid, there are 6 routes (without backtracking) to the bottom right corner.

(picture which cannot be shown here, see http://projecteuler.net/problem=15)

How many routes are there through a 20x20 grid?";
        }

        public override int ProblemNumber => 15;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

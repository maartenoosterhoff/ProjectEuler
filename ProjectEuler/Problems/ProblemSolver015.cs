namespace ProjectEuler.Problems
{
    internal class ProblemSolver015 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            //long dimension = 20;

            //var current = dimension + 1;
            //long solution = 1;
            //while (current > 1) {
            //    solution *= current;
            //    current--;
            //}
            //return solution.ToString();
            return "Unsolved";
        }

        protected override string GetProblemDescription()
        {
            return @"Starting in the top left corner of a 2x2 grid, there are 6 routes (without backtracking) to the bottom right corner.

(picture which cannot be shown here, see http://projecteuler.net/problem=15)

How many routes are there through a 20x20 grid?";
        }

        public override int ProblemNumber => 15;
    }
}

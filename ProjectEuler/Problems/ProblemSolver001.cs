﻿using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver001 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var solution = Enumerable.Range(1, 999)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();

            return solution.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        public override int ProblemNumber => 1;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

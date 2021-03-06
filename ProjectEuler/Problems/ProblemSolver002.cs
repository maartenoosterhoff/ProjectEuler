﻿using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver002 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var fibonacci = Helper.GetFibonacci(0, 4000000).ToList();
            var solution = fibonacci
                .Where(f => f % 2 == 0)
                .Sum();

            return solution.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";
        }

        public override int ProblemNumber => 2;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

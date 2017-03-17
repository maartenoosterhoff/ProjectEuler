using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver003 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            const long number = 600851475143;
            var squareRoot = ((long)Math.Sqrt(number)) + 1000;

            var primes = Helper.GetPrimesWithErastosthenesUpTill(squareRoot);
            var solution = primes
                .Where(x => number % x == 0)
                .Max();

            return solution.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?";
        }

        public override int ProblemNumber => 3;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

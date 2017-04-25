using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver016 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            const int exp = 1000;
            BigInteger b = new BigInteger(1);
            for (int i = 0; i < exp; i++)
            {
                b *= 2;
            }

            var digits = b.ToString();
            var sum = digits.Select(x => int.Parse(x.ToString())).Sum();

            return sum.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?";
        }

        public override int ProblemNumber => 16;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

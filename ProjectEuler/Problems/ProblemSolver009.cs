using System;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver009 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            for (var a = 1; a < 1000; a++)
            {
                for (var b = a + 1; b <= 1000; b++)
                {
                    var c2 = Math.Sqrt(a * a + b * b);
                    var c = (int)c2;
                    if (Math.Abs(c - c2) < 0.00001f && a < c && b < c && a + b + c == 1000)
                    {
                        return (a * b * c).ToString();
                    }
                }
            }
            return "No solution found.";
        }

        protected override string GetProblemDescription()
        {
            return @"A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.";
        }

        public override int ProblemNumber => 9;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

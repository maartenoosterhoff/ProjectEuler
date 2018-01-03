using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver025 : ProblemSolverBase
    {
        protected override string GetSolution()
        {

            var fibs = new List<BigInteger>
            {
                new BigInteger(1), new BigInteger(1)
            };
            while (fibs.Last().ToString().Length < 1000)
            {
                fibs.Add(fibs[fibs.Count - 1] + fibs[fibs.Count - 2]);
            }
            return fibs.Count.ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
Hence the first 12 terms will be:

F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144
The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
";
        }

        public override int ProblemNumber => 25;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

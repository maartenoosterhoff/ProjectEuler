using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver020 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            BigInteger sum = new BigInteger(1);
            for (int i = 2; i <= 100; i++)
            {
                sum = sum * i;
            }

            return sum.ToString().Select(x => int.Parse(x.ToString())).Sum().ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
";
        }

        public override int ProblemNumber => 20;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

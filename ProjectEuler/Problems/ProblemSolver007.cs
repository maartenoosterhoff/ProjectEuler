using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver007 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            return Helper.GetPrimesWithErastosthenesUpTill(1000000) // Take primes up till 1000000, this is a guess
                .Skip(1) // Skip prime 1 which should not be included according to the question
                .Skip(10000)
                .First()
                .ToString();
        }

        protected override string GetProblemDescription()
        {
            return @"By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?";
        }

        public override int ProblemNumber => 7;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

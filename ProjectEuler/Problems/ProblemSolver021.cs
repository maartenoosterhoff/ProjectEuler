using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver021 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var amicableNumbers = Enumerable.Range(1, 9999)
                .Where(x => x != GetSumOfProperDivisors(x))
                .Where(x => GetSumOfProperDivisors(GetSumOfProperDivisors(x)) == x)
                .Distinct()
                .ToArray();

            return amicableNumbers.Sum().ToString();
        }

        private readonly Dictionary<int, int> SumOfProperDivisors = new Dictionary<int, int>();

        private int GetSumOfProperDivisors(int number)
        {
            if (SumOfProperDivisors.ContainsKey(number))
            {
                return SumOfProperDivisors[number];
            }

            var sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                    sum += i;
            }

            SumOfProperDivisors[number] = sum;
            return sum;
        }
        

        protected override string GetProblemDescription()
        {
            return @"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
";
        }

        public override int ProblemNumber => 21;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}

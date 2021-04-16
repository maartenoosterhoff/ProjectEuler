using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver023 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            const int max = 28123;
            var abundantNumbers = Enumerable.Range(1, max + 10)
                .Where(x => x <= max)
                .Where(IsAbundant)
                .ToList();
            var sieve = Enumerable.Range(0, max).Select(x => true).ToArray();
            foreach (var a1 in abundantNumbers)
            {
                foreach (var a2 in abundantNumbers)
                {
                    var sum = a1 + a2;
                    var index = sum - 1;
                    if (index < max)
                    {
                        sieve[index] = false;
                    }
                }
            }

            var sum2 = 0;
            for (var index = 0; index < max; index++)
            {
                if (sieve[index])
                {
                    sum2 += index + 1;
                }
            }

            return sum2.ToString();
        }

        protected override string GetProblemDescription()
        {
            return "A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.\r\n\r\nA number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.\r\n\r\nAs 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.\r\n\r\nFind the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";
        }

        private bool IsAbundant(int number)
        {
            return this.GetProperDivisors(number).Sum() > number;
        }

        private bool IsDeficient(int number)
        {
            return this.GetProperDivisors(number).Sum() < number;
        }

        private IEnumerable<int> GetProperDivisors(int number)
        {
            var max = number / 2 + 1;
            for (var i = 1; i < max; i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                }
            }
        }

        public override int ProblemNumber => 23;
        public override SolvedState SolvedState => SolvedState.Solved;
    }
}
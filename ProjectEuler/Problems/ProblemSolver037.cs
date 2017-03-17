using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver037 : ProblemSolverBase
    {
        protected override string GetSolution()
        {
            var primes = Helper.GetPrimesWithErastosthenesUpTill(1000000).Skip(1).ToList();

            var truncatablePrimes = primes
                .Where(x => x > 7)
                .Where(x => IsTruncatable(x, primes))
                .ToArray();


            var sum = truncatablePrimes.Sum();

            return sum.ToString();
        }

        private static bool IsTruncatable(long prime, List<long> primes)
        {
            var length = prime.ToString().Length;
            var truncated = Enumerable.Range(1, length - 1)
                .Select(x => new
                {
                    left = prime / PowerTen(x),
                    right = prime % PowerTen(x)
                }
                )
                .SelectMany(x => new[] { x.left, x.right })
                .ToArray();

            return truncated.All(primes.Contains);
        }

        private static long PowerTen(int exp)
        {
            switch (exp)
            {
                case 0:
                    return 1;
                case 1:
                    return 10;
                case 2:
                    return 100;
                case 3:
                    return 1000;
                case 4:
                    return 10000;
                case 5:
                    return 100000;
                case 6:
                    return 1000000;
                case 7:
                    return 10000000;
                case 8:
                    return 100000000;
                case 9:
                    return 1000000000;
                default:
                    return (long)Math.Pow(10, exp);
            }
        }

        protected override string GetProblemDescription()
        {
            return @"The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.";
        }

        public override int ProblemNumber => 37;
    }
}
